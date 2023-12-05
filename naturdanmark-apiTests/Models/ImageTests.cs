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
            const int maxSize = 8; //MB
            byte[] small = new byte[1024];
            byte[] tooBig = new byte[1024*1024*maxSize + 1];
            byte[] justBarely = new byte[1024*1024*maxSize];
            Image image = new Image(1, small);
            image.validate();
            image = new Image(2, tooBig);
            Assert.ThrowsException<ArgumentException>(() => { image.validate() };);
            image = new Image(3, justBarely);
            image.validate();
        }
    }
}