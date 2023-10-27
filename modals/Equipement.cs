using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GestiondesSalles.modals
{
    public class Equipement
    {
        [Key]
        public Guid Id { get; set; }
        public string? Nom { get; set; }
        public string? Image { get; set; }
        public int Quantity { get; set; }
        public Guid RommId { get; set; }
        public Room? Room { get; set; }
    }
}