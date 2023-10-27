using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using GestiondesSalles.Status;

namespace GestiondesSalles.modals
{
    public class Room
    {
        [Key]
        public Guid Id { get; set; }
        public string Nom { get; set; } = string.Empty;
        public int Surface { get; set; }

        public string Status { get; set; } = RoomStatus.FREE.ToString();
        public int Maxpeople { get; set; }
        public string Image { get; set; } = string.Empty;
        public Guid FloorId { get; set; }
        public Floor? Floor { get; set; }
        [JsonIgnore]
        public List<Equipement>? Equipements { get; set; }
        [JsonIgnore]
        public List<Reservation>? Reservations { get; set; }
    }
}