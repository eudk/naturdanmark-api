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
            Observation obs1 = new Observation { AnimalName = "", ID = 1, Billede = null, Date = DateTime.Now, Description = null, Bredde = "breede", Længde = "base" };
            Observation obs2 = new Observation { AnimalName = null, ID = 1, Billede = null, Date = DateTime.Now, Description = null, Bredde = "breede", Længde = "base" };
            Observation obs3 = new Observation { AnimalName = "Animal", ID = 1, Billede = null, Date = DateTime.Now, Description = null, Bredde = "breede", Længde = "base" };
            obs3.ValidateAnimalName();
            Assert.ThrowsException<ArgumentNullException>(()=>obs2.ValidateAnimalName());
            Assert.ThrowsException<ArgumentOutOfRangeException>(()=>obs1.ValidateAnimalName());
            

        }

        [TestMethod()]
        public void ValidateLengthTest()
        {
            Observation obs1 = new Observation { AnimalName = "animal", ID = 1, Billede = null, Date = DateTime.Now, Description = null, Bredde = "breede", Længde = null };
            Observation obs2 = new Observation { AnimalName = "Animal", ID = 1, Billede = null, Date = DateTime.Now, Description = null, Bredde = "breede", Længde = "" };
            Observation obs3 = new Observation { AnimalName = "Animal", ID = 1, Billede = null, Date = DateTime.Now, Description = null, Bredde = "breede", Længde = "base" };
            obs3.ValidateLength();
            Assert.ThrowsException<ArgumentNullException>(()=> obs1.ValidateLength());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => obs2.ValidateLength());
        }

        [TestMethod()]
        public void ValidateBreddeTest()
        {
            Observation obs1 = new Observation { AnimalName = "animal", ID = 1, Billede = null, Date = DateTime.Now, Description = null, Bredde = null, Længde = "base" };
            Observation obs2 = new Observation { AnimalName = "animal", ID = 1, Billede = null, Date = DateTime.Now, Description = null, Bredde = "", Længde = "base" };
            Observation obs3 = new Observation { AnimalName = "animal", ID = 1, Billede = null, Date = DateTime.Now, Description = null, Bredde = "breede", Længde = "base" };
            obs3.ValidateBredde();
            Assert.ThrowsException<ArgumentNullException>(() => obs1.ValidateBredde());
            Assert.ThrowsException<ArgumentOutOfRangeException>( ()=> obs2.ValidateBredde());

        }
    }
}