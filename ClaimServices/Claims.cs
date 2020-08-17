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

        public Claims(int claimid, claimTypes claimtypes, string description, double claimamount, DateTime dateofincedent, DateTime dateofclaim, bool isvalid)
        {
            ClaimID = claimid;
            ClaimTypes = claimtypes;
            Description = description;
            ClaimAmount = claimamount;
            DateOfIncident = dateofincedent;
            DateOfClaim = dateofclaim;
            isValid = isvalid;
        }


        public int ClaimID { get; set; }
        //enum for claim type having car, home, theft
        public claimTypes ClaimTypes { get; set; }
        public string Description { get; set; }
        public double ClaimAmount { get; set; }

        public DateTime DateOfIncident { get; set; }

        public DateTime DateOfClaim { get; set; }
        public bool isValid { get; set; }
    }

    public enum claimTypes
    {
        Home,
        Car,
        Theft
    }
}
