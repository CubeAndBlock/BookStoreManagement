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
    public class TacGiaController : Controller
    {
        private readonly ITacGiaRepository _tacGiaRepository;
        private readonly IMapper _mapper;
        public TacGiaController(ITacGiaRepository tacGiaRepository, IMapper mapper)
        {
            _tacGiaRepository = tacGiaRepository;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<TacGia>))]
        public IActionResult GetTacGia() {
            var tacgia = _mapper.Map<List<TacGiaDto>>(_tacGiaRepository.GetTacGias());
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(tacgia);
        }
        [HttpGet("{tacgiaId}")]
        [ProducesResponseType(200, Type = typeof(TacGia))]
        [ProducesResponseType(400)]
        public IActionResult GetTacGia(int tacgiaId)
        {
            if(!_tacGiaRepository.TacGiaExists(tacgiaId))
            {
                return NotFound();
            }

            var tacgias = _mapper.Map<TacGia>(_tacGiaRepository.GetTacGiaByMaTG(tacgiaId));

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(tacgias);
        }
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateTacGia([FromBody] TacGiaDto tacgiaCreate)
        {
            if (tacgiaCreate == null)
                return BadRequest(ModelState);

            var tacgia = _tacGiaRepository.GetTacGias()
                .Where(c => c.TenTacGia.Trim().ToUpper() == tacgiaCreate.TenTacGia.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (tacgia != null)
            {
                ModelState.AddModelError("", "Tac Gia already exists");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tacgiaMap = _mapper.Map<TacGia>(tacgiaCreate);

            if (!_tacGiaRepository.TacGiaCreate(tacgiaMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }
        [HttpPut("{tacgiaId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateTacGia(int tacgiaId, [FromBody] TacGiaDto updatedTacGia)
        {
            if (updatedTacGia == null)
                return BadRequest(ModelState);

            if (tacgiaId != updatedTacGia.MaTacGia)
                return BadRequest(ModelState);

            if (!_tacGiaRepository.TacGiaExists(tacgiaId))
                return NotFound();
            if (!ModelState.IsValid)
                return BadRequest();

            var tacgiaMap = _mapper.Map<TacGia>(updatedTacGia);

            if (!_tacGiaRepository.TacGiaUpdate(tacgiaMap))
            {
                ModelState.AddModelError("", "Something went wrong updating tacgia");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
        [HttpDelete("{tacgiaId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteTacGia(int tacgiaId)
        {
            if (!_tacGiaRepository.TacGiaExists(tacgiaId))
            {
                return NotFound();
            }

            var tacgiaToDelete = _tacGiaRepository.GetTacGiaByMaTG(tacgiaId);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_tacGiaRepository.TacGiaDelete(tacgiaToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting tac gia");
            }

            return NoContent();
        }
    }
}
