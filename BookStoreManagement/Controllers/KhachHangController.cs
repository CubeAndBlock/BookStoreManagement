using AutoMapper;
using BookStoreManagement.Dto;
using BookStoreManagement.Interfaces;
using BookStoreManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KhachHangController : Controller
    {
        private readonly IKhachHangRepository _khachHangRepository;
        private readonly IDonHangRepository _donHangRepository;
        private readonly IMapper _mapper;
        public KhachHangController(IKhachHangRepository khachHangRepository, IDonHangRepository donHangRepository, IMapper mapper)
        {
            _khachHangRepository = khachHangRepository;
            _donHangRepository = donHangRepository;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<KhachHang>))]
        public IActionResult GetKhachHangs()
        {
            var khachHangs = _mapper.Map<List<KhachHangDto>>(_khachHangRepository.GetKhachHangs());
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(khachHangs);
        }
        [HttpGet("{khachHangId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<KhachHang>))]
        [ProducesResponseType(400)]
        public IActionResult GetKhachHangs(int khachHangId)
        {
            if(!_khachHangRepository.KhachHangExists(khachHangId))
                return NotFound();
            var khachHang = _mapper.Map<KhachHang>(_khachHangRepository.GetKhachHangByMaKH(khachHangId));

            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(khachHang);
        }
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult KhachHangCreate([FromQuery] int donHangId, [FromBody] KhachHangDto khachHangCreate)
        {
            if (khachHangCreate == null)
                return BadRequest(ModelState);

            var khachHang = _khachHangRepository.GetKhachHangs()
                .Where(c => c.HoTen.ToUpper() == khachHangCreate.TaiKhoan.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (khachHang != null)
            {
                ModelState.AddModelError("", "Tai khoan nay da ton tai");
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var khachhangMap = _mapper.Map<KhachHang>(khachHangCreate);

            khachhangMap.DonHang = _donHangRepository.GetDonHangByMaDH(donHangId);

            if (!_khachHangRepository.KhachHangCreate(khachhangMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }
        [HttpPut("{khachHangId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateCenter(int khachHangId, [FromBody] KhachHangDto updatedKhachHang)
        {
            if (updatedKhachHang == null)
                return BadRequest(ModelState);

            if (khachHangId != updatedKhachHang.MaKH)
                return BadRequest(ModelState);

            if (!_khachHangRepository.KhachHangExists(khachHangId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var khachHangMap = _mapper.Map<KhachHang>(updatedKhachHang);

            if (!_khachHangRepository.KhachHangUpdate(khachHangMap))
            {
                ModelState.AddModelError("", "Something went wrong updating center");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
        [HttpDelete("{khachHangId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteKhachHang(int khachHangId)
        {
            if (!_khachHangRepository.KhachHangExists(khachHangId))
            {
                return NotFound();
            }

            var khachHangToDelete = _khachHangRepository.GetKhachHangByMaKH(khachHangId);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_khachHangRepository.KhachHangDelete(khachHangToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting center");
            }

            return NoContent();
        }
    }
}
