using AutoMapper;
using GestiondesSalles.Dto.EquipementDto;
using GestiondesSalles.Dto.FloorDto;
using GestiondesSalles.Dto.RoomDto;
using GestiondesSalles.Dto.UserDto;
using GestiondesSalles.modals;

namespace GestiondesSalles.MapperProfile
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile(){
            CreateMap<CreateRoomDto,Room>();
            CreateMap<CreateFloorDto,Floor>();
            CreateMap<Room,ResponseRoomDto>();
            CreateMap<CreateEquipementDto , Equipement>();
            CreateMap<Equipement, ResponseEquipementDto>();
            CreateMap<UserDto,User>();
            CreateMap<User , ResponseUserDto>();
            
        }
    }
}