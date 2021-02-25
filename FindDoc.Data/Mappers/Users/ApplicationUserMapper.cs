using System;
using FindDoc.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FindDoc.Data.Entity.UserProfile;

namespace FindDoc.Data.Mappers.Users
{
    public class ApplicationUserMapper: IEntityTypeConfiguration<ApplicationUser>
    { 
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder
                .HasOne<Profile>(u => u.UserProfile)
                .WithOne(p => p.ApplicationUser);
        }
    }
}
