namespace MishnatYosef.Services
{
    public class OrderService
    {
        static readonly List<Entities.Order> _Orders = new List<Entities.Order>();
        public List<Entities.Order> GetService()
        {
            return _Orders;
        }
        public Entities.Order GetByIdService(int id)
        {
            Entities.Order order;
            order = _Orders.Find(x => x.Id == id);
            return order;
        }
        public bool PostService(Entities.Order order)
        {
            _Orders.Add(order);
            if (_Orders.Find(x => x.Id ==order.Id ) != null)
                return true;
            return false;
        }
        public bool DeleteByIdService(int id)
        {
            if (_Orders == null) return false;
            Entities.Order order = _Orders.Find(x => x.Id == id);
            if (order == null) return false;
            _Orders.Remove(order);
            return true;
        }
        public bool PutService(int id, Entities.Order o)
        {
            Entities.Order order = _Orders.Find(x => x.Id == id);
            if (order == null) return false;
            _Orders.Remove(order);
            _Orders.Add(o);
            return true;
        }
    }
}
