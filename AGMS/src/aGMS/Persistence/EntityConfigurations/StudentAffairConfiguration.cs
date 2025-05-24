using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class StudentAffairConfiguration : IEntityTypeConfiguration<StudentAffair>
{
    public void Configure(EntityTypeBuilder<StudentAffair> builder)
    {
        builder.ToTable("StudentAffairs").HasKey(sa => sa.Id);

        builder.Property(sa => sa.Id).HasColumnName("Id").IsRequired();
        builder.Property(sa => sa.OfficeName).HasColumnName("OfficeName").IsRequired();
        builder.Property(sa => sa.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(sa => sa.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(sa => sa.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(sa => !sa.DeletedDate.HasValue);

        builder.HasData(GetSeeds());
    }

    public static Guid StudentAffairId { get; } = new Guid("11111111-1111-1111-1111-111111111111");

    private IEnumerable<StudentAffair> GetSeeds()
    {
        yield return new StudentAffair
        {
            Id = StudentAffairId,
            OfficeName = "İYTE Öğrenci İşleri Daire Başkanlığı",
            CreatedDate = DateTime.UtcNow
        };
    }
}