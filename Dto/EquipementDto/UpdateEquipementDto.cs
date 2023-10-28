namespace GestiondesSalles.Dto.EquipementDto
{
    public class UpdateEquipementDto
    {
          public string? Nom { get; set; }= string.Empty;
        public string? Image { get; set; }= string.Empty;
        public int Quantity { get; set; }
        public Guid RommId { get; set; }
    }
}