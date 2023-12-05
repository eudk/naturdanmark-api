using Microsoft.VisualStudio.TestTools.UnitTesting;
using naturdanmark_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace naturdanmark_apiTests.Models
{
    [TestClass()]
    public class CoordinatesTest
    {
        [TestMethod]
        public void ValidateLongitude()
        {
            Coordinates ko1 = new Coordinates {Longitude=180 };
            Coordinates ko2 = new Coordinates { Longitude = -180 };
            Coordinates ko3 = new Coordinates { Longitude = 181 };
            Coordinates ko4 = new Coordinates{ Longitude = -181 };
            Coordinates ko5 = new Coordinates{ Longitude = 180.1 };
            Coordinates ko6 = new Coordinates{ Longitude = -180.1 };
            ko1.ValidateLongitude();
            ko2.ValidateLongitude();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => ko3.ValidateLongitude());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => ko4.ValidateLongitude());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => ko5.ValidateLongitude());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => ko6.ValidateLongitude());
        }

        [TestMethod]
        public void ValidateLatitude()
        {
            Coordinates ko1=new Coordinates { Latitude=90};
            Coordinates ko2 = new Coordinates { Latitude = -90 };
            Coordinates ko3 = new Coordinates { Latitude = 91 };
            Coordinates ko4 = new Coordinates { Latitude = -91 };
            Coordinates ko5 = new Coordinates { Latitude = 90.1 };
            Coordinates ko6 = new Coordinates { Latitude = -90.1 };
            ko1.ValidateLatitude();
            ko2.ValidateLatitude();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>ko3.ValidateLatitude());
            Assert.ThrowsException<ArgumentOutOfRangeException>(()=>ko4.ValidateLatitude());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => ko5.ValidateLatitude());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => ko6.ValidateLatitude());
        }


    }
}
