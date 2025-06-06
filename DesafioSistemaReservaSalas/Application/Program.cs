using DesafioSistemaReservaSalas.DesafioSistemaReservaSalas.Model.Entities;
using DesafioSistemaReservaSalas.DesafioSistemaReservaSalas.Model.Services;
using DesafioSistemaReservaSalas.DesafioSistemaReservaSalas.Model.Exceptions;
using DesafioSistemaReservaSalas.DesafioSistemaReservaSalas.Model.Repository;


namespace DesafioSistemaReservaSalas.DesafioSistemaReservaSalas.Application
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Teacher teacher = new Teacher("John Doe", 1);
            InfoRepository<Room> roomRepository = new InfoRepository<Room>();
            roomRepository.AddItem(new Room("Sala 101", 1, true));
            roomRepository.AddItem(new Room("Sala 102", 2, false));
            roomRepository.AddItem(new Room("Sala 103", 3, false));
            roomRepository.AddItem(new Room("Sala 104", 4, true));

            Console.WriteLine($"Bem vindo {teacher.Name}");
            int option;
            do
            {
                Console.WriteLine("Escolha dentre algumas destas opções:");
                Console.WriteLine("1. Reservar uma sala");
                Console.WriteLine("2. Cancelar uma reserva");
                Console.WriteLine("3. Listar salas reservadas");
                Console.WriteLine("4. Sair");

                Console.Write("Opção: ");
                option = int.Parse(Console.ReadLine());

                RoomReservationManager roomReservationManager = new RoomReservationManager();

                switch (option)
                {
                    case 1:
                        Console.WriteLine("Salas disponiveis");
                        foreach (var room in roomRepository.GetAllItems())
                        {
                            if (room.IsAvailable)
                            {
                                Console.WriteLine(room);
                            }
                        }

                        Console.Write("Digite o nome da sala que deseja reservar: ");
                        string roomName = Console.ReadLine();
                        Room selectedRoom = roomRepository.GetAllItems()
                            .FirstOrDefault(r => r.Name.Equals(roomName,
                            StringComparison.OrdinalIgnoreCase));

                        if (selectedRoom == null || !selectedRoom.IsAvailable)
                        {
                            Console.WriteLine("Sala não encontrada ou não disponível.");
                        }
                        else
                        {
                            try
                            {
                                roomReservationManager.ReserveRoom(selectedRoom, teacher);
                                Console.WriteLine($"Sala {selectedRoom.Name} reservada com sucesso!");
                            }
                            catch (RoomNotAvailableException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }

                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case 2:
                        Console.WriteLine("Salas reservadas:");
                        foreach (var room in teacher.ReserverdRooms)
                        {
                            Console.WriteLine(room);
                        }
                        Console.Write("Digite o nome da sala que deseja cancelar a reserva: ");
                        string cancelRoomName = Console.ReadLine();
                        Room cancelRoom = teacher.ReserverdRooms
                            .FirstOrDefault(r => r.Name.Equals(cancelRoomName,
                            StringComparison.OrdinalIgnoreCase));
                        if (cancelRoom == null)
                        {
                            Console.WriteLine("Sala não encontrada entre suas reservas.");
                        }
                        else
                        {
                            try
                            {
                                roomReservationManager.CancelReservation(cancelRoom, teacher);
                                Console.WriteLine($"Reserva da sala {cancelRoom.Name} cancelada com sucesso!");
                            }
                            catch (RoomNotReservedException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }

                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case 3:
                        Console.WriteLine("Salas:");
                        try
                        {
                            List<Room> reservedRooms = roomReservationManager.GetReservedRooms(teacher);
                            foreach (var reservedRoom in reservedRooms)
                            {
                                Console.WriteLine(reservedRoom);
                            }
                        }
                        catch (NoReservedRoomsException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }

                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case 4:
                        Console.WriteLine("Saindo do sistema...");
                        break;

                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");

                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            }
            while (option != 4);
        }
    }
}
