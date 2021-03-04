using System;
using FindDoc.Data.Entity;
using FindDoc.Data.Entity.Appointments;
using FindDoc.Data.Entity.UserProfile;
using FindDoc.Data.Entity.Users;
using FindDoc.Data.Mappers;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FindDoc.Data.Context
{
    public class ApplicationDbContext: IdentityDbContext
    {

        public ApplicationDbContext(DbContextOptions options): base(options)
        {
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public DbSet<DoctorProfile> DoctorProfiles { get; set; }

        public DbSet<PatientProfile> PatientProfiles { get; set; }

        public DbSet<Appointment> Appointments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ConfigureMappers();
            base.OnModelCreating(modelBuilder);
        }
    }
}
