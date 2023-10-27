namespace GestiondesSalles.Dto.RoomDto
{
    public class ResponseRoomDto
    {
        public Guid Id { get; set; }
         public string  Nom { get; set; }= string.Empty;
        public int Surface { get; set; }
        public int Maxpeople { get; set; }
        public string Image { get; set; }= string.Empty;
        public Guid FloorId { get; set; }
    }
}