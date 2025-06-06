namespace DesafioSistemaReservaSalas.DesafioSistemaReservaSalas.Model.Entities
{
    public class Teacher
    {
        public string Name { get; set; }
        public int TeacherId { get; set; }

        public List<Room> ReserverdRooms { get; set; } = new List<Room>();

        public Teacher()
        {
        }

        public Teacher(string name, int teacherId)
        {
            Name = name;
            TeacherId = teacherId;
        }
    }
}
