namespace DesafioSistemaReservaSalas.DesafioSistemaReservaSalas.Model.Repository
{
    public class InfoRepository<T>
    {

        private List<T> _items = new List<T>();

        public void AddItem(T item)
        {
            _items.Add(item);
        }
        public void RemoveItem(T item)
        {
            if (_items.Contains(item))
            {
                _items.Remove(item);
            }
        }
        public List<T> GetAllItems()
        {
            return _items;
        }
    }
}
