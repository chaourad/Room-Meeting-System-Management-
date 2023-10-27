using System.Net;
using AutoMapper;
using GestiondesSalles.Data;
using GestiondesSalles.Dto.RoomDto;
using GestiondesSalles.ExceptionHandlerMidls.FloorException;
using GestiondesSalles.ExceptionHandlerMidls.RoomException;
using GestiondesSalles.modals;
using GestiondesSalles.Repository.IRepository;
using GestiondesSalles.Status;
using GestiondesSalles.Utils;
using Microsoft.EntityFrameworkCore;

namespace GestiondesSalles.Repository
{
    public class RoomRepository : IRoomRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public RoomRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public Room Create(CreateRoomDto createRoom)
        {
            Floor? floor = _context.Floor
            .Where(f => f.Id == createRoom.FloorId)
            .FirstOrDefault();
            if (floor is null)
                throw new FloorNotFoundException(ErrorMessages.FLoorNotFound, ((int)HttpStatusCode.NotFound));

            var newRoom = _mapper.Map<CreateRoomDto, Room>(createRoom);
            _context.Rooms.Add(newRoom);
            _context.SaveChanges();
            return newRoom;
        }

        public ResponseRoomDto GetRoomById(Guid id)
        {
            Room? room = _context.Rooms.Where(r => r.Id == id).FirstOrDefault();
            if (room is null)
                throw new RoomNotFoundException(ErrorMessages.RoomNotFound, (int)HttpStatusCode.NotFound);

            return _mapper.Map<Room, ResponseRoomDto>(room);

        }

        public IEnumerable<ResponseRoomDto> GetAll()
         => _context.Rooms
         .Include(r => r.Floor)
         .Select(room => _mapper.Map<Room, ResponseRoomDto>(room));

        public void Delete(Guid id)
        {

            Room? room = _context.Rooms.Find(id);
            if (room is null)
                throw new RoomNotFoundException(ErrorMessages.RoomNotFound, (int)HttpStatusCode.NotFound);
            _context.Rooms.Remove(room);
            int res = _context.SaveChanges();
            if (res == 0)
                throw new RoomDeleteException(ErrorMessages.RoomDeleteException, (int)HttpStatusCode.BadRequest);
        }

        public ResponseRoomDto Update(Guid id, UpdateRoomDto roomDto)
        {

            Room? room = _context.Rooms.Find(id);
            if (room is null)
                throw new RoomNotFoundException(ErrorMessages.RoomNotFound, (int)HttpStatusCode.NotFound);

            if (roomDto is null)
                throw new RoomNotFoundException(ErrorMessages.RommDtoNotFound, (int)HttpStatusCode.NotFound);
            room.Maxpeople = roomDto.Maxpeople;
            room.Surface = roomDto.Surface;
            room.FloorId = roomDto.FloorId;
            room.Image = roomDto.Image;
            room.Nom = roomDto.Nom;
            _context.Rooms.Update(room);
            _context.SaveChanges();
            return _mapper.Map<Room, ResponseRoomDto>(room);


        }

        public IEnumerable<ResponseRoomDto> SearchRoomByFloor(Guid floodId)
        {
            return
                _context.Rooms.Where(room => room.FloorId == floodId)
                .Select(room => _mapper.Map<Room, ResponseRoomDto>(room));
        }


        public IEnumerable<ResponseRoomDto> GetFreeRooms()
        {
          return  _context.Rooms
          .Where(r => r.Status == RoomStatus.FREE.ToString())
          .Select(room => _mapper.Map<Room, ResponseRoomDto>(room));
             

        public IEnumerable<ResponseRoomDto> GetFreeRoomsByFloor(Guid floorId)
        {
            Floor? floor = _context.Floor.Find(floorId);
            if (floor is null)
                throw new FloorNotFoundException(ErrorMessages.FLoorNotFound, (int)HttpStatusCode.NotFound);

            return _context.Rooms
            .Where(room => room.FloorId == floorId && room.Status == RoomStatus.FREE.ToString())
            .Select(room => _mapper.Map<Room, ResponseRoomDto>(room));

        }
    }
}