using System.Collections;
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

        public void GetAll()
        {

        }

        public void GetById()
        {

        }

        public void Add()
        {

        }

        public void Update()
        {

        }
    }
}
