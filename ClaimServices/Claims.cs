using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace ClaimServices
{
    public class Claims
    {
        public Claims()
        {

        }

        public Claims(int claimid, claimTypes claimtypes, string description, double claimamount, DateTime dateofincedent, DateTime dateofclaim)
        {
            ClaimID = claimid;
            ClaimTypes = claimtypes;
            Description = description;
            ClaimAmount = claimamount;
            DateOfIncident = dateofincedent;
            DateOfClaim = dateofclaim;
        }


        public int ClaimID { get; set; }
        //enum for claim type having car, home, theft
        public claimTypes ClaimTypes { get; set; }
        public string Description { get; set; }
        public double ClaimAmount { get; set; }

        public DateTime DateOfIncident { get; set; }

        public DateTime DateOfClaim { get; set; }
        public bool isValid { 
            get 
            {
                int days = ((TimeSpan)(DateOfClaim - DateOfIncident)).Days;
                //Console.WriteLine(days);
                if (days > 30)
                {
                    return false;
                } else
                {
                    return true;
                }
            }  
        }
    }

    public enum claimTypes
    {
        Home,
        Car,
        Theft
    }
}
