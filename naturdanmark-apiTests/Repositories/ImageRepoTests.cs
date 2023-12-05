using Microsoft.VisualStudio.TestTools.UnitTesting;
using naturdanmark_api.Context;
using naturdanmark_api.Repositories;
using naturdanmark_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure;

namespace naturdanmark_api.Repositories.Tests
{
    [TestClass()]
    public class ImageRepoTests
    {
        private ImageRepo repo = new();
        [TestMethod()]
        public void ImageRepoAddTest()
        {
            Image image = new Image(new byte[1]);
            int before = repo.Count();
            Image value = repo.Add(image);
            int after = repo.Count();
            Assert.AreEqual(before + 1, after);
            Assert.AreEqual(image, value);
            int? expectNull = repo.Add(null);
            Assert.IsNull(expectNull);
        }

        public void ImageRepoGetByIdTest()
        {
            Image image = new Image(new byte[1]);
            Image? value = repo.Add(image);
            Assert.IsNotNull(value);
            value = repo.GetById(value.ObservationID);
            Assert.AreEqual(image, value);
            value = repo.GetById(null);
            Assert.IsNull(value);
        }
    }
}