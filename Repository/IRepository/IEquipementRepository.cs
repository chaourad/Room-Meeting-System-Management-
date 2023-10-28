using GestiondesSalles.Dto.EquipementDto;
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


    }
}