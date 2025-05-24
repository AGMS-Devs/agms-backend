using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.ToTable("Departments").HasKey(d => d.Id);

        builder.Property(d => d.Id).HasColumnName("Id").IsRequired();
        builder.Property(d => d.DepartmentName).HasColumnName("DepartmentName").IsRequired();
        builder.Property(d => d.DepartmentPhone).HasColumnName("DepartmentPhone").IsRequired();
        builder.Property(d => d.FacultyId).HasColumnName("FacultyId").IsRequired();
        builder.Property(d => d.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(d => d.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(d => d.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(d => !d.DeletedDate.HasValue);

        builder.HasOne(d => d.FacultyDeansOffice)
               .WithMany(fdo => fdo.Departments)
               .HasForeignKey(d => d.FacultyId);

        builder.HasData(GetSeeds());
    }

    // Fen Fakültesi Bölümleri
    public static Guid PhysicsDepartmentId { get; } = new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc");
    public static Guid ChemistryDepartmentId { get; } = new Guid("dddddddd-dddd-dddd-dddd-dddddddddddd");
    public static Guid MathematicsDepartmentId { get; } = new Guid("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee");

    // Mühendislik Fakültesi Bölümleri
    public static Guid ComputerEngineeringDepartmentId { get; } = new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff");
    public static Guid ElectricalEngineeringDepartmentId { get; } = new Guid("11111111-2222-3333-4444-555555555555");
    public static Guid MechanicalEngineeringDepartmentId { get; } = new Guid("22222222-3333-4444-5555-666666666666");

    private IEnumerable<Department> GetSeeds()
    {
        // Fen Fakültesi Bölümleri
        yield return new Department
        {
            Id = PhysicsDepartmentId,
            DepartmentName = "Fizik Bölümü",
            DepartmentPhone = "232-750-6001",
            FacultyId = FacultyDeansOfficeConfiguration.ScienceFacultyId,
            CreatedDate = DateTime.UtcNow
        };

        yield return new Department
        {
            Id = ChemistryDepartmentId,
            DepartmentName = "Kimya Bölümü",
            DepartmentPhone = "232-750-6002",
            FacultyId = FacultyDeansOfficeConfiguration.ScienceFacultyId,
            CreatedDate = DateTime.UtcNow
        };

        yield return new Department
        {
            Id = MathematicsDepartmentId,
            DepartmentName = "Matematik Bölümü",
            DepartmentPhone = "232-750-6003",
            FacultyId = FacultyDeansOfficeConfiguration.ScienceFacultyId,
            CreatedDate = DateTime.UtcNow
        };

        // Mühendislik Fakültesi Bölümleri
        yield return new Department
        {
            Id = ComputerEngineeringDepartmentId,
            DepartmentName = "Bilgisayar Mühendisliği",
            DepartmentPhone = "232-750-7001",
            FacultyId = FacultyDeansOfficeConfiguration.EngineeringFacultyId,
            CreatedDate = DateTime.UtcNow
        };

        yield return new Department
        {
            Id = ElectricalEngineeringDepartmentId,
            DepartmentName = "Elektrik-Elektronik Mühendisliği",
            DepartmentPhone = "232-750-7002",
            FacultyId = FacultyDeansOfficeConfiguration.EngineeringFacultyId,
            CreatedDate = DateTime.UtcNow
        };

        yield return new Department
        {
            Id = MechanicalEngineeringDepartmentId,
            DepartmentName = "Makine Mühendisliği",
            DepartmentPhone = "232-750-7003",
            FacultyId = FacultyDeansOfficeConfiguration.EngineeringFacultyId,
            CreatedDate = DateTime.UtcNow
        };
    }
}