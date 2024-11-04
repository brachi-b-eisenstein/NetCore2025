using MishnatYosef.Entities;

namespace MishnatYosef.Services
{
    public class CustomerService
    {
        static readonly List<Entities.Customer> _CustomersList= new List<Entities.Customer>();
        public List<Entities.Customer> GetService()
        {
            return _CustomersList;
        }
        public Entities.Customer GetByIdService(int id)
        {
            Entities.Customer customer = null;
            customer = _CustomersList.Find(x => x.Id == id);
            return customer;
        }
        public bool PostService(Entities.Customer customer)
        {
            _CustomersList.Add(customer);
            if(_CustomersList.Find(x => x.Id == customer.Id)!=null)
                return true;
            return false;
        }
        public bool DeleteByIdService(int id)
        {
            if(_CustomersList==null) return false;
            Entities.Customer customer = _CustomersList.Find(x => x.Id == id);
            if(customer==null) return false;
            _CustomersList.Remove(customer);
            return true;
        }
        public bool PutService(int id,Entities.Customer c)
        {
            Entities.Customer customer = _CustomersList.Find(x => x.Id == id);
            if (customer == null) return false;
            _CustomersList.Remove(customer);
            _CustomersList.Add(c);
            return true;
        }

    }
}
