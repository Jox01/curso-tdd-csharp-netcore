using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine
{
    public enum DrinkTypes
    {
        None,
        Coffee,
        Tea,
        Chocolate
    }


    public static class DrinkTypesExtensions
    {
        public static string GetCode(this DrinkTypes value)
        {
            if (value == DrinkTypes.Coffee)
            {
                return "C";
            }

            if (value == DrinkTypes.Tea)
            {
                return "T";
            }

            if (value == DrinkTypes.Chocolate)
            {
                return "H";
            }

            return string.Empty;
        }
    }

  

}
