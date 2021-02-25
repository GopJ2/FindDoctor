using System;
using FindDoc.Data.Entity.UserProfile;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindDoc.Data.Mappers.UserProfile
{
    public class ProfileMapper: IEntityTypeConfiguration<Profile>
    {
        public void Configure(EntityTypeBuilder<Profile> builder)
        {
            builder
                .HasKey(p => p.ApplicationUserId);
        }
    }
}
