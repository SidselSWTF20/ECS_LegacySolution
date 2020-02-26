using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECS.New;

namespace ECS.Test.Unit
{
    class MockHeater : IHeater
    {
        public bool WasTurnOnCalled { get; set; }
        public bool WasTurnOffCalled { get; set; }

        public MockHeater()
        {
            WasTurnOnCalled = false;
            WasTurnOffCalled = false;
        }

        public void TurnOn()
        {
            WasTurnOnCalled = true;
        }

        public void TurnOff()
        {
            WasTurnOffCalled = true;
        }

        public bool RunSelfTest()
        {
            return true;
        }
    }

    class MockTempSensor : ITempSensor

    {
        public int Temp { get; set; }
        public bool WasGetTempCalled { get; set; }

        public MockTempSensor()
        {
            WasGetTempCalled = true;
        }

        public int GetTemp()
        {
            WasGetTempCalled = true;
            return Temp;
        }

        public bool RunSelfTest()
        {
            return true;
        }
    }
}
