using GestiondesSalles.Dto.RoomDto;
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

        void Test();
        void Imane();
    }
}