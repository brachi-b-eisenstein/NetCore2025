
namespace MishnatYosef.Services
{
    public class DistributionStationService
    {
        static readonly List<Entities.DistibutionStation> _Stations = new List<Entities.DistibutionStation>();
        public List<Entities.DistibutionStation> GetService()
        {
            return _Stations;
        }
        public Entities.DistibutionStation GetByIdService(int id)
        {
            Entities.DistibutionStation station;
            station = _Stations.Find(x => x.Station == id);
            return station;
        }
        public bool PostService(Entities.DistibutionStation station)
        {
            _Stations.Add(station);
            if (_Stations.Find(x => x.Station == station.Station) != null)
                return true;
            return false;
        }
        public bool DeleteByIdService(int id)
        {
            if (_Stations == null) return false;
            Entities.DistibutionStation station = _Stations.Find(x => x.Station == id);
            if (station == null) return false;
            _Stations.Remove(station);
            return true;
        }
        public bool PutService(int id, Entities.DistibutionStation s)
        {
            Entities.DistibutionStation station = _Stations.Find(x => x.Station == id);
            if (station == null) return false;
            _Stations.Remove(station);
            _Stations.Add(s);
            return true;
        }
    }
}
