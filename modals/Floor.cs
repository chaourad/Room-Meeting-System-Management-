using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GestiondesSalles.modals
{
    public class Floor
    {
        [Key]
        public Guid Id { get; set; }
        public string  Nom { get; set; }= string.Empty;
        [JsonIgnore]
        public List<Room>? Rooms { get; set; } = new();
    }
}