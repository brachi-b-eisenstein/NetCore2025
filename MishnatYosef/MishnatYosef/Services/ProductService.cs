namespace MishnatYosef.Services
{
    public class ProductService
    {
        static readonly List<Entities.Product> _Products = new List<Entities.Product>();
        public List<Entities.Product> GetService()
        {
            return _Products;
        }
        public Entities.Product GetByIdService(int id)
        {
            Entities.Product product;
            product = _Products.Find(x => x.Id == id);
            return product;
        }
        public bool PostService(Entities.Product product)
        {
            _Products.Add(product);
            if (_Products.Find(x => x.Id == product.Id) != null)
                return true;
            return false;
        }
        public bool DeleteByIdService(int id)
        {
            if (_Products == null) return false;
            Entities.Product product = _Products.Find(x => x.Id == id);
            if (product == null) return false;
            _Products.Remove(product);
            return true;
        }
        public bool PutService(int id, Entities.Product p)
        {
            Entities.Product product = _Products.Find(x => x.Id == id);
            if (product == null) return false;
            _Products.Remove(product);
            _Products.Add(p);
            return true;
        }
    }
}
