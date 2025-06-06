using DesafioSistemaReservaSalas.DesafioSistemaReservaSalas.Model.Entities;
using DesafioSistemaReservaSalas.DesafioSistemaReservaSalas.Model.Exceptions;

namespace DesafioSistemaReservaSalas.DesafioSistemaReservaSalas.Model.Services
{
    public class RoomReservationManager
    {

        public Dictionary<Room, Teacher> reservations = new Dictionary<Room, Teacher>();

        public void ReserveRoom(Room room, Teacher teacher)
        {
            if (room == null || teacher == null)
            {
                throw new ArgumentNullException("Room or Teacher cannot be null.");
            }
            if (reservations.ContainsKey(room))
            {
                throw new RoomNotAvailableException("The room is already reserved by another teacher.");
            }

            reservations[room] = teacher;
            teacher.ReserverdRooms.Add(room);
        }

        public void CancelReservation(Room room, Teacher teacher)
        {
            if (room == null || teacher == null)
            {
                throw new ArgumentNullException("Room or Teacher cannot be null.");
            }
            if (!reservations.ContainsKey(room) || reservations[room] != teacher)
            {
                throw new RoomNotReservedException("The room is not reserved by this teacher.");
            }

            reservations.Remove(room);
            teacher.ReserverdRooms.Remove(room);
        }

        public List<Room> GetReservedRooms(Teacher teacher)
        {
            if(teacher == null)
            {
                throw new ArgumentNullException("Teacher cannot be null.");
            }

            if (!teacher.ReserverdRooms.Any())
            {
                throw new NoReservedRoomsException("This teacher has no reserved rooms.");
            }

            return teacher.ReserverdRooms;
        }
    }
}
