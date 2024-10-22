using KataTirePressureVariation.Interfaces;
using NSubstitute;
using NUnit.Framework;

namespace KataTirePressureVariation.Test
{
    public class AlarmTest
    {
        private ISensor _pressureSensor;
        private IDisplay _display;
        private Alarm _alarm;

        [SetUp]
        public void SetUp()
        {
            _pressureSensor = Substitute.For<ISensor>();
            _display = Substitute.For<IDisplay>();

            SafePressure savePressure = new SafePressure(17, 21);

            _alarm = new Alarm(savePressure,_pressureSensor, _display);
        }

        [TestCase(16)]
        [TestCase(22)]
        public void Activated_WhenPSI_IsOutOfRange(int psiValue)
        {
            _pressureSensor.GetValue().Returns(psiValue);

            _alarm.Check();

            _display.Received(1).ShowMessage("Caution! Active alarm");
        }

        [TestCase(17)]
        [TestCase(21)]
        public void NotActivated_WhenPSI_IsWithinRange(int psiValue)
        {
            _pressureSensor.GetValue().Returns(psiValue);

            _alarm.Check();

            _display.DidNotReceive().ShowMessage(Arg.Any<string>());
        }

        [Test]
        [TestCase(16)]
        [TestCase(22)]
        public void Activated_Once_For_Multiple_OutOfRange(int psiValue)
        {
            _pressureSensor.GetValue().Returns(psiValue);

            _alarm.Check();
            _alarm.Check();

            _display.Received(1).ShowMessage("Caution! Active alarm");
        }

        [Test]
        [TestCase(17)]
        [TestCase(21)]
        public void NotActivated_For_Multiple_WithinRange(int psiValue)
        {
            _pressureSensor.GetValue().Returns(psiValue);

            _alarm.Check();
            _alarm.Check();

            _display.DidNotReceive().ShowMessage(Arg.Any<string>());
        }

        [Test]
        public void Deactivated_WhenPSI_ReturnsToWithinRange_After_OutOfRange()
        {
            _pressureSensor.GetValue().Returns(16);

            _alarm.Check();
            _pressureSensor.GetValue().Returns(17); 
            _alarm.Check();

            _display.Received(1).ShowMessage("Information! Alarm deactivated");
        }

        [Test]
        public void Activated_WhenPSI_GoesOutOfRange_After_WithinRange()
        {
            _pressureSensor.GetValue().Returns(21);

            _alarm.Check();
            _pressureSensor.GetValue().Returns(22);
            _alarm.Check();

            _display.Received(1).ShowMessage("Caution! Active alarm");

        }
    }
}