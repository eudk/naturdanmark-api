using Microsoft.VisualStudio.TestTools.UnitTesting;
using naturdanmark_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace naturdanmark_api.Models.Tests
{
    [TestClass()]
    public class ObservationTests
    {
        [TestMethod()]
        public void ValidateAnimalNameTest()
        {
            Observation obs1 = new Observation { AnimalName = "", ID = 1, Picture = null, Date = DateTime.Now, Description = null, Latitude = 0, Longitude = 0 };
            Observation obs2 = new Observation { AnimalName = null, ID = 1, Picture = null, Date = DateTime.Now, Description = null, Latitude = 0, Longitude = 0 };
            Observation obs3 = new Observation { AnimalName = "Animal", ID = 1, Picture = null, Date = DateTime.Now, Description = null, Latitude = 0, Longitude = 0 };
            obs3.ValidateAnimalName();
            Assert.ThrowsException<ArgumentNullException>(()=>obs2.ValidateAnimalName());
            Assert.ThrowsException<ArgumentOutOfRangeException>(()=>obs1.ValidateAnimalName());
            

        }

        [TestMethod()]
        public void ValidateLengthTest()
        {
            Observation obs1 = new Observation { AnimalName = "animal", ID = 1, Picture = null, Date = DateTime.Now, Description = null, Latitude = 0, Longitude = 181 };
            Observation obs2 = new Observation { AnimalName = "Animal", ID = 1, Picture = null, Date = DateTime.Now, Description = null, Latitude = 0, Longitude = -181 };
            Observation obs3 = new Observation { AnimalName = "Animal", ID = 1, Picture = null, Date = DateTime.Now, Description = null, Latitude = 0, Longitude = 180 };
            Observation obs4 = new Observation { AnimalName = "Animal", ID = 1, Picture = null, Date = DateTime.Now, Description = null, Latitude = 0, Longitude = -180 };
            Observation obs5 = new Observation { AnimalName = "Animal", ID = 1, Picture = null, Date = DateTime.Now, Description = null, Latitude = 0, Longitude = -180.1 };
            Observation obs6 = new Observation { AnimalName = "Animal", ID = 1, Picture = null, Date = DateTime.Now, Description = null, Latitude = 0, Longitude = 180.1 };
            obs3.ValidateLongtitudes();
            obs4.ValidateLongtitudes();
            Assert.ThrowsException<ArgumentOutOfRangeException>(()=> obs1.ValidateLongtitudes());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => obs2.ValidateLongtitudes());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => obs5.ValidateLongtitudes());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => obs6.ValidateLongtitudes());

        }

        [TestMethod()]
        public void ValidateBreddeTest()
        {
            Observation obs1 = new Observation { AnimalName = "animal", ID = 1, Picture = null, Date = DateTime.Now, Description = null, Latitude = 91, Longitude = 0 };
            Observation obs2 = new Observation { AnimalName = "animal", ID = 1, Picture = null, Date = DateTime.Now, Description = null, Latitude = -91, Longitude = 0 };
            Observation obs3 = new Observation { AnimalName = "animal", ID = 1, Picture = null, Date = DateTime.Now, Description = null, Latitude = 90, Longitude = 0 };
            Observation obs4 = new Observation { AnimalName = "animal", ID = 1, Picture = null, Date = DateTime.Now, Description = null, Latitude = -90, Longitude = 0 };
            Observation obs5 = new Observation { AnimalName = "animal", ID = 1, Picture = null, Date = DateTime.Now, Description = null, Latitude = 90.1, Longitude = 0 };
            Observation obs6 = new Observation { AnimalName = "animal", ID = 1, Picture = null, Date = DateTime.Now, Description = null, Latitude  = -90.1, Longitude = 0 };
            obs3.ValidateLattitudes();
            obs4.ValidateLattitudes();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => obs1.ValidateLattitudes());
            Assert.ThrowsException<ArgumentOutOfRangeException>( ()=> obs2.ValidateLattitudes());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => obs5.ValidateLattitudes());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => obs6.ValidateLattitudes());

        }
    }
}