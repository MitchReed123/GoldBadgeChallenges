using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Badges
{
    public class BadgeUI
    {
        private bool _IsOpen = true;
        private readonly BadgeRepository _badgeRepository = new BadgeRepository();

        public void Start()
        {
            SeedContent();
            Menu();
        }

        private void Menu()
        {
            while (_IsOpen)
            {
                string input = getBadgeSelection();
                openBadgeItem(input);
            }
        }

        private string getBadgeSelection()
        {
            Console.Clear();
            Console.WriteLine(
                "Hello Security Admin, What would you like to do?\n" +
                "1 - Add a badge\n" +
                "2 - Edit a badge\n" +
                "3 - List all Badges\n"
                );
            string input = Console.ReadLine();
            return input;
        }

        private void openBadgeItem(string input)
        {
            Console.Clear();
            switch (input)
            {
                case "1":
                    //Add a badge
                    AddNewBadge();
                    break;
                case "2":
                    // edit a badge
                    break;
                case "3":
                    //list all badges
                    DisplayAllBadges();
                    break;
                default:
                    Console.WriteLine("Please select a valid option!");
                    break;
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        //logic for displaying all badges
        private void DisplayAllBadges()
        {
            List<Badge> listBadges = _badgeRepository.GetBadges();

            foreach (Badge item in listBadges)
            {
                DisplayBadges(item);
            }
        }
        //look at joshes console game example he used to make it so everything flows under it without multiplying the output it gives
        private void DisplayBadges(Badge badge)
        {
            List<Badge> listBadges = _badgeRepository.GetBadges();

            Console.WriteLine($"{"Badge Num: ", -5} {"Door Access", -22}");

            foreach (Badge item in listBadges)
            {
                Thread.Sleep(75);
                Console.WriteLine($"{item.BadgeID,-11} {item.DoorNames,-22}");
            }
        }

        //logic for adding a new badge
        private void AddNewBadge()
        {
            Console.Write("What is the number on the badge: ");
            string badgeid = Console.ReadLine();
            int BadgeID = int.Parse(badgeid);

            Console.Write("List a door that it needs access to: ");
            string AccessDoors = Console.ReadLine();

            Console.Write("Give the Badge a name: ");
            string BadgeName = Console.ReadLine();

            //AddMoreDoors();
            //Console.ReadLine();
            //Console.Write("Any other doors: (y/n)");
            //string userInput = Console.ReadLine();
            //switch (userInput)
            //{
            //    case "y":
            //        Console.Write("List a door that it needs access to:");
            //        string AccessDoors2 = Console.ReadLine();
            //        break;
            //    case "n":
            //        Menu();
            //        break;
            //}

            Badge newItem = new Badge(BadgeID, AccessDoors, BadgeName);

            _badgeRepository.AddNewBadges(newItem);
        }

        private string AddMoreDoors()
        {
            Console.WriteLine(
                $"Any other doors?: (y/n)\n" +
                $"y\n" +
                $"n\n"
                );
            while (true)
            {
                switch (Console.ReadLine())
                {
                    case "y":
                        Console.Write("List a door that it needs access to:");
                        string AccessDoors = Console.ReadLine();
                        break;
                    case "n":
                        Menu();
                        break;
                }
            }
        }

        public bool UpdateBadges(Badge updateBadge, int ID)
        {
            DisplayAllBadges();

            Console.WriteLine("What is the badge number to update?: ");
            string userInput = Console.ReadLine();

            int inputID = int.Parse(userInput);

            int BadgeID = inputID;

            Console.WriteLine("Input a new badge: ");
            string badgeName = Console.ReadLine();

            Console.WriteLine(
                "What would you like to do?\n" +
                "1. Remove a Door\n" +
                "2. Add a door\n"
                );
            
            switch (Console.ReadLine())
            {
                case "1":
                    //remove a door
                    //after they remove a door return what doors that person has access too
                    break;
                case "2":
                    //add a door
                    //Say added the door!
                    break;
                default:
                    Console.WriteLine("Please select a valid option");
                    break;
            }
            //Badge newItem = new Badge(BadgeID, )
                return false;
        }

        private void SeedContent()
        {
            Badge itemOne = new Badge(1, "Testing, Testing, Testing", "Testing");
            Badge itemTwo = new Badge(2, "Testing, Testing, Testing", "Testing");
            Badge itemThree = new Badge(3, "Testing, Testing, Testing", "Testing");

            _badgeRepository.AddNewBadges(itemOne);
            _badgeRepository.AddNewBadges(itemTwo);
            _badgeRepository.AddNewBadges(itemThree);
        }


    }
}
