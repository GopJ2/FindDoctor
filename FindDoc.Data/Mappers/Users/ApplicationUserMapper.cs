using System;
using FindDoc.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FindDoc.Data.Entity.UserProfile;
using FindDoc.Data.Entity.Appointments;
using System.Collections.Generic;

namespace FindDoc.Data.Mappers.Users
{
    public class ApplicationUserMapper: IEntityTypeConfiguration<ApplicationUser>
    { 
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder
                .HasOne<Profile>(u => u.UserProfile)
                .WithOne(p => p.ApplicationUser)
                .HasForeignKey<ApplicationUser>(u => u.UserProfileId);

            builder.OwnsMany<Appointment>(x => x.Appointments, a =>
            {
                a.WithOwner().HasForeignKey("DoctorId");
            });
        }
    }
}