using System;
using System.Collections.Generic;
using FindDoc.Data.Entity.UserProfile.Relatives;

namespace FindDoc.Data.Entity.UserProfile
{
    public class PatientProfile: Profile
    {
        public string AllergicReactions { get; set; }

        public string BloodGroup { get; set; }

        public List<Relative> Relatives { get; set; }
    }
}
