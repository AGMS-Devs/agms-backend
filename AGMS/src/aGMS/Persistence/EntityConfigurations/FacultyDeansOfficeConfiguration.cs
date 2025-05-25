using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class FacultyDeansOfficeConfiguration : IEntityTypeConfiguration<FacultyDeansOffice>
{
    public void Configure(EntityTypeBuilder<FacultyDeansOffice> builder)
    {
        builder.ToTable("FacultyDeansOffices").HasKey(fdo => fdo.Id);

        builder.Property(fdo => fdo.Id).HasColumnName("Id").IsRequired();
        builder.Property(fdo => fdo.FacultyName).HasColumnName("FacultyName").IsRequired();
        builder.Property(fdo => fdo.StudentAffairId).HasColumnName("StudentAffairId").IsRequired();
        builder.Property(fdo => fdo.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(fdo => fdo.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(fdo => fdo.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(fdo => !fdo.DeletedDate.HasValue);

        builder.HasOne(fdo => fdo.StudentAffair)
               .WithMany(sa => sa.FacultyDeansOffices)
               .HasForeignKey(fdo => fdo.StudentAffairId);

        builder.HasMany(fdo => fdo.Departments)
               .WithOne(d => d.FacultyDeansOffice)
               .HasForeignKey(d => d.FacultyId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasData(GetSeeds());
    }

    public static Guid ScienceFacultyId { get; } = new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa");
    public static Guid EngineeringFacultyId { get; } = new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb");

    private IEnumerable<FacultyDeansOffice> GetSeeds()
    {
        // Fen Fakültesi
        yield return new FacultyDeansOffice
        {
            Id = ScienceFacultyId,
            FacultyName = "Fen Fakültesi",
            StudentAffairId = StudentAffairConfiguration.StudentAffairId,
            CreatedDate = DateTime.UtcNow
            
        };

        // Mühendislik Fakültesi
        yield return new FacultyDeansOffice
        {
            Id = EngineeringFacultyId,
            FacultyName = "Mühendislik Fakültesi",
            StudentAffairId = StudentAffairConfiguration.StudentAffairId,
            CreatedDate = DateTime.UtcNow
        };
    }
}