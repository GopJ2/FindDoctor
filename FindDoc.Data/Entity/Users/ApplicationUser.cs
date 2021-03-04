using System;
using System.Collections.Generic;
using FindDoc.Data.Entity.Appointments;
using FindDoc.Data.Entity.UserProfile;
using Microsoft.AspNetCore.Identity;

namespace FindDoc.Data.Entity
{
    public class ApplicationUser: IdentityUser
    {
        public string UserProfileId { get; set; }

        public Profile UserProfile { get; set; }

        public List<Appointment> Appointments { get; set; }
    }
}


