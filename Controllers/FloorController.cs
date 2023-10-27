
using GestiondesSalles.Data;
using GestiondesSalles.Dto.FloorDto;
using GestiondesSalles.modals;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestiondesSalles.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FloorController : ControllerBase
    {
        private readonly AppDbContext _context;

        public FloorController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Floor>> Create(CreateFloorDto createFloor)
        {
            var floor = new Floor
            {
                Nom = createFloor.Nom,
            };

            _context.Floor.Add(floor);
            await _context.SaveChangesAsync();
            return Ok(floor);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Floor>> Get() => _context.Floor;

        [HttpGet("id/{id:Guid}")]
        public async Task<ActionResult<Floor>> GetById(Guid id)
        {
            Floor? floor = await _context.Floor.Where(c => c.Id == id).FirstOrDefaultAsync();
            if (floor == null)
                return NotFound("Floor nor found");

            return Ok(floor);
        }

        [HttpPut("update/{id:Guid}")]
        public async Task<ActionResult<Floor>> Update(Guid id, UpdateFloorDto floorDto)
        {
            if (floorDto == null)
                return NotFound("floor vide");
            var floor = await _context.Floor.Where(c => c.Id == id).FirstOrDefaultAsync();

            if (floor == null)
                return NotFound("Floor not found");

            floor.Nom = floorDto.Nom;
            _context.Floor.Update(floor);
            await _context.SaveChangesAsync();

            return Ok(floor);
        }
        [HttpGet("search/{nom}")]
        public ActionResult<Floor> Get(string nom)
        {
            Floor? floor = _context.Floor.SingleOrDefault(f => f.Nom == nom);
            if (floor == null)
            {
                return NotFound("floor non trouvé");
            }
            return Ok(floor);
        }

    }
}