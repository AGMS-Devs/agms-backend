using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class TranscriptConfiguration : IEntityTypeConfiguration<Transcript>
{
    public void Configure(EntityTypeBuilder<Transcript> builder)
    {
        builder.ToTable("Transcripts").HasKey(t => t.Id);

        builder.Property(t => t.Id).HasColumnName("Id").IsRequired();
        builder.Property(t => t.StudentIdentityNumber).HasColumnName("StudentIdentityNumber");
        builder.Property(t => t.TranscriptFileName).HasColumnName("TranscriptFileName");
        builder.Property(t => t.TranscriptGpa).HasColumnName("TranscriptGpa");
        builder.Property(t => t.TranscriptDate).HasColumnName("TranscriptDate");
        builder.Property(t => t.TranscriptDescription).HasColumnName("TranscriptDescription");
        builder.Property(t => t.DepartmentGraduationRank).HasColumnName("DepartmentGraduationRank");
        builder.Property(t => t.FacultyGraduationRank).HasColumnName("FacultyGraduationRank");
        builder.Property(t => t.UniversityGraduationRank).HasColumnName("UniversityGraduationRank");
        builder.Property(t => t.GraduationYear).HasColumnName("GraduationYear");
        builder.Property(t => t.TotalTakenCredit).HasColumnName("TotalTakenCredit");
        builder.Property(t => t.TotalRequiredCredit).HasColumnName("TotalRequiredCredit");
        builder.Property(t => t.CompletedCredit).HasColumnName("CompletedCredit");
        builder.Property(t => t.RemainingCredit).HasColumnName("RemainingCredit");
        builder.Property(t => t.RequiredCourseCount).HasColumnName("RequiredCourseCount");
        builder.Property(t => t.CompletedCourseCount).HasColumnName("CompletedCourseCount");
        builder.Property(t => t.StudentId).HasColumnName("StudentId");
        builder.Property(t => t.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(t => t.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(t => t.DeletedDate).HasColumnName("DeletedDate");

        builder.HasOne(t => t.FileAttachment)
            .WithOne(fa => fa.Transcript)
            .HasForeignKey<FileAttachment>(fa => fa.TranscriptId);

        builder.HasQueryFilter(t => !t.DeletedDate.HasValue);

        builder.HasData(GetSeeds());
    }

    private IEnumerable<Transcript> GetSeeds()
    {
        // Bilgisayar Mühendisliği Öğrencileri Transcript'leri (Yüksek GPA'lar)
        yield return new Transcript
        {
            Id = Guid.NewGuid(),
            StudentId = UserConfiguration.StudentUserId,
            StudentIdentityNumber = "12345678901",
            TranscriptFileName = "transcript_2023001.pdf",
            TranscriptGpa = 3.95m,
            TranscriptDate = DateTime.UtcNow.AddDays(-30),
            TranscriptDescription = "Mezuniyet transkripti",
            DepartmentGraduationRank = "1",
            FacultyGraduationRank = "1",
            UniversityGraduationRank = "1",
            GraduationYear = "2024",
            TotalTakenCredit = 240,
            TotalRequiredCredit = 240,
            CompletedCredit = 240,
            RemainingCredit = 0,
            RequiredCourseCount = 24,
            CompletedCourseCount = 24,
            CreatedDate = DateTime.UtcNow
        };

        yield return new Transcript
        {
            Id = Guid.NewGuid(),
            StudentId = UserConfiguration.StudentUserId2,
            StudentIdentityNumber = "12345678902",
            TranscriptFileName = "transcript_2023002.pdf",
            TranscriptGpa = 3.88m,
            TranscriptDate = DateTime.UtcNow.AddDays(-25),
            TranscriptDescription = "Mezuniyet transkripti",
            DepartmentGraduationRank = "2",
            FacultyGraduationRank = "3",
            UniversityGraduationRank = "5",
            GraduationYear = "2024",
            TotalTakenCredit = 240,
            TotalRequiredCredit = 240,
            CompletedCredit = 240,
            RemainingCredit = 0,
            RequiredCourseCount = 24,
            CompletedCourseCount = 24,
            CreatedDate = DateTime.UtcNow
        };

        yield return new Transcript
        {
            Id = Guid.NewGuid(),
            StudentId = UserConfiguration.StudentUserId3,
            StudentIdentityNumber = "12345678903",
            TranscriptFileName = "transcript_2023003.pdf",
            TranscriptGpa = 3.75m,
            TranscriptDate = DateTime.UtcNow.AddDays(-20),
            TranscriptDescription = "Mezuniyet transkripti",
            DepartmentGraduationRank = "3",
            FacultyGraduationRank = "6",
            UniversityGraduationRank = "12",
            GraduationYear = "2024",
            TotalTakenCredit = 240,
            TotalRequiredCredit = 240,
            CompletedCredit = 240,
            RemainingCredit = 0,
            RequiredCourseCount = 24,
            CompletedCourseCount = 24,
            CreatedDate = DateTime.UtcNow
        };

        yield return new Transcript
        {
            Id = Guid.NewGuid(),
            StudentId = UserConfiguration.StudentUserId4,
            StudentIdentityNumber = "12345678904",
            TranscriptFileName = "transcript_2023004.pdf",
            TranscriptGpa = 3.65m,
            TranscriptDate = DateTime.UtcNow.AddDays(-15),
            TranscriptDescription = "Mezuniyet transkripti",
            DepartmentGraduationRank = "4",
            FacultyGraduationRank = "8",
            UniversityGraduationRank = "18",
            GraduationYear = "2024",
            TotalTakenCredit = 240,
            TotalRequiredCredit = 240,
            CompletedCredit = 240,
            RemainingCredit = 0,
            RequiredCourseCount = 24,
            CompletedCourseCount = 24,
            CreatedDate = DateTime.UtcNow
        };

        // Elektrik-Elektronik Mühendisliği Öğrencileri Transcript'leri
        yield return new Transcript
        {
            Id = Guid.NewGuid(),
            StudentId = UserConfiguration.StudentUserId5,
            StudentIdentityNumber = "12345678905",
            TranscriptFileName = "transcript_2023005.pdf",
            TranscriptGpa = 3.92m,
            TranscriptDate = DateTime.UtcNow.AddDays(-22),
            TranscriptDescription = "Mezuniyet transkripti",
            DepartmentGraduationRank = "1",
            FacultyGraduationRank = "2",
            UniversityGraduationRank = "2",
            GraduationYear = "2024",
            TotalTakenCredit = 240,
            TotalRequiredCredit = 240,
            CompletedCredit = 240,
            RemainingCredit = 0,
            RequiredCourseCount = 24,
            CompletedCourseCount = 24,
            CreatedDate = DateTime.UtcNow
        };

        yield return new Transcript
        {
            Id = Guid.NewGuid(),
            StudentId = UserConfiguration.StudentUserId6,
            StudentIdentityNumber = "12345678906",
            TranscriptFileName = "transcript_2023006.pdf",
            TranscriptGpa = 3.78m,
            TranscriptDate = DateTime.UtcNow.AddDays(-18),
            TranscriptDescription = "Mezuniyet transkripti",
            DepartmentGraduationRank = "2",
            FacultyGraduationRank = "5",
            UniversityGraduationRank = "10",
            GraduationYear = "2024",
            TotalTakenCredit = 240,
            TotalRequiredCredit = 240,
            CompletedCredit = 240,
            RemainingCredit = 0,
            RequiredCourseCount = 24,
            CompletedCourseCount = 24,
            CreatedDate = DateTime.UtcNow
        };

        yield return new Transcript
        {
            Id = Guid.NewGuid(),
            StudentId = UserConfiguration.StudentUserId7,
            StudentIdentityNumber = "12345678907",
            TranscriptFileName = "transcript_2023007.pdf",
            TranscriptGpa = 3.68m,
            TranscriptDate = DateTime.UtcNow.AddDays(-14),
            TranscriptDescription = "Mezuniyet transkripti",
            DepartmentGraduationRank = "3",
            FacultyGraduationRank = "7",
            UniversityGraduationRank = "15",
            GraduationYear = "2024",
            TotalTakenCredit = 240,
            TotalRequiredCredit = 240,
            CompletedCredit = 240,
            RemainingCredit = 0,
            RequiredCourseCount = 24,
            CompletedCourseCount = 24,
            CreatedDate = DateTime.UtcNow
        };

        yield return new Transcript
        {
            Id = Guid.NewGuid(),
            StudentId = UserConfiguration.StudentUserId8,
            StudentIdentityNumber = "12345678908",
            TranscriptFileName = "transcript_2023008.pdf",
            TranscriptGpa = 3.55m,
            TranscriptDate = DateTime.UtcNow.AddDays(-12),
            TranscriptDescription = "Mezuniyet transkripti",
            DepartmentGraduationRank = "4",
            FacultyGraduationRank = "9",
            UniversityGraduationRank = "25",
            GraduationYear = "2024",
            TotalTakenCredit = 240,
            TotalRequiredCredit = 240,
            CompletedCredit = 240,
            RemainingCredit = 0,
            RequiredCourseCount = 24,
            CompletedCourseCount = 24,
            CreatedDate = DateTime.UtcNow
        };

        // Fizik Bölümü Öğrencileri Transcript'leri
        yield return new Transcript
        {
            Id = Guid.NewGuid(),
            StudentId = UserConfiguration.StudentUserId9,
            StudentIdentityNumber = "12345678909",
            TranscriptFileName = "transcript_2023009.pdf",
            TranscriptGpa = 3.85m,
            TranscriptDate = DateTime.UtcNow.AddDays(-28),
            TranscriptDescription = "Mezuniyet transkripti",
            DepartmentGraduationRank = "1",
            FacultyGraduationRank = "4",
            UniversityGraduationRank = "7",
            GraduationYear = "2024",
            TotalTakenCredit = 240,
            TotalRequiredCredit = 240,
            CompletedCredit = 240,
            RemainingCredit = 0,
            RequiredCourseCount = 24,
            CompletedCourseCount = 24,
            CreatedDate = DateTime.UtcNow
        };

        yield return new Transcript
        {
            Id = Guid.NewGuid(),
            StudentId = UserConfiguration.StudentUserId10,
            StudentIdentityNumber = "12345678910",
            TranscriptFileName = "transcript_2023010.pdf",
            TranscriptGpa = 3.72m,
            TranscriptDate = DateTime.UtcNow.AddDays(-16),
            TranscriptDescription = "Mezuniyet transkripti",
            DepartmentGraduationRank = "2",
            FacultyGraduationRank = "8",
            UniversityGraduationRank = "14",
            GraduationYear = "2024",
            TotalTakenCredit = 240,
            TotalRequiredCredit = 240,
            CompletedCredit = 240,
            RemainingCredit = 0,
            RequiredCourseCount = 24,
            CompletedCourseCount = 24,
            CreatedDate = DateTime.UtcNow
        };

        yield return new Transcript
        {
            Id = Guid.NewGuid(),
            StudentId = UserConfiguration.StudentUserId11,
            StudentIdentityNumber = "12345678911",
            TranscriptFileName = "transcript_2023011.pdf",
            TranscriptGpa = 3.62m,
            TranscriptDate = DateTime.UtcNow.AddDays(-11),
            TranscriptDescription = "Mezuniyet transkripti",
            DepartmentGraduationRank = "3",
            FacultyGraduationRank = "10",
            UniversityGraduationRank = "20",
            GraduationYear = "2024",
            TotalTakenCredit = 240,
            TotalRequiredCredit = 240,
            CompletedCredit = 240,
            RemainingCredit = 0,
            RequiredCourseCount = 24,
            CompletedCourseCount = 24,
            CreatedDate = DateTime.UtcNow
        };

        yield return new Transcript
        {
            Id = Guid.NewGuid(),
            StudentId = UserConfiguration.StudentUserId12,
            StudentIdentityNumber = "12345678912",
            TranscriptFileName = "transcript_2023012.pdf",
            TranscriptGpa = 3.48m,
            TranscriptDate = DateTime.UtcNow.AddDays(-9),
            TranscriptDescription = "Mezuniyet transkripti",
            DepartmentGraduationRank = "4",
            FacultyGraduationRank = "12",
            UniversityGraduationRank = "35",
            GraduationYear = "2024",
            TotalTakenCredit = 240,
            TotalRequiredCredit = 240,
            CompletedCredit = 240,
            RemainingCredit = 0,
            RequiredCourseCount = 24,
            CompletedCourseCount = 24,
            CreatedDate = DateTime.UtcNow
        };

        // Kimya Bölümü Öğrencileri Transcript'leri  
        yield return new Transcript
        {
            Id = Guid.NewGuid(),
            StudentId = UserConfiguration.StudentUserId13,
            StudentIdentityNumber = "12345678913",
            TranscriptFileName = "transcript_2023013.pdf",
            TranscriptGpa = 3.82m,
            TranscriptDate = DateTime.UtcNow.AddDays(-26),
            TranscriptDescription = "Mezuniyet transkripti",
            DepartmentGraduationRank = "1",
            FacultyGraduationRank = "6",
            UniversityGraduationRank = "8",
            GraduationYear = "2024",
            TotalTakenCredit = 240,
            TotalRequiredCredit = 240,
            CompletedCredit = 240,
            RemainingCredit = 0,
            RequiredCourseCount = 24,
            CompletedCourseCount = 24,
            CreatedDate = DateTime.UtcNow
        };

        yield return new Transcript
        {
            Id = Guid.NewGuid(),
            StudentId = UserConfiguration.StudentUserId14,
            StudentIdentityNumber = "12345678914",
            TranscriptFileName = "transcript_2023014.pdf",
            TranscriptGpa = 3.58m,
            TranscriptDate = DateTime.UtcNow.AddDays(-13),
            TranscriptDescription = "Mezuniyet transkripti",
            DepartmentGraduationRank = "2",
            FacultyGraduationRank = "11",
            UniversityGraduationRank = "23",
            GraduationYear = "2024",
            TotalTakenCredit = 240,
            TotalRequiredCredit = 240,
            CompletedCredit = 240,
            RemainingCredit = 0,
            RequiredCourseCount = 24,
            CompletedCourseCount = 24,
            CreatedDate = DateTime.UtcNow
        };

        // Matematik Bölümü Öğrencileri Transcript'leri
        yield return new Transcript
        {
            Id = Guid.NewGuid(),
            StudentId = UserConfiguration.StudentUserId15,
            StudentIdentityNumber = "12345678915",
            TranscriptFileName = "transcript_2023015.pdf",
            TranscriptGpa = 3.90m,
            TranscriptDate = DateTime.UtcNow.AddDays(-24),
            TranscriptDescription = "Mezuniyet transkripti",
            DepartmentGraduationRank = "1",
            FacultyGraduationRank = "3",
            UniversityGraduationRank = "3",
            GraduationYear = "2024",
            TotalTakenCredit = 240,
            TotalRequiredCredit = 240,
            CompletedCredit = 240,
            RemainingCredit = 0,
            RequiredCourseCount = 24,
            CompletedCourseCount = 24,
            CreatedDate = DateTime.UtcNow
        };

        yield return new Transcript
        {
            Id = Guid.NewGuid(),
            StudentId = UserConfiguration.StudentUserId16,
            StudentIdentityNumber = "12345678916",
            TranscriptFileName = "transcript_2023016.pdf",
            TranscriptGpa = 3.98m, // En yüksek GPA
            TranscriptDate = DateTime.UtcNow.AddDays(-35),
            TranscriptDescription = "Mezuniyet transkripti",
            DepartmentGraduationRank = "1",
            FacultyGraduationRank = "1",
            UniversityGraduationRank = "1",
            GraduationYear = "2024",
            TotalTakenCredit = 240,
            TotalRequiredCredit = 240,
            CompletedCredit = 240,
            RemainingCredit = 0,
            RequiredCourseCount = 24,
            CompletedCourseCount = 24,
            CreatedDate = DateTime.UtcNow
        };

        // Makine Mühendisliği Öğrencileri Transcript'leri
        yield return new Transcript
        {
            Id = Guid.NewGuid(),
            StudentId = UserConfiguration.StudentUserId17,
            StudentIdentityNumber = "12345678917",
            TranscriptFileName = "transcript_2023017.pdf",
            TranscriptGpa = 3.77m,
            TranscriptDate = DateTime.UtcNow.AddDays(-19),
            TranscriptDescription = "Mezuniyet transkripti",
            DepartmentGraduationRank = "1",
            FacultyGraduationRank = "4",
            UniversityGraduationRank = "11",
            GraduationYear = "2024",
            TotalTakenCredit = 240,
            TotalRequiredCredit = 240,
            CompletedCredit = 240,
            RemainingCredit = 0,
            RequiredCourseCount = 24,
            CompletedCourseCount = 24,
            CreatedDate = DateTime.UtcNow
        };

        yield return new Transcript
        {
            Id = Guid.NewGuid(),
            StudentId = UserConfiguration.StudentUserId18,
            StudentIdentityNumber = "12345678918",
            TranscriptFileName = "transcript_2023018.pdf",
            TranscriptGpa = 3.45m,
            TranscriptDate = DateTime.UtcNow.AddDays(-8),
            TranscriptDescription = "Mezuniyet transkripti",
            DepartmentGraduationRank = "2",
            FacultyGraduationRank = "13",
            UniversityGraduationRank = "40",
            GraduationYear = "2024",
            TotalTakenCredit = 240,
            TotalRequiredCredit = 240,
            CompletedCredit = 240,
            RemainingCredit = 0,
            RequiredCourseCount = 24,
            CompletedCourseCount = 24,
            CreatedDate = DateTime.UtcNow
        };
        yield return new Transcript
        {
            Id = Guid.NewGuid(),
            StudentId = UserConfiguration.StudentUserId19,
            StudentIdentityNumber = "12345678919",
            TranscriptFileName = "transcript_2023019.pdf",
            TranscriptGpa = 2.34m,
            TranscriptDate = DateTime.UtcNow.AddDays(-8),
            TranscriptDescription = "Mezuniyet transkripti",
            DepartmentGraduationRank = "2",
            FacultyGraduationRank = "13",
            UniversityGraduationRank = "40",
            GraduationYear = "2024",
            TotalTakenCredit = 240,
            TotalRequiredCredit = 240,
            CompletedCredit = 240,
            RemainingCredit = 0,
            RequiredCourseCount = 24,
            CompletedCourseCount = 24,
            CreatedDate = DateTime.UtcNow
        };
        yield return new Transcript
        {
            Id = Guid.NewGuid(),
            StudentId = UserConfiguration.StudentUserId20,
            StudentIdentityNumber = "12345678920",
            TranscriptFileName = "transcript_2023020.pdf",
            TranscriptGpa = 2.23m,
            TranscriptDate = DateTime.UtcNow.AddDays(-8),
            TranscriptDescription = "Mezuniyet transkripti",
            DepartmentGraduationRank = "2",
            FacultyGraduationRank = "13",
            UniversityGraduationRank = "40",
            GraduationYear = "2024",
            TotalTakenCredit = 240,
            TotalRequiredCredit = 240,
            CompletedCredit = 240,
            RemainingCredit = 0,
            RequiredCourseCount = 24,
            CompletedCourseCount = 24,
            CreatedDate = DateTime.UtcNow
        };
        yield return new Transcript
        {
            Id = Guid.NewGuid(),
            StudentId = UserConfiguration.StudentUserId21,
            StudentIdentityNumber = "12345678921",
            TranscriptFileName = "transcript_2023021.pdf",
            TranscriptGpa = 2.43m,
            TranscriptDate = DateTime.UtcNow.AddDays(-8),
            TranscriptDescription = "Mezuniyet transkripti",
            DepartmentGraduationRank = "2",
            FacultyGraduationRank = "13",
            UniversityGraduationRank = "40",
            GraduationYear = "2024",
            TotalTakenCredit = 240,
            TotalRequiredCredit = 240,
            CompletedCredit = 240,
            RemainingCredit = 0,
            RequiredCourseCount = 24,
            CompletedCourseCount = 24,
            CreatedDate = DateTime.UtcNow
        };
        yield return new Transcript
        {
            Id = Guid.NewGuid(),
            StudentId = UserConfiguration.StudentUserId22,
            StudentIdentityNumber = "12345678922",
            TranscriptFileName = "transcript_2023022.pdf",
            TranscriptGpa = 2.53m,
            TranscriptDate = DateTime.UtcNow.AddDays(-8),
            TranscriptDescription = "Mezuniyet transkripti",
            DepartmentGraduationRank = "2",
            FacultyGraduationRank = "13",
            UniversityGraduationRank = "40",
            GraduationYear = "2024",
            TotalTakenCredit = 240,
            TotalRequiredCredit = 240,
            CompletedCredit = 240,
            RemainingCredit = 0,
            RequiredCourseCount = 24,
            CompletedCourseCount = 24,
            CreatedDate = DateTime.UtcNow
        };
        yield return new Transcript
        {
            Id = Guid.NewGuid(),
            StudentId = UserConfiguration.StudentUserId23,
            StudentIdentityNumber = "12345678923",
            TranscriptFileName = "transcript_2023023.pdf",
            TranscriptGpa = 2.63m,
            TranscriptDate = DateTime.UtcNow.AddDays(-8),
            TranscriptDescription = "Mezuniyet transkripti",
            DepartmentGraduationRank = "2",
            FacultyGraduationRank = "13",
            UniversityGraduationRank = "40",
            GraduationYear = "2024",
            TotalTakenCredit = 240,
            TotalRequiredCredit = 240,
            CompletedCredit = 240,
            RemainingCredit = 0,
            RequiredCourseCount = 24,
            CompletedCourseCount = 24,
            CreatedDate = DateTime.UtcNow
        };
        yield return new Transcript
        {
            Id = Guid.NewGuid(),
            StudentId = UserConfiguration.StudentUserId24,
            StudentIdentityNumber = "12345678924",
            TranscriptFileName = "transcript_2023024.pdf",  
            TranscriptGpa = 2.73m,
            TranscriptDate = DateTime.UtcNow.AddDays(-8),
            TranscriptDescription = "Mezuniyet transkripti",
            DepartmentGraduationRank = "2",
            FacultyGraduationRank = "13",
            UniversityGraduationRank = "40",
            GraduationYear = "2024",
            TotalTakenCredit = 240,
            TotalRequiredCredit = 240,
            CompletedCredit = 240,
            RemainingCredit = 0,
            RequiredCourseCount = 24,
            CompletedCourseCount = 24,
            CreatedDate = DateTime.UtcNow
        };
        yield return new Transcript
        {
            Id = Guid.NewGuid(),
            StudentId = UserConfiguration.StudentUserId25,
            StudentIdentityNumber = "12345678925",
            TranscriptFileName = "transcript_2023025.pdf",  
            TranscriptGpa = 2.83m,
            TranscriptDate = DateTime.UtcNow.AddDays(-8),
            TranscriptDescription = "Mezuniyet transkripti",
            DepartmentGraduationRank = "2",
            FacultyGraduationRank = "13",
            UniversityGraduationRank = "40",
            GraduationYear = "2024",
            TotalTakenCredit = 240,
            TotalRequiredCredit = 240,
            CompletedCredit = 240,
            RemainingCredit = 0,
            RequiredCourseCount = 24,
            CompletedCourseCount = 24,
            CreatedDate = DateTime.UtcNow
        };
        yield return new Transcript
        {
            Id = Guid.NewGuid(),
            StudentId = UserConfiguration.StudentUserId26,
            StudentIdentityNumber = "12345678926",
            TranscriptFileName = "transcript_2023026.pdf",
            TranscriptGpa = 2.93m,
            TranscriptDate = DateTime.UtcNow.AddDays(-8),
            TranscriptDescription = "Mezuniyet transkripti",
            DepartmentGraduationRank = "2",
            FacultyGraduationRank = "13",
            UniversityGraduationRank = "40",    
            GraduationYear = "2024",
            TotalTakenCredit = 240,
            TotalRequiredCredit = 240,
            CompletedCredit = 240,
            RemainingCredit = 0,
            RequiredCourseCount = 24,
            CompletedCourseCount = 24,
            CreatedDate = DateTime.UtcNow
        };
            
        
        
        
        
        
        
        
        
        
        
        
    }
}