using GestiondesSalles.Dto.RoomDto;
using GestiondesSalles.modals;
using GestiondesSalles.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GestiondesSalles.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomController : ControllerBase
    {
        private readonly IRoomRepository _roomRepository;
        public RoomController(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }
        [HttpPost("Create")]
        public ActionResult<Room> Create(CreateRoomDto roomDto)
         => Ok(_roomRepository.Create(roomDto));

        [HttpGet]
        public ActionResult<IEnumerable<ResponseRoomDto>> GetAll()
        => Ok(_roomRepository.GetAll());

        [HttpDelete("Delete/{id:Guid}")]
        public ActionResult Delete(Guid id)
        {
            _roomRepository.Delete(id);
            return Ok();
        }
        [HttpPut("Update/{id:Guid}")]
        public ActionResult<ResponseRoomDto> Update(Guid id, UpdateRoomDto updateRoomDto) => Ok(_roomRepository.Update(id, updateRoomDto));

        [HttpGet("SearchRoomByFloor/{floorId:Guid}")]
        public ActionResult<IEnumerable<ResponseRoomDto>> SearchRoomByFloor(Guid floorId)

         => Ok(_roomRepository.SearchRoomByFloor(floorId));

        [HttpGet("GetFreeRoomsByFloor/{floorId:Guid}")]
        public ActionResult<IEnumerable<ResponseRoomDto>> GetFreeRoomsByFloor(Guid floorId)
        => Ok(_roomRepository.GetFreeRoomsByFloor(floorId));

        [HttpGet("GetFreeRooms")]

        public ActionResult<IEnumerable<ResponseRoomDto>> GetFreeRooms() =>Ok(_roomRepository.GetFreeRooms());

       

    }
}