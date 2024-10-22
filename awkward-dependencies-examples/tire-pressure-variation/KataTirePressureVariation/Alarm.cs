using KataTirePressureVariation.Interfaces;

namespace KataTirePressureVariation
{
    public class Alarm
    {
        private const string ACTIVE_MESSAGE = "Caution! Active alarm";
        private const string NON_ACTIVE_MESSAGE = "Information! Alarm deactivated";
        
        private bool _isActive = false;
        private readonly SafePressure _savePressure;
        private readonly ISensor _pressureSensor;
        private readonly IDisplay _display;

        public Alarm(SafePressure savePressure,ISensor pressureSensor, IDisplay display)
        {
            _savePressure = savePressure;
            _pressureSensor = pressureSensor;
            _display = display;
        }

        public void Check()
        {
            int actualPsi = _pressureSensor.GetValue();

            if (actualPsi < _savePressure.Min || actualPsi > _savePressure.Max)
            {
                if (_isActive == false)
                {
                    _display.ShowMessage(ACTIVE_MESSAGE);
                }
                _isActive = true;
            }
            else
            {
                if (_isActive == true)
                {
                    _display.ShowMessage(NON_ACTIVE_MESSAGE);
                    _isActive = false;
                }
            }
        }
    }
}