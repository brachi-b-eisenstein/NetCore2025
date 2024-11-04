namespace MishnatYosef.Services
{
    public class OrderedProductService
    {
        static readonly List<Entities.OrderedProduct> _OrderedProducts = new List<Entities.OrderedProduct>();
        public List<Entities.OrderedProduct> GetService()
        {
            return _OrderedProducts;
        }
        public Entities.OrderedProduct GetByIdService(int id)
        {
            Entities.OrderedProduct orderedProduct;
            orderedProduct = _OrderedProducts.Find(x => x.Id == id);
            return orderedProduct;
        }
        public bool PostService(Entities.OrderedProduct orderedProduct)
        {
            _OrderedProducts.Add(orderedProduct);
            if (_OrderedProducts.Find(x => x.Id == orderedProduct.Id) != null)
                return true;
            return false;
        }
        public bool DeleteByIdService(int id)
        {
            if (_OrderedProducts == null) return false;
            Entities.OrderedProduct orderedProduct = _OrderedProducts.Find(x => x.Id == id);
            if (orderedProduct == null) return false;
            _OrderedProducts.Remove(orderedProduct);
            return true;
        }
        public bool PutService(int id, Entities.OrderedProduct o)
        {
            Entities.OrderedProduct orderedProduct = _OrderedProducts.Find(x => x.Id == id);
            if (orderedProduct == null) return false;
            _OrderedProducts.Remove(orderedProduct);
            _OrderedProducts.Add(o);
            return true;
        }
    }
}
