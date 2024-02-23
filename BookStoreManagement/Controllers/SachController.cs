using AutoMapper;
using BookStoreManagement.Dto;
using BookStoreManagement.Interfaces;
using BookStoreManagement.Models;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace BookStoreManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SachController : Controller
    {
        private readonly ISachRepository _sachRepository;
        private readonly IMapper _mapper;
        public SachController(ISachRepository sachRepository, IMapper mapper)
        {
            _sachRepository = sachRepository;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Sach>))]
        public IActionResult GetSachs()
        {
            var sachs = _mapper.Map<List<SachDto>>(_sachRepository.GetSaches());
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(sachs);
        }
        [HttpGet("{sachId}")]
        [ProducesResponseType(200, Type = typeof(Sach))]
        [ProducesResponseType(400)]
        public IActionResult GetSach(int sachId) {
            if (!_sachRepository.SachExists(sachId))
            {
                return NotFound();
            }

            var sach = _mapper.Map<Sach>(_sachRepository.GetSachByMaSach(sachId));

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(sach);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateSach([FromBody] SachDto sachCreate)
        {
            if (sachCreate == null)
                return BadRequest(ModelState);

            var sach = _sachRepository.GetSaches()
                .Where(c => c.TenSach.Trim().ToUpper() == sachCreate.TenSach.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (sach != null)
            {
                ModelState.AddModelError("", "Cuốn sách này đã tồn tại");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var sachMap = _mapper.Map<Sach>(sachCreate);

            if (!_sachRepository.SachCreate(sachMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        [HttpPut("{sachId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateSach(int sachId, [FromBody] SachDto updatedSach)
        {
            if (updatedSach == null)
                return BadRequest(ModelState);

            if (sachId != updatedSach.MaSach)
                return BadRequest(ModelState);

            if (!_sachRepository.SachExists(sachId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var sachMap = _mapper.Map<Sach>(updatedSach);

            if (!_sachRepository.SachUpdate(sachMap))
            {
                ModelState.AddModelError("", "Something went wrong updating sach");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
        [HttpDelete("{sachId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteSach(int sachId)
        {
            if (!_sachRepository.SachExists(sachId))
            {
                return NotFound();
            }

            var sachToDelete = _sachRepository.GetSachByMaSach(sachId);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_sachRepository.SachDelete(sachToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting sach");
            }

            return NoContent();
        }

    }
}
