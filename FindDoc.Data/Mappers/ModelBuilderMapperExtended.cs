using System;
using FindDoc.Data.Mappers.UserProfile;
using FindDoc.Data.Mappers.Users;
using Microsoft.EntityFrameworkCore;

namespace FindDoc.Data.Mappers
{
    public static class ModelBuilderMapperExtended
    {
       public static void ConfigureMappers(this ModelBuilder modelBuilder)
       {
            modelBuilder.ApplyConfiguration(new ProfileMapper());
            modelBuilder.ApplyConfiguration(new ApplicationUserMapper());
        }
    }
}
