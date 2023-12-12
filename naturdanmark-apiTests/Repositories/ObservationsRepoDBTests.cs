using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using naturdanmark_api.Context;
using naturdanmark_api.Repositories;
using naturdanmark_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace naturdanmark_api.Repositories.Tests
{
    [TestClass()]
    public class ObservationsRepoDBTests
    {
        private const bool useDatabase = true;
        private static ObservationsRepoDB _repo;

        [ClassInitialize]
        public static void initonce(TestContext context)
        {
            if(useDatabase)
            {
                var optionsbuilder = new DbContextOptionsBuilder<ObservationContext>();
                optionsbuilder.UseSqlServer(Secret.secret);
                ObservationContext dbcontext = new(optionsbuilder.Options);
                _repo = new ObservationsRepoDB(dbcontext);
            }
        }

        [TestMethod()]
        public void GetAllTest()
        {
            List<Observation> observations = _repo.Get();
            List<Observation> observationFromToday = _repo.Get(true);
            List<Observation> observationSortedByDateAsc = _repo.Get(false, "dateasc");
            List<Observation> observationSortedByDateDesc = _repo.Get(false, "datedesc");
            Assert.AreNotEqual(observations.Count(), observationFromToday.Count());
            Assert.AreEqual(observationSortedByDateAsc[observations.Count() - 1], observationSortedByDateDesc[0]);
            Assert.ThrowsException<ArgumentException>(() => _repo.Get(false, "ghghghhg"));
        }

        [TestMethod()]
        public void AddTest()
        {
            int before = _repo.Get().Count();
            _repo.Add(new Observation { AnimalName = "Animal",UserName="user", ID = 1, Picture = null, Date = DateTime.Now, Description = "AB", Latitude = 0, Longitude = 0 });
            Assert.AreEqual(before+1, _repo.Get().Count());
        }

        [TestMethod()]
        public void GetbyidTest()
        {
            
            Observation? obs = _repo.Getbyid(3);
            Observation obsmimic = _repo.Get()[2];
            Observation? obsNull = _repo.Getbyid(99);
            Assert.AreEqual(obsmimic, obs);
            Assert.IsNull(obsNull);
        }
    }
}