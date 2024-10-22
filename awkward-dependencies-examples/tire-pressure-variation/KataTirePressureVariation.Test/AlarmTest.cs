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
        public void Activated_When_PSI_Is_Out_Of_Range(int psiValue)
        {
            _pressureSensor.GetValue().Returns(psiValue);

            _alarm.Check();

            _display.Received(1).ShowMessage("Caution! Active alarm");
        }

        [TestCase(17)]
        [TestCase(21)]
        public void Not_Activated_When_PSI_Is_Within_Range(int psiValue)
        {
            _pressureSensor.GetValue().Returns(psiValue);

            _alarm.Check();

            _display.DidNotReceive().ShowMessage(Arg.Any<string>());
        }

        [TestCase(16)]
        [TestCase(22)]
        public void Activated_Once_When_PSI_Is_Out_Of_Range_Multiple_Times(int psiValue)
        {
            _pressureSensor.GetValue().Returns(psiValue);

            _alarm.Check();
            _alarm.Check();

            _display.Received(1).ShowMessage("Caution! Active alarm");
        }

        [Test]
        [TestCase(17)]
        [TestCase(21)]
        public void Not_Activated_When_PSI_Is_Within_Range_Multiple_Times(int psiValue)
        {
            _pressureSensor.GetValue().Returns(psiValue);

            _alarm.Check();
            _alarm.Check();

            _display.DidNotReceive().ShowMessage(Arg.Any<string>());
        }

        [Test]
        public void Deactivated_When_PSI_Returns_To_Within_Range_After_Being_Out_Of_Range()
        {
            _pressureSensor.GetValue().Returns(16);
            _alarm.Check();
            _pressureSensor.GetValue().Returns(17); 
            
            _alarm.Check();

            _display.Received(1).ShowMessage("Information! Alarm deactivated");
        }

        [Test]
        public void Activated_When_PSI_Goes_Out_Of_Range_After_Being_Within_Range()
        {
            _pressureSensor.GetValue().Returns(21);
            _alarm.Check();
            _pressureSensor.GetValue().Returns(22);
            
            _alarm.Check();

            _display.Received(1).ShowMessage("Caution! Active alarm");

        }
    }
}