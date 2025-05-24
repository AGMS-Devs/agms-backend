using System;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Enums;
using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class TakenCourse : Entity<Guid>
{
    public Guid CourseId { get; set; }
    [ForeignKey("CourseId")]
    public virtual Course Course { get; set; }

    public Guid StudentId { get; set; }
    [ForeignKey("StudentId")]
    public virtual Student Student { get; set; }

    public Grade Grade { get; set; }
    public DateTime TakenDate { get; set; }

    public TakenCourse()
    {
    }
    
    public TakenCourse(Guid id, Guid courseId, Guid studentId, Grade grade, DateTime takenDate)
    {
        Id = id;
        CourseId = courseId;
        StudentId = studentId;
        Grade = grade;
        TakenDate = takenDate;
    }
}
