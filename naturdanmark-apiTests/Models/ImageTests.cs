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
    public class ImageTests
    {
        [TestMethod()]
        public void ImageTest()
        {
            Image image = new Image("this is an image, trust");
            image.validate();
            image = new Image(null);
            Assert.ThrowsException<ArgumentNullException>(() => image.validate());
        }
    }
}