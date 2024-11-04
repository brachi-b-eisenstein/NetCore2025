namespace MishnatYosef.Services
{
    public class ProductOnSellService
    {
        static readonly List<Entities.ProductOnSell> _ProductsOnSell = new List<Entities.ProductOnSell>();
        public List<Entities.ProductOnSell> GetService()
        {
            return _ProductsOnSell;
        }
        public Entities.ProductOnSell GetByIdService(int id)
        {
            Entities.ProductOnSell product;
            product = _ProductsOnSell.Find(x => x.Id == id);
            return product;
        }
        public bool PostService(Entities.ProductOnSell product)
        {
            _ProductsOnSell.Add(product);
            if (_ProductsOnSell.Find(x => x.Id == product.Id) != null)
                return true;
            return false;
        }
        public bool DeleteByIdService(int id)
        {
            if (_ProductsOnSell == null) return false;
            Entities.ProductOnSell product = _ProductsOnSell.Find(x => x.Id == id);
            if (product == null) return false;
            _ProductsOnSell.Remove(product);
            return true;
        }
        public bool PutService(int id, Entities.ProductOnSell p)
        {
            Entities.ProductOnSell product = _ProductsOnSell.Find(x => x.Id == id);
            if (product == null) return false;
            _ProductsOnSell.Remove(product);
            _ProductsOnSell.Add(p);
            return true;
        }
    }
}
