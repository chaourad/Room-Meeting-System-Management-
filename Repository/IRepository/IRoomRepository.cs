using GestiondesSalles.Dto.EquipementDto;
using GestiondesSalles.Dto.RoomDto;
using GestiondesSalles.Filter;
using GestiondesSalles.modals;

namespace GestiondesSalles.Repository.IRepository
{
    public interface IRoomRepository
    {
        Room Create(CreateRoomDto createRoom);
        IEnumerable<ResponseRoomDto> GetAll();
        ResponseRoomDto GetRoomById(Guid id);
        void Delete(Guid id);
        ResponseRoomDto Update(Guid id, UpdateRoomDto roomDto);
        IEnumerable<ResponseRoomDto> SearchRoomByFloor(Guid floodId);
        IEnumerable<ResponseRoomDto> GetFreeRoomsByFloor(Guid floorId);
        IEnumerable<ResponseRoomDto> GetFreeRooms();
//        IEnumerable<Room> FilterEquipemnt(FilterRoom filter);

    }
}