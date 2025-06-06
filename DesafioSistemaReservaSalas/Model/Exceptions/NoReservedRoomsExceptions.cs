namespace DesafioSistemaReservaSalas.DesafioSistemaReservaSalas.Model.Exceptions
{
    public class NoReservedRoomsException : ApplicationException
    {
        public NoReservedRoomsException(string message) : base(message)
        {
        }
    }
}
