using System;
namespace FindDoc.Data.Entity.UserProfile
{
    public class Profile
    {
        public string ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
    }
}
