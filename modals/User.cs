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
        public string? Nom { get; set; } = string.Empty;
        public string? Prenom { get; set; } = string.Empty;
        public string  Username { get; set; }= string.Empty;
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string?  Role { get; set; }= string.Empty;
        [JsonIgnore]
        public List<Reservation> Reservations { get; set; } = new();
    }
}