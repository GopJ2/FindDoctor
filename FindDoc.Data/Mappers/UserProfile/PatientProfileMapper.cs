using System;
using FindDoc.Data.Entity.UserProfile;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindDoc.Data.Mappers.UserProfile
{
    public class PatientProfileMapper: IEntityTypeConfiguration<PatientProfile>
    {
        public void Configure(EntityTypeBuilder<PatientProfile> builder)
        {
            builder
                .ToTable("PatientProfiles");
        }
    }
}
