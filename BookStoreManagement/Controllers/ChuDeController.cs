using AutoMapper;
using BookStoreManagement.Dto;
using BookStoreManagement.Interfaces;
using BookStoreManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChuDeController : Controller
    {
        private readonly IChuDeRepository _chuDeRepository;
        private readonly ISachRepository _sachRepository;
        private readonly IMapper _mapper;
        public ChuDeController(IChuDeRepository chuDeRepository, ISachRepository sachRepository, IMapper mapper)
        {
            _chuDeRepository = chuDeRepository;
            _sachRepository = sachRepository;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(200,Type = typeof(IEnumerable<ChuDe>))]
        public IActionResult GetChuDe() {
            var chudes = _mapper.Map<List<ChuDeDto>>(_chuDeRepository.GetChuDes());
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(chudes);
        }
        [HttpGet("{chudeId}")]
        [ProducesResponseType(200, Type=typeof(ChuDeDto))]
        [ProducesResponseType(400)]
        public IActionResult GetChuDes(int chudeId) {
            if (!_chuDeRepository.ChuDeExists(chudeId))
                return NotFound();
            var chudes = _mapper.Map<ChuDeDto>(_chuDeRepository.GetChuDeByMaCD(chudeId));
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(chudes);
        }
        [HttpGet("sach/{chudeId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ChuDe>))]
        [ProducesResponseType(400)]
        public IActionResult GetSachByMaCD(int chudeId)
        {
            var saches = _mapper.Map<List<SachDto>>(_chuDeRepository.GetSachByChuDe(chudeId));
            if (!ModelState.IsValid)
                return BadRequest();
            return Ok(saches);
        }
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateChuDe([FromQuery] int sachId, [FromBody] ChuDeDto chudeCreate)
        {
            if (chudeCreate == null)
                return BadRequest(ModelState);

            var nxb = _chuDeRepository.GetChuDes()
                .Where(c => c.TenChuDe.Trim().ToUpper() == chudeCreate.TenChuDe.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (nxb != null)
            {
                ModelState.AddModelError("", "Chu de already exists");
                return StatusCode(442, ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var chudeMap = _mapper.Map<ChuDe>(chudeCreate);

            chudeMap.Sach = _sachRepository.GetSachByMaSach(sachId);

            if (!_chuDeRepository.ChuDeCreate(chudeMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }
        [HttpPut("{chudeId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdatedChuDe(int chudeId, [FromBody] ChuDeDto chudeUpdate)
        {
            if (chudeUpdate == null)
                return BadRequest(ModelState);

            if (chudeId != chudeUpdate.MaChuDe)
                return BadRequest(ModelState);

            if (!_chuDeRepository.ChuDeExists(chudeId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var chudeMap = _mapper.Map<ChuDe>(chudeUpdate);

            if (!_chuDeRepository.ChuDeUpdate(chudeMap))
            {
                ModelState.AddModelError("", "Something went wrong updating chu de");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
        [HttpDelete("{chudeId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteChuDe(int chudeId)
        {
            if (!_chuDeRepository.ChuDeExists(chudeId))
            {
                return NotFound();
            }

            var chudeToDelete = _chuDeRepository.GetChuDeByMaCD(chudeId);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_chuDeRepository.ChuDeDelete(chudeToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting chu de");
            }

            return NoContent();
        }
    }
}
