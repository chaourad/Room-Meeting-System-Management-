using GestiondesSalles.Dto.EquipementDto;
using GestiondesSalles.Dto.RoomDto;
using GestiondesSalles.Filter;
using GestiondesSalles.modals;

namespace GestiondesSalles.IRepository
{
    public interface IEquipementRepository
    {
      Equipement CreateA(CreateEquipementDto equipementDto);
      void Delete(Guid id);
      IEnumerable<ResponseEquipementDto> GetAll();
       ResponseEquipementDto GetById(Guid id);
      ResponseEquipementDto Update(UpdateEquipementDto updateEquipementDto, Guid id);

      IEnumerable<ResponseEquipementDto> GetEquipementByRommId(Guid roomId);
    }
}