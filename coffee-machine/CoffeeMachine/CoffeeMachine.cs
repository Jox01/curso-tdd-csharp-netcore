using CoffeeMachine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachineKata
{
    public class CoffeeMachine
    {
        private readonly IDrinkMaker _drinkMaker;

        private DrinkTypes _drinkSelection = DrinkTypes.None;

        public CoffeeMachine(IDrinkMaker drinkMaker)
        {
            _drinkMaker = drinkMaker;
        }

        public void MakeDrink()
        {
            _drinkMaker.Execute($"{GetDrinkRepresentation()}::");
        }

        private string GetDrinkRepresentation()
        {
         return _drinkSelection.GetCode();

            if (_drinkSelection == DrinkTypes.Coffee)
            {
                return "C";
            }

            if (_drinkSelection == DrinkTypes.Tea)
            {
                return "T";
            }

            if (_drinkSelection == DrinkTypes.Chocolate)
            {
                return "H";
            }

            return string.Empty;
        }

        public void SelectChocolate()
        {
            _drinkSelection = DrinkTypes.Chocolate;
        }

        public void SelectCoffee()
        {
            _drinkSelection = DrinkTypes.Coffee;
        }

        public void SelectTea()
        {
            _drinkSelection = DrinkTypes.Tea;
        }
    }
}
