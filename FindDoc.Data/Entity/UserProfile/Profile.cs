using System;
namespace FindDoc.Data.Entity.UserProfile
{
    public abstract class Profile
    {
        public string Id { get; set; }

        public string Avatar { get; set; }

        public string City { get; set; }

        public string Age { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Instagram { get; set; }

        public string Facebook { get; set; }

        public string Twitter { get; set; }

        public string VK { get; set; }

        public string ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
    }
}
