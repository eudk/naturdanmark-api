using System.Collections;
using Azure.Core;
using naturdanmark_api.Models;

namespace naturdanmark_api.Repositories
{
    public class CoordinateRepo
    {
        private readonly Hashtable Repo = new();

        private int idcounter = 1;

        public CoordinateRepo()
        {
            Repo.Add(1, new Coordinates { DeviceID = 1, Longitude = 170, Latitude = 45 });

        }

        public Hashtable GetAll()
        {
            return new Hashtable(Repo);
        }

        public Coordinates GetById( int id)
        {
            return (Coordinates)Repo[id];
        }

        public Coordinates Add(Coordinates cor)
        {
            cor.DeviceID = idcounter++;
            Repo.Add(cor.DeviceID, cor);
            return cor;
        }

        public Coordinates Update(int id, Coordinates cor)
        {
            return cor;
        }
    }
}
