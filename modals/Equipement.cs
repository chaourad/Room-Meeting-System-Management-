using System.ComponentModel.DataAnnotations;

namespace GestiondesSalles.modals
{
    public class Equipement
    {
        [Key]
        public Guid Id { get; set; }
        public string? Nom { get; set; }= string.Empty;
        public string? Image { get; set; }= string.Empty;
        public int Quantity { get; set; }
        public Guid RommId { get; set; }
        public Room? Room { get; set; }
    }
}