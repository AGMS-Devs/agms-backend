using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class RectorateConfiguration : IEntityTypeConfiguration<Rectorate>
{
    public void Configure(EntityTypeBuilder<Rectorate> builder)
    {
        builder.ToTable("Rectorates").HasKey(r => r.Id);

        builder.Property(r => r.Id).HasColumnName("Id").IsRequired();
        builder.Property(r => r.StudentAffairId).HasColumnName("StudentAffairId");
        builder.Property(r => r.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(r => r.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(r => r.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(r => !r.DeletedDate.HasValue);
    }
}