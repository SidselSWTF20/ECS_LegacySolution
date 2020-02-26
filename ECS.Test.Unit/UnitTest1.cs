using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using NSubstitute.Core.DependencyInjection;
using NUnit.Framework;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace ECS.New
{
    [TestFixture]
    public class UnitTest1
    {
        private ECS _uut;
        private IHeater _heater;
        private ITempSensor _tempSensor;
        //private int _thr;

        [SetUp]

        public void SetUp()
        {
            _heater = Substitute.For<IHeater>();
            _tempSensor = Substitute.For<ITempSensor>();

            _uut = new ECS(25, _tempSensor, _heater);
        }

        [Test]
        public void RunSelfTest_TempSensorFails_SelfTestFails()
        {
            _tempSensor.RunSelfTest().Returns(false);
            _heater.RunSelfTest().Returns(true);
            Assert.IsFalse(_uut.RunSelfTest());

        }

        [Test]

        public void Regulate_TempBelowThreshold_HeaterTurnedOff()
        {
            _tempSensor.GetTemp().Returns(27);
            _uut.Regulate();
            _heater.Received(1).TurnOff();
        }

        [Test]
        public void Regulate_TempHigherThenThreshold_HeaterTurnedOn()
        {
            _tempSensor.GetTemp().Returns(10);
            _uut.Regulate();
            _heater.Received(1).TurnOn();
        }

    }
}
