using NSubstitute;
using NUnit.Framework;

namespace CoffeeMachineKata.Tests
{
    public class CoffeeMachineTest
    {
        private IDrinkMaker _drinkMaker;
        private CoffeeMachine _coffeeMachine;

        [SetUp]
        public void Init()
        {
            _drinkMaker = Substitute.For<IDrinkMaker>();
            _coffeeMachine = new CoffeeMachine(_drinkMaker);
        }

        [Test]
        public void Make_Coffee_Without_Sugar()
        {
            _coffeeMachine.SelectCoffee();

            _coffeeMachine.MakeDrink();

            _drinkMaker.Received().Execute("C::");
        }

        [Test]
        public void Make_Tea_Without_Sugar()
        {

            _coffeeMachine.SelectTea();

            _coffeeMachine.MakeDrink();

            _drinkMaker.Received().Execute("T::");
        }

        [Test]
        public void Make_Chocolate_Without_Sugar()
        {

            _coffeeMachine.SelectChocolate();
            _coffeeMachine.MakeDrink();

            _drinkMaker.Received().Execute("H::");
        }


        [Test]
        public void Make_Coffee_With_One_Sugar()
        {
            _coffeeMachine.SelectCoffee();
            _coffeeMachine.AddSugar(1);

            _coffeeMachine.MakeDrink();

            _drinkMaker.Received().Execute("C:1:0");
        }

        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        public void Make_Coffee_With_Two_Or_More_Sugars(int sugarCount)
        {
            _coffeeMachine.SelectCoffee();
            _coffeeMachine.AddSugar(sugarCount);

            _coffeeMachine.MakeDrink();

            _drinkMaker.Received().Execute("C:2:0");
        }

        [Test]
        public void Make_Drink_Without_Selection()
        {
            _coffeeMachine.MakeDrink();

            _drinkMaker.DidNotReceive().Execute(Arg.Any<string>());

        }

        [Test]
        public void Make_Drink_Multiple_Times()
        {
            _coffeeMachine.SelectCoffee();
            _coffeeMachine.AddSugar(1);
            _coffeeMachine.MakeDrink();

            _coffeeMachine.MakeDrink();

            _drinkMaker.Received(1).Execute("C:1:0");
        }
    }
}