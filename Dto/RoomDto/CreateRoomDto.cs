using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestiondesSalles.Dto.RoomDto
{
    public class CreateRoomDto
    {
        public string  Nom { get; set; }= string.Empty;
        public int Surface { get; set; }
        public int Maxpeople { get; set; }
        public string Image { get; set; }= string.Empty;
        public Guid FloorId { get; set; }
    }
}