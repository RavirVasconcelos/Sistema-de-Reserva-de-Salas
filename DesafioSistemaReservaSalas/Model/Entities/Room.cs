namespace DesafioSistemaReservaSalas.DesafioSistemaReservaSalas.Model.Entities
{
    public class Room
    {
        public string Name { get; set; }
        public int Capacity { get; set; }
        public bool IsAvailable { get; set; }

        public Room()
        {
        }

        public Room(string name, int capacity, bool isAvailable)
        {
            Name = name;
            Capacity = capacity;
            IsAvailable = isAvailable;
        }

        public override string ToString()
        {
            return $"Room: {Name}, Capacity: {Capacity}, Available: {IsAvailable}";
        }
    }
}
