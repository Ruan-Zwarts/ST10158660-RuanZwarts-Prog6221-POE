using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10158660_RuanZwarts_Prog6221_POE
{
    internal class Ingredient
    {
        class IngredientList
        {
            public string Name { get; set; }
            public double Quantity { get; set; }
            public string Unit { get; set; }
            private double originalQuantity;

            public IngredientList(string name, double quantity, string unit)
            {
                Name = name;
                Quantity = quantity;
                Unit = unit;
                originalQuantity = quantity;
            }

            public void ResetQuantity()
            {
                Quantity = originalQuantity;
            }
        }
    }
}
