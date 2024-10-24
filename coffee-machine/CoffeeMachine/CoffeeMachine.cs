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
        private int _sugarCount = 0;

        public CoffeeMachine(IDrinkMaker drinkMaker)
        {
            _drinkMaker = drinkMaker;
        }

        public void MakeDrink()
        {
            if (_drinkSelection != DrinkTypes.None)
            {
                _drinkMaker.Execute($"{GetDrinkRepresentation()}:{GetSugarRepresentation()}:{GetStickRepresentation()}");
            }

            //reset the drink selection
            _drinkSelection = DrinkTypes.None;
            _sugarCount = 0;

        }

        private string GetStickRepresentation()
        {
            if (_sugarCount > 0)
            {
                return "0";
            }

            return string.Empty;
        }

        private string GetSugarRepresentation()
        {
            if (_sugarCount == 0)
            {
                return string.Empty;
            }
            else if(_sugarCount == 1)
            {
                return "1";
            }
            else
            {
                return "2";
            }
        }

        private string GetDrinkRepresentation()
        {
            return _drinkSelection.GetCode();
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

        public void AddSugar(int sugarCount)
        {
            _sugarCount += sugarCount;
        }
    }
}
