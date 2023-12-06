using Microsoft.VisualStudio.TestTools.UnitTesting;
using naturdanmark_api.Repositories;
using naturdanmark_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace naturdanmark_apiTests.Repositories
{
    [TestClass()]
    public class CoordinateRepoTests
    {

        [TestMethod()]
        public void GetByIdTest()
        {
            CoordinateRepo repo = new CoordinateRepo();
            Assert.AreEqual((Coordinates)repo.GetAll()[1], repo.GetById(1));
            Assert.IsNull(repo.GetById(-1));
        }

        [TestMethod()]
        public void AddTest()
        {
            CoordinateRepo repo = new CoordinateRepo();
            int before = repo.GetAll().Count;
            repo.Add(new Coordinates { DeviceID = 2, Latitude = 45, Longitude = 45, Date = DateTime.Now });
            Assert.AreEqual(before + 1, repo.GetAll().Count);
        }

        [TestMethod()]
        public void UpdateTest()
        {
            CoordinateRepo repo = new CoordinateRepo();
            Coordinates newCor = new Coordinates{ DeviceID = 2, Longitude = 55, Latitude = 40, Date = DateTime.Now };
            Coordinates Corold = repo.GetById(1);
            Coordinates corupdated=repo.Update(1, new Coordinates { DeviceID = 1, Date = DateTime.Now, Longitude = 45, Latitude = 45 });
            Coordinates cor = repo.GetById(1);
            Assert.AreNotEqual(Corold,corupdated);
            Assert.IsNull(repo.Update(10000,corupdated));

        }
    }
}