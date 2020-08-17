using System;
using System.Collections.Generic;
using System.Text;

namespace Cafe
{
    public class Menu
    {
        public Menu() { }
        public Menu(int mealnum, string mealname, string description, string listofingredients, decimal price)
        {
            MealNum = mealnum;
            MealName = mealname;
            Description = description;
            ListOfIngredients = listofingredients;
            Price = price;
        }
        //all of my parameters and logic 
        public int MealNum { get; set; }
        public string MealName { get; set; }
        public string Description { get; set; }
        public string ListOfIngredients { get; set; }
        public decimal Price { get; set; }




    }
}
