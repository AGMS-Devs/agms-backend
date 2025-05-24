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
        // ============================================================================
        // BILGISAYAR MÜHENDİSLİĞİ ÖĞRENCİLERİ - CengList1Id
        // ============================================================================
        
        // StudentUserId - FULLY APPROVED (Mezun olabilir)
        yield return new GraduationProcess
        {
            Id = Guid.NewGuid(),
            GraduationListId = GraduationListConfiguration.CengList1Id,
            StudentId = UserConfiguration.StudentUserId,
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
        
        // StudentUserId2 - FULLY APPROVED (Mezun olabilir)
        yield return new GraduationProcess
        {
            Id = Guid.NewGuid(),
            GraduationListId = GraduationListConfiguration.CengList1Id,
            StudentId = UserConfiguration.StudentUserId2,
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

        // StudentUserId3 - PARTIALLY APPROVED (Mezuniyet süreci devam ediyor)
        yield return new GraduationProcess
        {
            Id = Guid.NewGuid(),
            GraduationListId = GraduationListConfiguration.CengList1Id,
            StudentId = UserConfiguration.StudentUserId3,
            AdvisorApproved = true,
            AdvisorApprovedDate = DateTime.UtcNow,
            DepartmentSecretaryApproved = true,
            DepartmentSecretaryApprovedDate = DateTime.UtcNow,
            FacultyDeansOfficeApproved = false,
            StudentAffairsApproved = false,
            CreatedDate = DateTime.UtcNow
        };

        // StudentUserId4 - FULLY APPROVED (Mezun olabilir)
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

        // StudentUserId5 - NOT APPROVED (Henüz mezun olamaz)
        yield return new GraduationProcess
        {
            Id = Guid.NewGuid(),
            GraduationListId = GraduationListConfiguration.CengList1Id,
            StudentId = UserConfiguration.StudentUserId5,
            AdvisorApproved = false,
            DepartmentSecretaryApproved = false,
            FacultyDeansOfficeApproved = false,
            StudentAffairsApproved = false,
            CreatedDate = DateTime.UtcNow
        };

        // StudentUserId6 - FULLY APPROVED (Mezun olabilir)
        yield return new GraduationProcess
        {
            Id = Guid.NewGuid(),
            GraduationListId = GraduationListConfiguration.CengList1Id,
            StudentId = UserConfiguration.StudentUserId6,
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

        // ============================================================================
        // ELEKTRİK-ELEKTRONİK MÜHENDİSLİĞİ ÖĞRENCİLERİ - EeList1Id
        // ============================================================================

        // StudentUserId7 - PARTIALLY APPROVED (Mezuniyet süreci devam ediyor)
        yield return new GraduationProcess
        {
            Id = Guid.NewGuid(),
            GraduationListId = GraduationListConfiguration.EeList1Id,
            StudentId = UserConfiguration.StudentUserId7,
            AdvisorApproved = true,
            AdvisorApprovedDate = DateTime.UtcNow,
            DepartmentSecretaryApproved = false,
            FacultyDeansOfficeApproved = false,
            StudentAffairsApproved = false,
            CreatedDate = DateTime.UtcNow
        };

        // StudentUserId8 - FULLY APPROVED (Mezun olabilir)
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

        // StudentUserId9 - FULLY APPROVED (Mezun olabilir)
        yield return new GraduationProcess
        {
            Id = Guid.NewGuid(),
            GraduationListId = GraduationListConfiguration.EeList1Id,
            StudentId = UserConfiguration.StudentUserId9,
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

        // StudentUserId10 - NOT APPROVED (Henüz mezun olamaz)
        yield return new GraduationProcess
        {
            Id = Guid.NewGuid(),
            GraduationListId = GraduationListConfiguration.EeList1Id,
            StudentId = UserConfiguration.StudentUserId10,
            AdvisorApproved = false,
            DepartmentSecretaryApproved = false,
            FacultyDeansOfficeApproved = false,
            StudentAffairsApproved = false,
            CreatedDate = DateTime.UtcNow
        };

        // ============================================================================
        // FİZİK BÖLÜMÜ ÖĞRENCİLERİ - PhysList1Id
        // ============================================================================

        // StudentUserId11 - NOT APPROVED (Henüz mezun olamaz)
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

        // StudentUserId12 - PARTIALLY APPROVED (Mezuniyet süreci devam ediyor)
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

        // ============================================================================
        // KİMYA BÖLÜMÜ ÖĞRENCİLERİ - ChemList1Id
        // ============================================================================

        // StudentUserId13 - NOT APPROVED (Henüz mezun olamaz)
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

        // StudentUserId14 - NOT APPROVED (Henüz mezun olamaz)
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

        // ============================================================================
        // MATEMATİK BÖLÜMÜ ÖĞRENCİLERİ - MathList1Id
        // ============================================================================

        // StudentUserId15 - NOT APPROVED (Henüz mezun olamaz)
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

        // StudentUserId16 - NOT APPROVED (Henüz mezun olamaz)
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

        // ============================================================================
        // MAKİNE MÜHENDİSLİĞİ ÖĞRENCİLERİ - MeList1Id
        // ============================================================================

        // StudentUserId17 - NOT APPROVED (Henüz mezun olamaz)
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

        // StudentUserId18 - NOT APPROVED (Henüz mezun olamaz)
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

        // ============================================================================
        // EK ÖĞRENCILER - ÇEŞİTLİ BÖLÜMLER
        // ============================================================================

        // StudentUserId19 - FULLY APPROVED (Bilgisayar Mühendisliği - Mezun olabilir)
        yield return new GraduationProcess
        {
            Id = Guid.NewGuid(),
            GraduationListId = GraduationListConfiguration.CengList1Id,
            StudentId = UserConfiguration.StudentUserId19,
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

        // StudentUserId20 - FULLY APPROVED (Elektrik-Elektronik Mühendisliği - Mezun olabilir)
        yield return new GraduationProcess
        {
            Id = Guid.NewGuid(),
            GraduationListId = GraduationListConfiguration.EeList1Id,
            StudentId = UserConfiguration.StudentUserId20,
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

        // StudentUserId21 - PARTIALLY APPROVED (Fizik Bölümü - Mezuniyet süreci devam ediyor)
        yield return new GraduationProcess
        {
            Id = Guid.NewGuid(),
            GraduationListId = GraduationListConfiguration.PhysList1Id,
            StudentId = UserConfiguration.StudentUserId21,
            AdvisorApproved = true,
            AdvisorApprovedDate = DateTime.UtcNow,
            DepartmentSecretaryApproved = true,
            DepartmentSecretaryApprovedDate = DateTime.UtcNow,
            FacultyDeansOfficeApproved = true,
            FacultyDeansOfficeApprovedDate = DateTime.UtcNow,
            StudentAffairsApproved = false,
            CreatedDate = DateTime.UtcNow
        };

        // StudentUserId22 - FULLY APPROVED (Fizik Bölümü - Mezun olabilir)
        yield return new GraduationProcess
        {
            Id = Guid.NewGuid(),
            GraduationListId = GraduationListConfiguration.PhysList1Id,
            StudentId = UserConfiguration.StudentUserId22,
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

        // StudentUserId23 - FULLY APPROVED (Kimya Bölümü - Mezun olabilir)
        yield return new GraduationProcess
        {
            Id = Guid.NewGuid(),
            GraduationListId = GraduationListConfiguration.ChemList1Id,
            StudentId = UserConfiguration.StudentUserId23,
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

        // StudentUserId24 - PARTIALLY APPROVED (Matematik Bölümü - Mezuniyet süreci devam ediyor)
        yield return new GraduationProcess
        {
            Id = Guid.NewGuid(),
            GraduationListId = GraduationListConfiguration.MathList1Id,
            StudentId = UserConfiguration.StudentUserId24,
            AdvisorApproved = true,
            AdvisorApprovedDate = DateTime.UtcNow,
            DepartmentSecretaryApproved = false,
            FacultyDeansOfficeApproved = false,
            StudentAffairsApproved = false,
            CreatedDate = DateTime.UtcNow
        };

        // StudentUserId25 - FULLY APPROVED (Makine Mühendisliği - Mezun olabilir)
        yield return new GraduationProcess
        {
            Id = Guid.NewGuid(),
            GraduationListId = GraduationListConfiguration.MeList1Id,
            StudentId = UserConfiguration.StudentUserId25,
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

        // StudentUserId26 - FULLY APPROVED (Matematik Bölümü - Mezun olabilir)
        yield return new GraduationProcess
        {
            Id = Guid.NewGuid(),
            GraduationListId = GraduationListConfiguration.MathList1Id,
            StudentId = UserConfiguration.StudentUserId26,
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
    }
}