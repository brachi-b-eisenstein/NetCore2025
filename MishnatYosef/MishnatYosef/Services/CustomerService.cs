using MishnatYosef.Entities;

namespace MishnatYosef.Services
{
    public class CustomerService
    {
        public List<Entities.Customer> GetService()
        {
            Console.WriteLine(Data.DataContextManager.Lists._CustomerList.Count());
            return Data.DataContextManager.Lists._CustomerList;
        }
        public Entities.Customer GetByIdService(int id)
        {
            Entities.Customer customer;
            customer = Data.DataContextManager.Lists._CustomerList.Find(x => x.Id == id);
            return customer;
        }
        public bool AddCustomer(Entities.Customer customer)
        {
            Data.DataContextManager.Lists._CustomerList.Add(customer);
            if(Data.DataContextManager.Lists._CustomerList.Find(x => x.Id == customer.Id)!=null)
                return true;
            return false;
        }
        public bool DeleteByIdService(int id)
        {
            if(Data.DataContextManager.Lists._CustomerList == null) return false;
            Entities.Customer customer = Data.DataContextManager.Lists._CustomerList.Find(x => x.Id == id);
            if(customer==null) return false;
            Data.DataContextManager.Lists._CustomerList.Remove(customer);
            return true;
        }
        public bool UpdateCustomer(int id,Entities.Customer c)
        {
            int customer = Data.DataContextManager.Lists._CustomerList.FindIndex(x => x.Id == id);
            if (customer == null) return false;             
            Data.DataContextManager.Lists._CustomerList[customer]=c;
            return true;
        }

    }
}
