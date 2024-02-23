using AutoMapper;
using BookStoreManagement.Dto;
using BookStoreManagement.Interfaces;
using BookStoreManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NhaXuatBanController : Controller
    {
        private readonly ISachRepository _sachRepository;
        private readonly INhaXuatBanRepository _nhaXuatBanRepository;
        private readonly IMapper _mapper;
        public NhaXuatBanController(ISachRepository sachRepository, INhaXuatBanRepository nhaXuatBanRepository, IMapper mapper)
        {
            _sachRepository = sachRepository;
            _nhaXuatBanRepository = nhaXuatBanRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetNXBs() {
            var nxb = _mapper.Map<List<NhaXuatBanDto>>(_nhaXuatBanRepository.GetNhaXuatBans());
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(nxb);
        }
        [HttpGet("{nxbId}")]
        [ProducesResponseType(200, Type = typeof(NhaXuatBan))]
        public IActionResult GetNXB(int nxbId)
        {
            if(!_nhaXuatBanRepository.NhaXUatBanExists(nxbId))
                return NotFound();
            var nxb = _mapper.Map<NhaXuatBanDto>(_nhaXuatBanRepository.GetNhaXuatBanByMaNXB(nxbId));
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(nxb);
        }
        [HttpGet("sach/{nxbId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<NhaXuatBan>))]
        [ProducesResponseType(400)]
        public IActionResult GetSachByMaNXB(int nxbId)
        {
            var saches = _mapper.Map<List<SachDto>>(_nhaXuatBanRepository.GetSachByNXB(nxbId));
            if (!ModelState.IsValid)
                return BadRequest();
            return Ok(saches);
        }
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateNXB([FromQuery] int sachId, [FromBody] NhaXuatBanDto nxbCreate)
        {
            if (nxbCreate == null)
                return BadRequest(ModelState);

            var nxb = _nhaXuatBanRepository.GetNhaXuatBans()
                .Where(c => c.TenNXB.Trim().ToUpper() == nxbCreate.TenNXB.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (nxb != null)
            {
                ModelState.AddModelError("", "Nxb already exists");
                return StatusCode(442, ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var nxbMap = _mapper.Map<NhaXuatBan>(nxbCreate);

            nxbMap.Sach = _sachRepository.GetSachByMaSach(sachId);

            if (!_nhaXuatBanRepository.NhaXuatBanCreate(nxbMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }
        [HttpPut("{nxbId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdatedNxb(int nxbId, [FromBody] NhaXuatBanDto nxbUpdate)
        {
            if (nxbUpdate == null)
                return BadRequest(ModelState);

            if (nxbId != nxbUpdate.MaNXB)
                return BadRequest(ModelState);

            if (!_nhaXuatBanRepository.NhaXUatBanExists(nxbId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var nxbMap = _mapper.Map<NhaXuatBan>(nxbUpdate);

            if (!_nhaXuatBanRepository.NhaXuatBanUpdate(nxbMap))
            {
                ModelState.AddModelError("", "Something went wrong updating nxb");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
        [HttpDelete("{nxbId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteNxb(int nxbId)
        {
            if (!_nhaXuatBanRepository.NhaXUatBanExists(nxbId))
            {
                return NotFound();
            }

            var nxbToDelete = _nhaXuatBanRepository.GetNhaXuatBanByMaNXB(nxbId);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_nhaXuatBanRepository.NhaXuatBanDelete(nxbToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting nxb");
            }

            return NoContent();
        }
    }
}
