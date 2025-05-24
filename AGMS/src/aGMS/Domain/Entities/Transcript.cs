using NArchitecture.Core.Persistence.Repositories;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class Transcript : Entity<Guid>
{
    public string StudentIdentityNumber { get; set; } = string.Empty;
    public string TranscriptFileName { get; set; } = string.Empty;
    public decimal TranscriptGpa { get; set; }
    public DateTime TranscriptDate { get; set; }
    public string TranscriptDescription { get; set; } = string.Empty;
    public string DepartmentGraduationRank { get; set; } = string.Empty;
    public string FacultyGraduationRank { get; set; } = string.Empty;
    public string UniversityGraduationRank { get; set; } = string.Empty;
    public string GraduationYear { get; set; } = string.Empty;
    public int TotalTakenCredit { get; set; }
    public int TotalRequiredCredit { get; set; }
    public int CompletedCredit { get; set; }
    public int RemainingCredit { get; set; } 
    public int RequiredCourseCount { get; set; }
    public int CompletedCourseCount { get; set; }

    public virtual FileAttachment FileAttachment { get; set; }


    public Guid StudentId { get; set; }
    [ForeignKey("StudentId")]
    public virtual User StudentUser { get; set; }
    

    public Transcript()
    {
    }

    public Transcript(Guid id, string studentIdentityNumber, string transcriptFileName, decimal transcriptGpa, DateTime transcriptDate, Guid studentId, string transcriptDescription, string departmentGraduationRank, string facultyGraduationRank, string universityGraduationRank, string graduationYear, int totalTakenCredit, int totalRequiredCredit, int completedCredit, int remainingCredit, int requiredCourseCount, int completedCourseCount)
    {
        Id = id;

        StudentIdentityNumber = studentIdentityNumber;
        TranscriptFileName = transcriptFileName;
        TranscriptGpa = transcriptGpa;
        TranscriptDate = transcriptDate;
        TranscriptDescription = transcriptDescription;
        DepartmentGraduationRank = departmentGraduationRank;
        FacultyGraduationRank = facultyGraduationRank;
        UniversityGraduationRank = universityGraduationRank;
        GraduationYear = graduationYear;
        TotalTakenCredit = totalTakenCredit;
        TotalRequiredCredit = totalRequiredCredit;
        CompletedCredit = completedCredit;
        RemainingCredit = remainingCredit;
        StudentId = studentId;
        RequiredCourseCount = requiredCourseCount;
        CompletedCourseCount = completedCourseCount;
    }
}
