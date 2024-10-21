using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KataTirePressureVariation.Interfaces;

namespace KataTirePressureVariation
{
    public class Alarm
    {

        private const int MAX_PRESURE = 21;
        private const int MIN_PRESURE = 17;
        private static bool _isActive = false;
        
        private readonly ISensor _presureSensor;
        private readonly IDisplay _display;

        public Alarm(ISensor presureSensor, IDisplay display)
        {
            _presureSensor = presureSensor;
            _display = display;
        }

        public void Check()
        {
            int actualPsi = _presureSensor.GetValue();


            if (actualPsi < MIN_PRESURE || actualPsi > MAX_PRESURE)
            {
                _isActive = !_isActive;
            }

        }
    }
}