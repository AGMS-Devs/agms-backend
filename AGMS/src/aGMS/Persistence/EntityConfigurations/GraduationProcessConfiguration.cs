using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class GraduationProcessConfiguration : IEntityTypeConfiguration<GraduationProcess>
{
    public void Configure(EntityTypeBuilder<GraduationProcess> builder)
    {
        builder.ToTable("GraduationProcesses").HasKey(gp => gp.Id);

        builder.Property(gp => gp.Id).HasColumnName("Id").IsRequired();
        builder.Property(gp => gp.GraduationListId).HasColumnName("GraduationListId").IsRequired();
        builder.Property(gp => gp.StudentId).HasColumnName("StudentId").IsRequired();
        builder.Property(gp => gp.AdvisorApproved).HasColumnName("AdvisorApproved").IsRequired();
        builder.Property(gp => gp.AdvisorApprovedDate).HasColumnName("AdvisorApprovedDate");
        builder.Property(gp => gp.DepartmentSecretaryApproved).HasColumnName("DepartmentSecretaryApproved").IsRequired();
        builder.Property(gp => gp.DepartmentSecretaryApprovedDate).HasColumnName("DepartmentSecretaryApprovedDate");
        builder.Property(gp => gp.FacultyDeansOfficeApproved).HasColumnName("FacultyDeansOfficeApproved").IsRequired();
        builder.Property(gp => gp.FacultyDeansOfficeApprovedDate).HasColumnName("FacultyDeansOfficeApprovedDate");
        builder.Property(gp => gp.StudentAffairsApproved).HasColumnName("StudentAffairsApproved").IsRequired();
        builder.Property(gp => gp.StudentAffairsApprovedDate).HasColumnName("StudentAffairsApprovedDate");
        builder.Property(gp => gp.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(gp => gp.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(gp => gp.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(gp => !gp.DeletedDate.HasValue);

        builder.HasOne(gp => gp.GraduationList)
               .WithMany(gl => gl.GraduationProcesses)
               .HasForeignKey(gp => gp.GraduationListId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(gp => gp.StudentUser)
               .WithMany()
               .HasForeignKey(gp => gp.StudentId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasData(GetSeeds());
    }

    private IEnumerable<GraduationProcess> GetSeeds()
    {
        // Bilgisayar Mühendisliği Öğrencileri
        // 4. Sınıf - Mezun olabilir durumda
        yield return new GraduationProcess
        {
            Id = Guid.NewGuid(),
            GraduationListId = GraduationListConfiguration.CengList1Id,
            StudentId = UserConfiguration.StudentUserId4,
            AdvisorApproved = true,
            AdvisorApprovedDate = DateTime.UtcNow,
            DepartmentSecretaryApproved = true,
            DepartmentSecretaryApprovedDate = DateTime.UtcNow,
            FacultyDeansOfficeApproved = true,
            FacultyDeansOfficeApprovedDate = DateTime.UtcNow,
            StudentAffairsApproved = true,
            StudentAffairsApprovedDate = DateTime.UtcNow,
            CreatedDate = DateTime.UtcNow
        };

        // 3. Sınıf - Henüz mezun olamaz
        yield return new GraduationProcess
        {
            Id = Guid.NewGuid(),
            GraduationListId = GraduationListConfiguration.CengList1Id,
            StudentId = UserConfiguration.StudentUserId3,
            AdvisorApproved = false,
            DepartmentSecretaryApproved = false,
            FacultyDeansOfficeApproved = false,
            StudentAffairsApproved = false,
            CreatedDate = DateTime.UtcNow
        };

        // Elektrik-Elektronik Mühendisliği Öğrencileri
        // 4. Sınıf - Mezun olabilir durumda
        yield return new GraduationProcess
        {
            Id = Guid.NewGuid(),
            GraduationListId = GraduationListConfiguration.EeList1Id,
            StudentId = UserConfiguration.StudentUserId8,
            AdvisorApproved = true,
            AdvisorApprovedDate = DateTime.UtcNow,
            DepartmentSecretaryApproved = true,
            DepartmentSecretaryApprovedDate = DateTime.UtcNow,
            FacultyDeansOfficeApproved = true,
            FacultyDeansOfficeApprovedDate = DateTime.UtcNow,
            StudentAffairsApproved = true,
            StudentAffairsApprovedDate = DateTime.UtcNow,
            CreatedDate = DateTime.UtcNow
        };

        // 3. Sınıf - Henüz mezun olamaz
        yield return new GraduationProcess
        {
            Id = Guid.NewGuid(),
            GraduationListId = GraduationListConfiguration.EeList1Id,
            StudentId = UserConfiguration.StudentUserId7,
            AdvisorApproved = false,
            DepartmentSecretaryApproved = false,
            FacultyDeansOfficeApproved = false,
            StudentAffairsApproved = false,
            CreatedDate = DateTime.UtcNow
        };

        // Fizik Bölümü Öğrencileri
        // 4. Sınıf - Mezuniyet süreci devam ediyor
        yield return new GraduationProcess
        {
            Id = Guid.NewGuid(),
            GraduationListId = GraduationListConfiguration.PhysList1Id,
            StudentId = UserConfiguration.StudentUserId12,
            AdvisorApproved = true,
            AdvisorApprovedDate = DateTime.UtcNow,
            DepartmentSecretaryApproved = true,
            DepartmentSecretaryApprovedDate = DateTime.UtcNow,
            FacultyDeansOfficeApproved = false,
            StudentAffairsApproved = false,
            CreatedDate = DateTime.UtcNow
        };

        // 3. Sınıf - Henüz mezun olamaz
        yield return new GraduationProcess
        {
            Id = Guid.NewGuid(),
            GraduationListId = GraduationListConfiguration.PhysList1Id,
            StudentId = UserConfiguration.StudentUserId11,
            AdvisorApproved = false,
            DepartmentSecretaryApproved = false,
            FacultyDeansOfficeApproved = false,
            StudentAffairsApproved = false,
            CreatedDate = DateTime.UtcNow
        };

        // Kimya Bölümü Öğrencileri
        // 2. Sınıf - Henüz mezun olamaz
        yield return new GraduationProcess
        {
            Id = Guid.NewGuid(),
            GraduationListId = GraduationListConfiguration.ChemList1Id,
            StudentId = UserConfiguration.StudentUserId14,
            AdvisorApproved = false,
            DepartmentSecretaryApproved = false,
            FacultyDeansOfficeApproved = false,
            StudentAffairsApproved = false,
            CreatedDate = DateTime.UtcNow
        };

        // 1. Sınıf - Henüz mezun olamaz
        yield return new GraduationProcess
        {
            Id = Guid.NewGuid(),
            GraduationListId = GraduationListConfiguration.ChemList1Id,
            StudentId = UserConfiguration.StudentUserId13,
            AdvisorApproved = false,
            DepartmentSecretaryApproved = false,
            FacultyDeansOfficeApproved = false,
            StudentAffairsApproved = false,
            CreatedDate = DateTime.UtcNow
        };

        // Matematik Bölümü Öğrencileri
        // 2. Sınıf - Henüz mezun olamaz
        yield return new GraduationProcess
        {
            Id = Guid.NewGuid(),
            GraduationListId = GraduationListConfiguration.MathList1Id,
            StudentId = UserConfiguration.StudentUserId16,
            AdvisorApproved = false,
            DepartmentSecretaryApproved = false,
            FacultyDeansOfficeApproved = false,
            StudentAffairsApproved = false,
            CreatedDate = DateTime.UtcNow
        };

        // 1. Sınıf - Henüz mezun olamaz
        yield return new GraduationProcess
        {
            Id = Guid.NewGuid(),
            GraduationListId = GraduationListConfiguration.MathList1Id,
            StudentId = UserConfiguration.StudentUserId15,
            AdvisorApproved = false,
            DepartmentSecretaryApproved = false,
            FacultyDeansOfficeApproved = false,
            StudentAffairsApproved = false,
            CreatedDate = DateTime.UtcNow
        };

        // Makine Mühendisliği Öğrencileri
        // 2. Sınıf - Henüz mezun olamaz
        yield return new GraduationProcess
        {
            Id = Guid.NewGuid(),
            GraduationListId = GraduationListConfiguration.MeList1Id,
            StudentId = UserConfiguration.StudentUserId18,
            AdvisorApproved = false,
            DepartmentSecretaryApproved = false,
            FacultyDeansOfficeApproved = false,
            StudentAffairsApproved = false,
            CreatedDate = DateTime.UtcNow
        };

        // 1. Sınıf - Henüz mezun olamaz
        yield return new GraduationProcess
        {
            Id = Guid.NewGuid(),
            GraduationListId = GraduationListConfiguration.MeList1Id,
            StudentId = UserConfiguration.StudentUserId17,
            AdvisorApproved = false,
            DepartmentSecretaryApproved = false,
            FacultyDeansOfficeApproved = false,
            StudentAffairsApproved = false,
            CreatedDate = DateTime.UtcNow
        };
    }
}