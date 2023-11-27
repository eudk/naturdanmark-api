using Microsoft.VisualStudio.TestTools.UnitTesting;
using naturdanmark_api.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using naturdanmark_api.Models;

namespace naturdanmark_api.Repositories.Tests
{
    [TestClass()]
    public class ObservationsRepoTests
    {

        [TestMethod()]
        public void AddTest()
        {
            ObservationsRepo repo = new ObservationsRepo();
            int before=repo.GetAll().Count();
            repo.Add(new Observation { AnimalName = "animal", ID = 1, Billede = null, Date = DateTime.Now, Description = null, Bredde = 0, Længde = 0 });
            Assert.AreEqual(before + 1, repo.GetAll().Count());
        }

        [TestMethod()]
        public void GetbyidTest()
        {
            ObservationsRepo repo = new ObservationsRepo();
            Observation? obs=repo.Getbyid(2);
            Observation obsmimic=repo.GetAll()[1];
            Observation? obsNull = repo.Getbyid(99);
            Assert.AreEqual(obsmimic, obs);
            Assert.IsNull(obsNull);
        }
    }
}