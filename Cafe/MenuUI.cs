using System;
using System.Collections.Generic;
using System.Text;

namespace Cafe
{
    public class MenuUI
    {
        private bool _IsOpen = true;
        private readonly MenuRepository _MenuRepo = new MenuRepository();

        public void Start()
        {
            SeedContent();
            Menu();
        }


        private void Menu()
        {
            while (_IsOpen)
            {
                string input = getMenuSelection();
                openMenuItem(input);
            }
        }

        private string getMenuSelection()
        {
            Console.Clear();
            Console.WriteLine(
                "Welcome to the Menu!\n" +
                "Select an Item Please\n" +
                "1 - Add New Menu Item\n" +
                "2 - Delete Menu Item\n" +
                "3 - See Full Menu\n"
                );
            string input = Console.ReadLine();
            return input;
        }

        private void openMenuItem(string input)
        {
            Console.Clear();
            switch (input)
            {
                case "1":
                    //Add new Items
                    AddNewMenuItem();
                    break;
                case "2":
                    //delete items
                    DeleteItem();
                    break;
                case "3":
                    //See full Menu
                    DisplayAllItems();
                    break;
                default:
                    Console.WriteLine("Please select a valid option.");
                    break;
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        private void DisplayAllItems()
        {
            List<Menu> listMenu = _MenuRepo.GetMenu();

            foreach (Menu item in listMenu)
            {
                DisplayFullMenu(item);
            }
        }


        private void DisplayFullMenu(Menu menu)
        {

            Console.WriteLine(
                $"---------------------------------------------------\n" +
                $"| Meal Number: {menu.MealNum}\n" +
                $"---------------------------------------------------\n" +
                $"| Meal Name: {menu.MealName}\n" +
                $"---------------------------------------------------\n" +
                $"| Meal Description: {menu.Description}\n" +
                $"---------------------------------------------------\n" +
                $"| List of Ingredients: {menu.ListOfIngredients}\n" +
                $"---------------------------------------------------\n" +
                $"| Price of Item: {menu.Price}\n" +
                $"---------------------------------------------------\n"
                );

        }

        private void DisplayByName(string name)
        {
            Console.WriteLine("Enter a Menu Name you are Looking for.");
            string userInput = Console.ReadLine();

            Menu searchResult = _MenuRepo.GetByName(userInput);

            if(searchResult != null)
            {
                DisplayFullMenu(searchResult);
            }
        }

        private void DeleteItem()
        {
            DisplayAllItems();

            //get the name
            Console.WriteLine("What is the name of the menu item: ");
            string userInput = Console.ReadLine();

            bool wasDeleted = _MenuRepo.RemoveContentFromList(userInput);

            if(wasDeleted)
            {
                Console.WriteLine("Your Menu Item was deleted");
            } else
            {
                Console.WriteLine("Menu item wasnt deleted");
            }

        }



        private void AddNewMenuItem()
        {
            Console.WriteLine("Enter a Meal Num");
            string mealNum = Console.ReadLine();
            int MealNumber = Convert.ToInt32(mealNum);

            Console.WriteLine("Enter name of Meal");
            string MealName = Console.ReadLine();

            Console.WriteLine("Enter a Description");
            string description = Console.ReadLine();

            Console.WriteLine("List the ingredients");
            string ingredients = Console.ReadLine();

            Console.WriteLine("Enter a Price");
            string cost = Console.ReadLine();
            decimal price = decimal.Parse(cost);

            Menu newItem = new Menu(MealNumber, MealName, description, ingredients, price);

            _MenuRepo.AddContentToMenu(newItem);
        }

        private void SeedContent()
        {
            Menu itemOne = new Menu(1, "Testing", "testing", "Testing, Testing, Testing", 12);

            _MenuRepo.AddContentToMenu(itemOne);
        }
    }
}
