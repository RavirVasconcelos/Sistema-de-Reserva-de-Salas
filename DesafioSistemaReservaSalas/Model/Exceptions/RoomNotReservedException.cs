namespace DesafioSistemaReservaSalas.DesafioSistemaReservaSalas.Model.Exceptions
{
    public class RoomNotReservedException : ApplicationException
    {
        public RoomNotReservedException(string message) : base(message)
        {
        }
    }
}
