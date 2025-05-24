using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class CeremonyConfiguration : IEntityTypeConfiguration<Ceremony>
{
    public void Configure(EntityTypeBuilder<Ceremony> builder)
    {
        builder.ToTable("Ceremonies").HasKey(c => c.Id);

        builder.Property(c => c.Id).HasColumnName("Id").IsRequired();
        builder.Property(c => c.CeremonyDate).HasColumnName("CeremonyDate");
        builder.Property(c => c.CeremonyLocation).HasColumnName("CeremonyLocation");
        builder.Property(c => c.CeremonyDescription).HasColumnName("CeremonyDescription");
        builder.Property(c => c.CeremonyStatus).HasColumnName("CeremonyStatus");
        builder.Property(c => c.AcademicYear).HasColumnName("AcademicYear");
        builder.Property(c => c.StudentAffairId).HasColumnName("StudentAffairId");
        builder.Property(c => c.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(c => c.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(c => c.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(c => !c.DeletedDate.HasValue);
    }
}