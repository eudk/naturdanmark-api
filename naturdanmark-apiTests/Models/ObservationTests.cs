﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
        public void ValidateLongitudeTest()
        {
            Observation obs1 = new Observation { AnimalName = "animal", ID = 1, Picture = null, Date = DateTime.Now, Description = null, Latitude = 0, Longitude = 181 };
            Observation obs2 = new Observation { AnimalName = "Animal", ID = 1, Picture = null, Date = DateTime.Now, Description = null, Latitude = 0, Longitude = -181 };
            Observation obs3 = new Observation { AnimalName = "Animal", ID = 1, Picture = null, Date = DateTime.Now, Description = null, Latitude = 0, Longitude = 180 };
            Observation obs4 = new Observation { AnimalName = "Animal", ID = 1, Picture = null, Date = DateTime.Now, Description = null, Latitude = 0, Longitude = -180 };
            Observation obs5 = new Observation { AnimalName = "Animal", ID = 1, Picture = null, Date = DateTime.Now, Description = null, Latitude = 0, Longitude = -180.1 };
            Observation obs6 = new Observation { AnimalName = "Animal", ID = 1, Picture = null, Date = DateTime.Now, Description = null, Latitude = 0, Longitude = 180.1 };
            obs3.ValidateLongitude();
            obs4.ValidateLongitude();
            Assert.ThrowsException<ArgumentOutOfRangeException>(()=> obs1.ValidateLongitude());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => obs2.ValidateLongitude());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => obs5.ValidateLongitude());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => obs6.ValidateLongitude());

        }

        [TestMethod()]
        public void ValidateLatitudeTest()
        {
            Observation obs1 = new Observation { AnimalName = "animal", ID = 1, Picture = null, Date = DateTime.Now, Description = null, Latitude = 91, Longitude = 0 };
            Observation obs2 = new Observation { AnimalName = "animal", ID = 1, Picture = null, Date = DateTime.Now, Description = null, Latitude = -91, Longitude = 0 };
            Observation obs3 = new Observation { AnimalName = "animal", ID = 1, Picture = null, Date = DateTime.Now, Description = null, Latitude = 90, Longitude = 0 };
            Observation obs4 = new Observation { AnimalName = "animal", ID = 1, Picture = null, Date = DateTime.Now, Description = null, Latitude = -90, Longitude = 0 };
            Observation obs5 = new Observation { AnimalName = "animal", ID = 1, Picture = null, Date = DateTime.Now, Description = null, Latitude = 90.1, Longitude = 0 };
            Observation obs6 = new Observation { AnimalName = "animal", ID = 1, Picture = null, Date = DateTime.Now, Description = null, Latitude  = -90.1, Longitude = 0 };
            obs3.ValidateLatitude();
            obs4.ValidateLatitude();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => obs1.ValidateLatitude());
            Assert.ThrowsException<ArgumentOutOfRangeException>( ()=> obs2.ValidateLatitude());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => obs5.ValidateLatitude());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => obs6.ValidateLatitude());

        }

        [TestMethod]
        public void ValidateDateTest()
        {
            Observation obs1 = new Observation { Date = DateTime.Now };
            Observation obs2 = new Observation { Date = DateTime.Now.AddMinutes(16) };
            Observation obs3 = new Observation { Date = DateTime.Now.AddDays(1) };
            Observation obs4 = new Observation { Date = new DateTime(2023, 11, 23) };
            Observation obs5 = new Observation { Date = DateTime.Now.AddDays(-6) };
            obs1.ValidateDateTime();
            obs5.ValidateDateTime();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => obs2.ValidateDateTime());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => obs3.ValidateDateTime());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => obs4.ValidateDateTime());
        }

        [TestMethod]
        public void TestValidateUserName()
        {
            Observation obs1 = new Observation { UserName = "" };
            Observation obs2 = new Observation { UserName = "user" };
            Observation obs3 = new Observation { UserName = null };
            obs2.ValidateUsername();
            Assert.ThrowsException<ArgumentOutOfRangeException>(obs1.ValidateUsername);
            Assert.ThrowsException<ArgumentNullException>(obs3.ValidateUsername);
        }

        [TestMethod]
        public void TestDistance()
        {
            Observation obs = new Observation() { Latitude = 40.4568, Longitude = 73.9852};
            double distance = obs.DistanceFrom(33.3333, 56.7877);
            double expectedDistance = 1718000;
            Assert.IsTrue((distance - expectedDistance) < 1000);
            distance = obs.DistanceFrom(null, 1);
            Assert.AreEqual(0, distance);
            distance = obs.DistanceFrom(1, null);
            Assert.AreEqual(0, distance);
            distance = obs.DistanceFrom(null, null);
            Assert.AreEqual(0, distance);
        }
    }
}