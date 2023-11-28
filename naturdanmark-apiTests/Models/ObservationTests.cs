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
            Observation obs1 = new Observation { AnimalName = "", ID = 1, Picture = null, Date = DateTime.Now, Description = null, lattitudes = 0, longtitudes = 0 };
            Observation obs2 = new Observation { AnimalName = null, ID = 1, Picture = null, Date = DateTime.Now, Description = null, lattitudes = 0, longtitudes = 0 };
            Observation obs3 = new Observation { AnimalName = "Animal", ID = 1, Picture = null, Date = DateTime.Now, Description = null, lattitudes = 0, longtitudes = 0 };
            obs3.ValidateAnimalName();
            Assert.ThrowsException<ArgumentNullException>(()=>obs2.ValidateAnimalName());
            Assert.ThrowsException<ArgumentOutOfRangeException>(()=>obs1.ValidateAnimalName());
            

        }

        [TestMethod()]
        public void ValidateLengthTest()
        {
            Observation obs1 = new Observation { AnimalName = "animal", ID = 1, Picture = null, Date = DateTime.Now, Description = null, lattitudes = 0, longtitudes = 181 };
            Observation obs2 = new Observation { AnimalName = "Animal", ID = 1, Picture = null, Date = DateTime.Now, Description = null, lattitudes = 0, longtitudes = -181 };
            Observation obs3 = new Observation { AnimalName = "Animal", ID = 1, Picture = null, Date = DateTime.Now, Description = null, lattitudes = 0, longtitudes = 180 };
            Observation obs4 = new Observation { AnimalName = "Animal", ID = 1, Picture = null, Date = DateTime.Now, Description = null, lattitudes = 0, longtitudes = -180 };
            Observation obs5 = new Observation { AnimalName = "Animal", ID = 1, Picture = null, Date = DateTime.Now, Description = null, lattitudes = 0, longtitudes = -180.1 };
            Observation obs6 = new Observation { AnimalName = "Animal", ID = 1, Picture = null, Date = DateTime.Now, Description = null, lattitudes = 0, longtitudes = 180.1 };
            obs3.ValidateLength();
            obs4.ValidateLength();
            Assert.ThrowsException<ArgumentOutOfRangeException>(()=> obs1.ValidateLength());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => obs2.ValidateLength());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => obs5.ValidateLength());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => obs6.ValidateLength());

        }

        [TestMethod()]
        public void ValidateBreddeTest()
        {
            Observation obs1 = new Observation { AnimalName = "animal", ID = 1, Picture = null, Date = DateTime.Now, Description = null, lattitudes = 91, longtitudes = 0 };
            Observation obs2 = new Observation { AnimalName = "animal", ID = 1, Picture = null, Date = DateTime.Now, Description = null, lattitudes = -91, longtitudes = 0 };
            Observation obs3 = new Observation { AnimalName = "animal", ID = 1, Picture = null, Date = DateTime.Now, Description = null, lattitudes = 90, longtitudes = 0 };
            Observation obs4 = new Observation { AnimalName = "animal", ID = 1, Picture = null, Date = DateTime.Now, Description = null, lattitudes = -90, longtitudes = 0 };
            Observation obs5 = new Observation { AnimalName = "animal", ID = 1, Picture = null, Date = DateTime.Now, Description = null, lattitudes = 90.1, longtitudes = 0 };
            Observation obs6 = new Observation { AnimalName = "animal", ID = 1, Picture = null, Date = DateTime.Now, Description = null, lattitudes  = -90.1, longtitudes = 0 };
            obs3.ValidateBredde();
            obs4.ValidateBredde();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => obs1.ValidateBredde());
            Assert.ThrowsException<ArgumentOutOfRangeException>( ()=> obs2.ValidateBredde());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => obs5.ValidateBredde());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => obs6.ValidateBredde());

        }
    }
}