using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace naturdanmark_apiTests.Models
{
    public class KoordinatesTest
    {
        [TestMethod]
        public void ValidateLongtitude()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>);
        }

        [TestMethod]
        public void ValidateLatitude()
        {
            Assert.ThrowsException<ArgumentException>(() =>);
        }
    }
}
