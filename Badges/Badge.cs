using System;
using System.Collections.Generic;
using System.Text;

namespace Badges
{
    public class Badge
    {
        public Badge()
        {

        }

        public Badge(int badgeid, string doornames, string badgename)
        {
            BadgeID = badgeid;
            DoorNames = doornames;
            BadgeName = badgename;
        }
        //a badgeID will have multiple doors and a badge name

        public int BadgeID { get; set; }
        public string DoorNames { get; set; }
        public string BadgeName { get; set; }


    }
}
