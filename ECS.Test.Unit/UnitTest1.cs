using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;

namespace ECS.New
{
    [TestFixture]
    public class UnitTest1
    {
        private ECS _uut;
        private IHeater _heater;
        private ITempSensor _tempSensor;
        private int _thr;

        [SetUp]

        public void SetUp()
        {
            _heater = new FakeHeater();
            _tempSensor = new FakeTempSensor();
            _thr = 30;
            _uut = new ECS(_thr, _tempSensor, _heater);
        }

        [Test]
        public void TestMethod1()
        {
        }
    }
}
