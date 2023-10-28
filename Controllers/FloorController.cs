
using System.Net;
using GestiondesSalles.Data;
using GestiondesSalles.Dto.FloorDto;
using GestiondesSalles.ExceptionHandlerMidls.FloorException;
using GestiondesSalles.modals;
using GestiondesSalles.Utils;
using Microsoft.AspNetCore.Authorization;
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


        [HttpPost, Authorize(Roles ="Admin")]
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

        [HttpGet("Id/{id:Guid}")]
        public async Task<ActionResult<Floor>> GetById(Guid id)
        {
            Floor? floor = await _context.Floor.Where(c => c.Id == id).FirstOrDefaultAsync();
            if (floor == null)
                return NotFound("Floor nor found");
            return Ok(floor);
        }
       
        [HttpDelete("Delete/{id:Guid}"),Authorize(Roles ="Admin")]
        public void Delete(Guid id)
        {
            Floor? floor = _context.Floor.Find(id);
            if(floor is null)
                throw new FloorNotFoundException(ErrorMessages.FLoorNotFound,(int) HttpStatusCode.NotFound);
            
            _context.Floor.Remove(floor);
           int res = _context.SaveChanges();
             if (res == 0)
                throw new FloorDeleteException(ErrorMessages.RoomDeleteException, (int)HttpStatusCode.BadRequest);
        }

        [HttpPut("Update/{id:Guid}"), Authorize(Roles ="Admin")]
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
        [HttpGet("Search/{nom}")]
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