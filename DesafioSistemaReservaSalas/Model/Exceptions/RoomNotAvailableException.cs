namespace DesafioSistemaReservaSalas.DesafioSistemaReservaSalas.Model.Exceptions
{
    public class RoomNotAvailableException : ApplicationException
    {
        public RoomNotAvailableException(string message) : base(message)
        {
        }
    }
}
