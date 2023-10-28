using System.Net;
using AutoMapper;
using GestiondesSalles.Data;
using GestiondesSalles.Dto.EquipementDto;
using GestiondesSalles.ExceptionHandlerMidls.EquipementException;
using GestiondesSalles.ExceptionHandlerMidls.FloorException;
using GestiondesSalles.ExceptionHandlerMidls.RoomException;
using GestiondesSalles.IRepository;
using GestiondesSalles.modals;
using GestiondesSalles.Utils;
using Microsoft.EntityFrameworkCore;

namespace GestiondesSalles.Repository
{
    public class EquipementRepository : IEquipementRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public EquipementRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Equipement CreateA(CreateEquipementDto equipementDto)
        {
            Room? rom = _context.Rooms.Where(f => f.Id == equipementDto.RommId).FirstOrDefault();
            if (rom is null)
                throw new RoomNotFoundException(ErrorMessages.RoomNotFound, (int)HttpStatusCode.NotFound);

            var newEquipment = _mapper.Map<CreateEquipementDto, Equipement>(equipementDto);
            _context.Equipements.Add(newEquipment);
            _context.SaveChanges();

            return newEquipment;
        }
        public void Delete(Guid id)
        {
            Equipement? equipement = _context.Equipements.Find(id);
            if (equipement is null)
            {
                throw new EquipementNotFoundException(ErrorMessages.EquipementNotFound, (int)HttpStatusCode.NotFound);
            }
            _context.Equipements.Remove(equipement);
            int result = _context.SaveChanges();
            if (result == 0)
                throw new EquipementDeleteException(ErrorMessages.EquipementDeleteException, (int)HttpStatusCode.BadRequest);

        }
        public IEnumerable<ResponseEquipementDto> GetAll()
        {
            return _context.Equipements.Include(rm => rm.Room)
            .Select(equip => _mapper.Map<Equipement, ResponseEquipementDto>(equip));
        }

        public ResponseEquipementDto GetById(Guid id)
        {
            Equipement? equipement = _context.Equipements.Where(e => e.Id == id).FirstOrDefault();
            if (equipement is null)
                throw new EquipementNotFoundException(ErrorMessages.EquipementNotFound, (int)HttpStatusCode.NotFound);
            return _mapper.Map<Equipement, ResponseEquipementDto>(equipement);
        }
        public ResponseEquipementDto Update(UpdateEquipementDto updateEquipementDto, Guid id)
        {
            if (updateEquipementDto is null)
                throw new EquipementNotFoundException(ErrorMessages.EquipementNotFound, (int)HttpStatusCode.NotFound);

            Equipement? equipement = _context.Equipements.Find(id);
            if (equipement is null)
                throw new EquipementNotFoundException(ErrorMessages.EquipementNotFound, (int)HttpStatusCode.NotFound);
            
            equipement.Nom = updateEquipementDto.Nom;
            equipement.Image = updateEquipementDto.Image;
            equipement.Quantity = updateEquipementDto.Quantity;
            equipement.RommId = updateEquipementDto.RommId;
            _context.Equipements.Update(equipement);
            _context.SaveChanges();
            return _mapper.Map<Equipement, ResponseEquipementDto>(equipement);
            }

    }
}