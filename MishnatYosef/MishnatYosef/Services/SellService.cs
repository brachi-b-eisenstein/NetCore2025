
namespace MishnatYosef.Services
{
    public class SellService
    {
        static readonly List<Entities.Sell> _Sells = new List<Entities.Sell>();
        public List<Entities.Sell> GetService()
        {
            return _Sells;
        }
        public Entities.Sell GetByIdService(int id)
        {
            Entities.Sell sell;
            sell = _Sells.Find(x => x.Id == id);
            return sell;
        }
        public bool PostService(Entities.Sell sell)
        {
            _Sells.Add(sell);
            if (_Sells.Find(x => x.Id == sell.Id) != null)
                return true;
            return false;
        }
        public bool DeleteByIdService(int id)
        {
            if (_Sells == null) return false;
            Entities.Sell sell = _Sells.Find(x => x.Id == id);
            if (sell == null) return false;
            _Sells.Remove(sell);
            return true;
        }
        public bool PutService(int id, Entities.Sell s)
        {
            Entities.Sell sell = _Sells.Find(x => x.Id == id);
            if (sell == null) return false;
            _Sells.Remove(sell);
            _Sells.Add(s);
            return true;
        }
    }
}
