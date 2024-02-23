using AutoMapper;
using BookStoreManagement.Dto;
using BookStoreManagement.Interfaces;
using BookStoreManagement.Models;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace BookStoreManagement.Controllers
{
    [Route("api/controller")]
    [ApiController]
    public class DonHangController : Controller
    {
        private readonly IDonHangRepository _donHangRepository;
        private readonly IMapper _mapper;
        public DonHangController(IDonHangRepository donHangRepository, IMapper mapper)
        {
            _donHangRepository = donHangRepository;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<DonHang>))]
        public IActionResult GetDonHangs()
        {
            var donhangs = _mapper.Map<List<DonHangDto>>(_donHangRepository.GetDonHangs());
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(donhangs);
        }
        [HttpGet("{donHangId}")]
        [ProducesResponseType(200, Type = typeof(DonHang))]
        [ProducesResponseType(400)]
        public IActionResult GetDonHang(int donHangId)
        {
            if (!_donHangRepository.DonHangExists(donHangId))
                return NotFound();
            var donhang = _mapper.Map<DonHang>(_donHangRepository.GetDonHangByMaDH(donHangId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(donhang);
        }
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateDonHang([FromBody] DonHangDto donHangCreate)
        {
            if (donHangCreate == null)
                return BadRequest(ModelState);

            var donhang = _donHangRepository.GetDonHangs()
                .Where(c => c.MaDonHang == donHangCreate.MaDonHang)
                .FirstOrDefault();

            if (donhang != null)
            {
                ModelState.AddModelError("", "Don hang da ton tai");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var donhangMap = _mapper.Map<DonHang>(donHangCreate);

            if (!_donHangRepository.DonHangCreate(donhangMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }
        [HttpPut("{donHangId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateDonHang(int donHangId, [FromBody] DonHangDto updatedDonHang)
        {
            if (updatedDonHang == null)
                return BadRequest(ModelState);

            if (donHangId != updatedDonHang.MaDonHang)
                return BadRequest(ModelState);

            if (!_donHangRepository.DonHangExists(donHangId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var donHangMap = _mapper.Map<DonHang>(updatedDonHang);

            if (!_donHangRepository.DonHangUpdate(donHangMap))
            {
                ModelState.AddModelError("", "Something went wrong updating company");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
        [HttpDelete("{donHangId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteDonHang(int donHangId)
        {
            if (!_donHangRepository.DonHangExists(donHangId))
            {
                return NotFound();
            }

            var donHangToDelete = _donHangRepository.GetDonHangByMaDH(donHangId);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_donHangRepository.DonHangDelete(donHangToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting company");
            }

            return NoContent();
        }
    }
}
