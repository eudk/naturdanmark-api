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
                ObservationContext dbcontext= new(optionsbuilder.Options);
                _repo= new ObservationsRepoDB(dbcontext);
            }
        }

        [TestMethod()]
        public void AddTest()
        {
            int before=_repo.GetAll().Count();
            _repo.Add(new Observation { AnimalName = "Animal", ID = 1, Picture = null, Date = DateTime.Now, Description = "A", Latitude = 0, Longitude = 0 });
            Assert.AreEqual(before+1, _repo.GetAll().Count());
        }

        [TestMethod()]
        public void GetbyidTest()
        {
            
            Observation? obs = _repo.Getbyid(2);
            Observation obsmimic = _repo.GetAll()[1];
            Observation? obsNull = _repo.Getbyid(99);
            Assert.AreEqual(obsmimic, obs);
            Assert.IsNull(obsNull);
        }
    }
}