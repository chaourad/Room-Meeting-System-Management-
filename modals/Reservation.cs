using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GestiondesSalles.modals
{
    public class Reservation
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime Date_debut { get; set; }
        public DateTime Date_fin { get; set; }
        public Guid RommId { get; set; }
        public Room? Room { get; set; }
        [JsonIgnore]
        public List<User>? Users { get; set; }
    }
}