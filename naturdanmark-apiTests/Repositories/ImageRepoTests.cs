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
using Microsoft.EntityFrameworkCore;

namespace naturdanmark_api.Repositories.Tests
{
    [TestClass()]
    public class ImageRepoTests
    {
        private const bool useDatabase = true;
        private static ImageRepo _repo;

        [ClassInitialize]
        public static void initonce(TestContext context)
        {
            if (useDatabase)
            {
                var optionsbuilder = new DbContextOptionsBuilder<ObservationContext>();
                optionsbuilder.UseSqlServer(Secret.secret);
                ObservationContext dbcontext = new(optionsbuilder.Options);
                _repo = new ImageRepo(dbcontext);
            }
        }


        [TestMethod()]
        public void ImageRepoAddTest()
        {
            Image image = new Image(new byte[1]);
            int before = _repo.Count();
            Image value = _repo.Add(image);
            int after = _repo.Count();
            Assert.AreEqual(before + 1, after);
            Assert.AreEqual(image, value);
            Assert.ThrowsException<ArgumentNullException>(() => _repo.Add(new Image(null)));
            Assert.ThrowsException<ArgumentNullException>(() => _repo.Add(null));
        }

        public void ImageRepoGetByIdTest()
        {
            Image image = new Image(new byte[1]);
            Image? value = _repo.Add(image);
            Assert.IsNotNull(value);
            value = _repo.GetById(value.OberservationID);
            Assert.AreEqual(image, value);
            value = _repo.GetById(-1);
            Assert.IsNull(value);
        }
    }
}