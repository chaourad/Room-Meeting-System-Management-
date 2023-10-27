using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GestiondesSalles.modals
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        public string  username { get; set; }= string.Empty;
        public string password { get; set; }= string.Empty;
        public string  role { get; set; }= string.Empty;
        [JsonIgnore]
        public List<Reservation> Reservations { get; set; } = new();
    }
}