using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;

namespace ClaimServices
{
    public class ClaimsUI
    {
        private bool _IsOpen = true;
        private readonly ClaimsRepository _claimsRepository = new ClaimsRepository();

        public void Start()
        {
            SeedContent();
            Menu();
        }

        private void Menu()
        {
            while (_IsOpen)
            {
                string input = getClaimSelection();
                openClaimItem(input);
            }
        }

        private string getClaimSelection()
        {
            Console.Clear();
            Console.WriteLine(
                "Welcome to your Claim Selection Menu!\n" +
                "Select an Item Please\n" +
                "1 - See all Claims\n" +
                "2 - Take care of next claim\n" +
                "3 - Enter a new claim\n" +
                "4 - Modify an existing claim\n"
                );
            string input = Console.ReadLine();
            return input;
        }

        private void openClaimItem(string input)
        {
            Console.Clear();
            switch (input)
            {
                case "1":
                    //See all claims
                    DisplayAllClaims();
                    break;
                case "2":
                    //Take care of next claim
                    NextClaim();
                    break;
                case "3":
                    // Add a new claim
                    AddNewClaim();
                    break;
                case "4":
                    // Update a claim
                    updateClaims();
                    break;
                default:
                    Console.WriteLine("Please select a valid option!");
                    break;
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
        //logic for displaying all the claims
        private void DisplayAllClaims()
        {
            //List<Claims> listClaims = _claimsRepository.GetClaims();

            Queue<Claims> queueClaims = _claimsRepository.GetClaimsQ();

            Claims claim = _claimsRepository.GetNextClaim();
            DisplayClaims(claim);
            //foreach (Claims item in queueClaims)
            //{
            //    DisplayClaims(item);
            //}
        }

        private void DisplayClaims(Claims claims)
        {
            Queue<Claims> queueClaims = _claimsRepository.GetClaimsQ();

            Console.WriteLine($"{"ClaimID", -5} {"Type", -5} {"Description", -22} {"Amount", -7} {"DateOfAccident", -18} {"DateOfClaim", -18} {"IsValid", -7}" );
            foreach (Claims item in queueClaims)
            {
                Thread.Sleep(75);
            Console.WriteLine($"{item.ClaimID, -7} {item.ClaimTypes, -5} {item.Description, -22} {item.ClaimAmount, -7} {item.DateOfIncident.ToShortDateString(), -18} {item.DateOfClaim.ToShortDateString(), -18} {item.isValid, -7} ");
            }
            
        }

        private void DisplaySingleClaim(Claims claim)
        {
            Console.WriteLine($"{"ClaimID",-5} {"Type",-5} {"Description",-22} {"Amount",-7} {"DateOfAccident",-18} {"DateOfClaim",-18} {"IsValid",-7}");
            Thread.Sleep(75);
            Console.WriteLine($"{claim.ClaimID, -7} {claim.ClaimTypes, -5} {claim.Description, -22} {claim.ClaimAmount, -7} {claim.DateOfIncident.ToShortDateString(), -18} {claim.DateOfClaim.ToShortDateString(), -18} {claim.isValid, -7}");
        }

        //logic for going to next claim
        private void NextClaim()
        {
            //DisplayAllClaims();
            Console.Write("Do you want to deal with the next claim(y/n)?: ");
            //string userInput = Console.ReadKey()
            //if userInput == "y" show next claim in the array, else return to menu
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "y":
                    NextClaimLogic();
                    break;
                case "n":
                    Menu();
                    break;
            }
        }

        private void NextClaimLogic()
        {


            Claims claim = _claimsRepository.GetNextClaim();
            if(claim != null)
            {
                //displaysingleclaim
                DisplaySingleClaim(claim);
                Console.WriteLine("Do you want to deal with it or no?");
            }
        }

        private DateTime userDateTime()
        {
            DateTime userDateTime;
            if(DateTime.TryParse(Console.ReadLine(), out userDateTime)){
                return userDateTime.Date;
            }
            else
            {
                Console.WriteLine("Entered a incorrect Value");
            }
            return DateTime.Now;
        }

        //logic for adding a new claim
        private void AddNewClaim() 
        {
            Console.Write("Enter the claim ID: ");
            string sID = Console.ReadLine();
            int ClaimID = Convert.ToInt32(sID);

            Console.Write("Enter the claim type: ");
            claimTypes claimtypes = GetClaimTypes();

            Console.Write("Enter a claim description: ");
            string description = Console.ReadLine();

            Console.Write("Amount dont in Damage: ");
            string input = Console.ReadLine();
            double Amount = double.Parse(input);

            Console.Write("Date of Accident: YYYY/MM/DD: ");
            string dateinput = Console.ReadLine();
            DateTime accidentDate = Convert.ToDateTime(dateinput).Date;

            //DateTime newish = DateTime.Now;
            //Console.Write("Date of Claim:  YYYY,DD,MM: ");
            //string claimInput = Console.ReadLine();
            DateTime claimDate = DateTime.Today;

            //Console.Write("Is this a valid claim?:YTrue/False ");
            //string valid = Console.ReadLine();
            //bool isValid = Boolean.Parse(valid);

            Claims newItem = new Claims(ClaimID, claimtypes, description, Amount, accidentDate, claimDate);

            //_claimsRepository.AddContentToQueue(newItem);
            _claimsRepository.AddContentQueue(newItem);
        }

        private claimTypes GetClaimTypes()
        {
            Console.WriteLine(
                $"Select a claim type\n" +
                $"1 - House\n" +
                $"2 - Car\n" +
                $"3 - Theft\n"
                );
            while (true)
            {
                switch (Console.ReadLine())
                {
                    case "1":
                        return claimTypes.Home;

                    case "2":
                        return claimTypes.Car;
                    case "3":
                        return claimTypes.Theft;
                }
                Console.WriteLine("You did not select an option thats available, try again.");
            }
        }

        private void updateClaims()
        {
            // display all content
            DisplayAllClaims();
            // ask for the id of the claim to update
            Console.WriteLine("Please enter the ID of the claim you are looking to update");
            string userInput = Console.ReadLine();
            // get that id
            int inputID = int.Parse(userInput);

            // build a new object 
            //Console.Write("Enter the claim ID: ");
            //string sID = Console.ReadLine();
            int ClaimID = inputID;

            Console.Write("Enter the claim type: ");
            claimTypes claimtypes = GetClaimTypes();

            Console.Write("Enter a claim description: ");
            string description = Console.ReadLine();

            Console.Write("Amount dont in Damage: ");
            string input = Console.ReadLine();
            double Amount = double.Parse(input);

            Console.Write("Date of Accident: YYYY/MM/DD: ");
            string dateinput = Console.ReadLine();
            DateTime accidentDate = Convert.ToDateTime(dateinput);

            //DateTime newish = DateTime.Now;
            Console.Write("Date of Claim:  YYYY/MM/DD: ");
            string claimInput = Console.ReadLine();
            DateTime claimDate = Convert.ToDateTime(claimInput);

            Console.Write("Is this a valid claim?: True/False ");
            string valid = Console.ReadLine();
            bool isValid = Boolean.Parse(valid);

            Claims newItem = new Claims(ClaimID, claimtypes, description, Amount, accidentDate, claimDate);

            //veryify the update worked
            bool wasUpdated = _claimsRepository.UpdateClaims(newItem, inputID);
            if (wasUpdated)
            {
                Console.WriteLine("Claim updated");
            } else
            {
                Console.WriteLine("Not updated");
            }
        }

        private void SeedContent()
        {
            Claims itemOne = new Claims(4, claimTypes.Car, "testing", 12000,DateTime.Now.Date, DateTime.Now.Date);
            Claims itemTwo = new Claims(2, claimTypes.Home, "testing", 200000, new DateTime(2020, 8, 5).Date, DateTime.Now.Date);
            Claims itemThree = new Claims(1, claimTypes.Theft, "testing", 15000, DateTime.Now.Date, DateTime.Now.Date);

            //_claimsRepository.AddContentToClaims(itemOne);
            //_claimsRepository.AddContentToClaims(itemTwo);
            //_claimsRepository.AddContentToClaims(itemThree);

            _claimsRepository.AddContentQueue(itemOne);
            _claimsRepository.AddContentQueue(itemTwo);
            _claimsRepository.AddContentQueue(itemThree);
        }
    }
}
