using GestiondesSalles.Dto.EquipementDto;
using GestiondesSalles.IRepository;
using GestiondesSalles.modals;
using Microsoft.AspNetCore.Mvc;

namespace GestiondesSalles.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EquipementController : ControllerBase
    {
        private readonly IEquipementRepository _repository;
        public EquipementController(IEquipementRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("Create")]
        public ActionResult<Equipement> Create(CreateEquipementDto equipementDto)
         => Ok(_repository.CreateA(equipementDto));

        [HttpDelete("Delete/{id:Guid}")]
        public ActionResult Delete(Guid id)
        {
            _repository.Delete(id);
            return Ok();
        }

         [HttpGet]
        public ActionResult<IEnumerable<ResponseEquipementDto>> GetAll()
        => Ok(_repository.GetAll());

        [HttpGet("id/{id:Guid}")]
        public ActionResult<ResponseEquipementDto> GetById(Guid id)
        =>Ok(_repository.GetById(id));

        [HttpPut("Update/{id:Guid}")]
        public ActionResult<ResponseEquipementDto> Update(UpdateEquipementDto updateEquipementDto, Guid id)
        => Ok(_repository.Update(updateEquipementDto,id));
    }
}