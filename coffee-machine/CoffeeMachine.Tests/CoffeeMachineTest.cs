using NSubstitute;
using NUnit.Framework;

namespace CoffeeMachineKata.Tests
{
    public class CoffeeMachineTest
    {
        [Test]
        public void Make_Coffee_Without_Sugar()
        {
            var drinkMaker = Substitute.For<IDrinkMaker>();
            
            var coffeeMachine = new CoffeeMachine(drinkMaker);

            coffeeMachine.SelectCoffee();
            coffeeMachine.MakeDrink();

            drinkMaker.Received().Execute("C::");
            
        }

        [Test]
        public void Make_Tea_Without_Sugar()
        {
            var drinkMaker = Substitute.For<IDrinkMaker>();

            var coffeeMachine = new CoffeeMachine(drinkMaker);

            coffeeMachine.SelectTea();
            coffeeMachine.MakeDrink();

            drinkMaker.Received().Execute("T::");

        }

        [Test]
        public void Make_Chocolate_Without_Sugar()
        {
            var drinkMaker = Substitute.For<IDrinkMaker>();

            var coffeeMachine = new CoffeeMachine(drinkMaker);

            coffeeMachine.SelectChocolate();
            coffeeMachine.MakeDrink();

            drinkMaker.Received().Execute("H::");

        }
    }
}