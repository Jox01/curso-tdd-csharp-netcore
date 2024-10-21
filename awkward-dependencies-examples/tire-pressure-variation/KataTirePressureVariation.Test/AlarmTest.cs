using KataTirePressureVariation.Interfaces;
using NSubstitute;
using NUnit.Framework;

namespace KataTirePressureVariation.Test
{
    public class AlarmShould
    {
        private  ISensor _presureSensor;
        private  IDisplay _display;

        private readonly Alarm _sut;

        [SetUp]
        public void SetUp()
        {
            _presureSensor = Substitute.For<ISensor>();
            _display = Substitute.For<IDisplay>();
        }

        [Test]
        [TestCase(16)]
        [TestCase(22)]
        public void Activate_WhenPSI_IsIncorrect(int psiValue)
        {
            _presureSensor.GetValue().Returns(psiValue);
            
            var alarm = new Alarm(_presureSensor, _display);
            
            alarm.Check();
            
            _display.Received(1).ShowMessage("Caution! Active alarm");
        }

        [Test]
        [TestCase(17)]
        [TestCase(21)]
        public void Activate_WhenPSI_IsCorrect(int psiValue)
        {
            _presureSensor.GetValue().Returns(psiValue);
            
            var alarm = new Alarm(_presureSensor, _display);

            alarm.Check();

            _display.DidNotReceive().ShowMessage(Arg.Any<string>());
        }

        [Test]
        [TestCase(16)]
        [TestCase(22)]
        public void Display_StatusAlarm_Changed(int psiValue)
        {
            _presureSensor.GetValue().Returns(psiValue);

            var alarm = new Alarm(_presureSensor, _display);

            alarm.Check();
            alarm.Check();

            _display.Received(1).ShowMessage("Caution! Active alarm");
        }


    }
}