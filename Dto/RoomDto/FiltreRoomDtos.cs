using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestiondesSalles.modals;
using GestiondesSalles.Status;

namespace GestiondesSalles.Dto.RoomDto
{
    public class FiltreRoomDtos
    {
          public string Nom { get; set; } = string.Empty;
        public int Surface { get; set; }

        public string Status { get; set; } = RoomStatus.FREE.ToString();
        public int Maxpeople { get; set; }
        public string Image { get; set; } = string.Empty;
        public Guid FloorId { get; set; }
        public Floor Floor { get; set; }
        
        public List<Equipement>? Equipements { get; set; }
      
        public List<Reservation>? Reservations { get; set; }
    }
}