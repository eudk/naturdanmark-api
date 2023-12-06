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
            Repo.Add(idcounter++, new Coordinates { DeviceID = 1, Longitude = 170, Latitude = 45 });

        }

        public Hashtable GetAll()
        {
            return new Hashtable(Repo);
        }

        public Coordinates? GetById( int id)
        {
            return (Coordinates)Repo[id];
        }

        public Coordinates Add(Coordinates cor)
        {
            cor.DeviceID = idcounter++;
            cor.Date = DateTime.Now;
            cor.ValidateAll();
            Repo.Add(cor.DeviceID, cor);
            return cor;
        }

        public Coordinates Update(int id, Coordinates newcor)
        {
            Coordinates? oldcor = GetById(id);
            if (oldcor != null) 
            {
                oldcor.Date =DateTime.Now;
                oldcor.Longitude = newcor.Longitude;
                oldcor.Longitude = newcor.Latitude;
                return newcor;
            }
            return null;

        }
    }
}
