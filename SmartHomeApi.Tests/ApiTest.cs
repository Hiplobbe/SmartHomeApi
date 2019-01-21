using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartHomeApi.Helpers;
using SmartHomeApi.Models;
using System.Linq;

namespace SmartHomeApi.Tests
{
    [TestClass]
    public class ApiTest
    {
        /// <summary>
        /// Tests the home randomizer to it returns expected values.
        /// </summary>
        [TestMethod]
        public void RandomizerTest()
        {
            List<Home> list = HomeHelper.GetMockupHomes(20);

            Assert.IsTrue(list.Count <= 20);
            Assert.IsFalse(list.Any(x => x.Rooms.Count <= 0));
        }
    }
}
