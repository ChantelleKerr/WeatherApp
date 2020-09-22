
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeatherApp;
using WeatherApp.Models;

namespace WeatherUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestNNE()
        {
            string isNNE = WindDirection.GetWindDirection(34);
            Assert.IsTrue(isNNE == "NNE");
        }
        [TestMethod]
        public void TestNE()
        {
            string isNE = WindDirection.GetWindDirection(45);
            Assert.IsTrue(isNE == "NE");
        }
        [TestMethod]
        public void TestNorth()
        {
            string isNorth = WindDirection.GetWindDirection(0);
            Assert.IsTrue(isNorth == "N");
            string isN = WindDirection.GetWindDirection(360);
            Assert.IsTrue(isN == "N");
        }
        [TestMethod]
        public void TestSE()
        {
            string isSE = WindDirection.GetWindDirection(135);
            Assert.IsTrue(isSE == "SE");
        }
        [TestMethod]
        public void TestSSE()
        {
            string isSSE = WindDirection.GetWindDirection(136);
            Assert.IsTrue(isSSE == "SSE");
        }
        [TestMethod]
        public void TestSouth()
        {
            string isSouth = WindDirection.GetWindDirection(180);
            Assert.IsTrue(isSouth == "S");
        }

        [TestMethod]
        public void TestSW()
        {
            string isSW = WindDirection.GetWindDirection(225);
            Assert.IsTrue(isSW == "SW");
        }
        [TestMethod]
        public void TestSSW()
        {
            string isSSW = WindDirection.GetWindDirection(181);
            Assert.IsTrue(isSSW == "SSW");
        }
        [TestMethod]
        public void TestWest()
        {
            string isWest = WindDirection.GetWindDirection(270);
            Assert.IsTrue(isWest == "W");
        }
        [TestMethod]
        public void TestWSW()
        {
            string isWSW = WindDirection.GetWindDirection(269);
            Assert.IsTrue(isWSW == "WSW");
        }
        [TestMethod]
        public void TestWNW()
        {
            string isWNW= WindDirection.GetWindDirection(314);
            Assert.IsTrue(isWNW == "WNW");
        }
    }
}
