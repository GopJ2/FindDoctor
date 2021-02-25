using System;
using FindDoc.Data.Entity;
using FindDoc.Data.Entity.UserProfile;
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

        public DbSet<Profile> Profiles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ConfigureMappers();
            base.OnModelCreating(modelBuilder);
        }
    }
}
