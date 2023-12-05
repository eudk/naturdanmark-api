using Microsoft.VisualStudio.TestTools.UnitTesting;
using naturdanmark_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace naturdanmark_apiTests.Models
{
    public class CoordinatesTest
    {
        [TestMethod]
        public void ValidateLongitude()
        {
            Coordinates ko1 = new Coordinates();
            Coordinates ko2 = new Coordinates();
            Coordinates ko3 = new Coordinates();
            Coordinates ko4 = new Coordinates();
            Coordinates ko5 = new Coordinates();
            Coordinates ko6 = new Coordinates();
            ko1.ValidateLongitude();
            ko2.ValidateLongitude();
            Assert.ThrowsException<ArgumentException>(() => ko3.ValidateLongitude);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => ko4.ValidateLongitude);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => ko5.ValidateLongitude);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => ko6.ValidateLongitude);
        }

        [TestMethod]
        public void ValidateLatitude()
        {
            Coordinates ko1=new Coordinates();
            Coordinates ko2 = new Coordinates();
            Coordinates ko3 = new Coordinates();
            Coordinates ko4 = new Coordinates();
            Coordinates ko5 = new Coordinates();
            Coordinates ko6 = new Coordinates();
            ko1.ValidateLatitude();
            ko2.ValidateLatitude();
            Assert.ThrowsException<ArgumentException>(() =>ko3.ValidateLatitude);
            Assert.ThrowsException<ArgumentOutOfRangeException>(()=>ko4.ValidateLongitude);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => ko5.ValidateLongitude);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => ko6.ValidateLongitude);
        }


    }
}
