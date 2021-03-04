using System;
using FindDoc.Data.Entity.UserProfile;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindDoc.Data.Mappers.UserProfile
{
    public class DoctorProfileMapper : IEntityTypeConfiguration<DoctorProfile>
    {
        public void Configure(EntityTypeBuilder<DoctorProfile> builder)
        {
            builder
                .ToTable("DoctorProfiles");
        }
    }
}
