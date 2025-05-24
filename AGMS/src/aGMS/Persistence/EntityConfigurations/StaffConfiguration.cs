using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class StaffConfiguration : IEntityTypeConfiguration<Staff>
{
    public void Configure(EntityTypeBuilder<Staff> builder)
    {
        builder.ToTable("Staffs").HasKey(s => s.Id);

        builder.Property(s => s.Id).HasColumnName("Id").IsRequired();
        builder.Property(s => s.StaffPhone).HasColumnName("StaffPhone").IsRequired();
        builder.Property(s => s.StaffRole).HasColumnName("StaffRole").IsRequired();
        builder.Property(s => s.DepartmentId).HasColumnName("DepartmentId");
        builder.Property(s => s.FacultyId).HasColumnName("FacultyId");
        builder.Property(s => s.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(s => s.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(s => s.DeletedDate).HasColumnName("DeletedDate");

        builder.HasOne(s => s.User)
            .WithOne(u => u.StaffProfile)
            .HasForeignKey<Staff>(s => s.Id);

        builder.HasQueryFilter(s => !s.DeletedDate.HasValue);

        builder.HasData(GetSeeds());
    }

    private IEnumerable<Staff> GetSeeds()
    {
        // Öğrenci İşleri Personeli
        yield return new Staff
        {
            Id = UserConfiguration.StudentAffairsStaffUserId,
            StaffPhone = "232-750-5001",
            StaffRole = StaffRole.StudentAffairs,
            CreatedDate = DateTime.UtcNow
        };

        // Bölüm Sekreterleri
        // Bilgisayar Mühendisliği Bölüm Sekreteri
        yield return new Staff
        {
            Id = UserConfiguration.DepartmentSecretaryUserId,
            StaffPhone = "232-750-7004",
            StaffRole = StaffRole.DepartmentSecretary,
            DepartmentId = DepartmentConfiguration.ComputerEngineeringDepartmentId,
            CreatedDate = DateTime.UtcNow
        };

        // Elektrik-Elektronik Mühendisliği Bölüm Sekreteri
        yield return new Staff
        {
            Id = UserConfiguration.ElectricalEngineeringDepartmentSecretaryUserId,
            StaffPhone = "232-750-7005",
            StaffRole = StaffRole.DepartmentSecretary,
            DepartmentId = DepartmentConfiguration.ElectricalEngineeringDepartmentId,
            CreatedDate = DateTime.UtcNow
        };

        // Fizik Bölümü Sekreteri
        yield return new Staff
        {
            Id = UserConfiguration.PhysicsDepartmentSecretaryUserId,
            StaffPhone = "232-750-6004",
            StaffRole = StaffRole.DepartmentSecretary,
            DepartmentId = DepartmentConfiguration.PhysicsDepartmentId,
            CreatedDate = DateTime.UtcNow
        };

        // Dekanlık Personeli
        // Mühendislik Fakültesi Dekanlık Personeli
        yield return new Staff
        {
            Id = UserConfiguration.DeansOfficeStaffUserId,
            StaffPhone = "232-750-5002",
            StaffRole = StaffRole.FacultyDeansOffice,
            FacultyId = FacultyDeansOfficeConfiguration.EngineeringFacultyId,
            CreatedDate = DateTime.UtcNow
        };

        // Fen Fakültesi Dekanlık Personeli
        yield return new Staff
        {
            Id = UserConfiguration.ScienceFacultyDeansOfficeStaffUserId,
            StaffPhone = "232-750-6002",
            StaffRole = StaffRole.FacultyDeansOffice,
            FacultyId = FacultyDeansOfficeConfiguration.ScienceFacultyId,
            CreatedDate = DateTime.UtcNow
        };

        // Rektörlük Personeli
        yield return new Staff
        {
            Id = UserConfiguration.RectorateStaffUserId,
            StaffPhone = "232-750-1001",
            StaffRole = StaffRole.Rectorate,
            CreatedDate = DateTime.UtcNow
        };
    }
}