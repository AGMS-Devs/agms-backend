using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.ToTable("Students").HasKey(s => s.Id);

        builder.Property(s => s.Id).HasColumnName("Id").IsRequired();
        builder.Property(s => s.StudentNumber).HasColumnName("StudentNumber").IsRequired();
        builder.Property(s => s.DepartmentId).HasColumnName("DepartmentId").IsRequired();
        builder.Property(s => s.EnrollDate).HasColumnName("EnrollDate").IsRequired();
        builder.Property(s => s.StudentStatus).HasColumnName("StudentStatus").IsRequired();
        builder.Property(s => s.GraduationStatus).HasColumnName("GraduationStatus").IsRequired();
        builder.Property(s => s.AssignedAdvisorId).HasColumnName("AssignedAdvisorId").IsRequired();
        builder.Property(s => s.RequiredCourseListId).HasColumnName("RequiredCourseListId").IsRequired();
        builder.Property(s => s.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(s => s.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(s => s.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(s => !s.DeletedDate.HasValue);

        builder.HasOne(s => s.User)
               .WithOne(u => u.StudentProfile)
               .HasForeignKey<Student>(s => s.Id);

        builder.HasOne(s => s.Department)
               .WithMany(d => d.Students)
               .HasForeignKey(s => s.DepartmentId);

        builder.HasOne(s => s.AssignedAdvisor)
               .WithMany(a => a.Students)
               .HasForeignKey(s => s.AssignedAdvisorId);

        builder.HasMany(s => s.TakenCourses)
               .WithOne(tc => tc.Student)
               .HasForeignKey(tc => tc.StudentId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(s => s.RequiredCourseList)
               .WithMany(rcl => rcl.Students)
               .HasForeignKey(s => s.RequiredCourseListId);

        builder.HasData(GetSeeds());
    }

    private IEnumerable<Student> GetSeeds()
    {
        // Bilgisayar Mühendisliği Öğrencileri
        yield return new Student
        {
            Id = UserConfiguration.StudentUserId,
            StudentNumber = "2023001",
            DepartmentId = DepartmentConfiguration.ComputerEngineeringDepartmentId,
            EnrollDate = new DateTime(2023, 9, 1),
            StudentStatus = StudentStatus.Active,
            GraduationStatus = GraduationStatus.Pending,
            AssignedAdvisorId = AdvisorConfiguration.ComputerEngineeringAdvisorId1,
            RequiredCourseListId = RequiredCourseListConfiguration.ComputerEngineering1RequiredCourseListId,
            CreatedDate = DateTime.UtcNow
        };

        yield return new Student
        {
            Id = UserConfiguration.StudentUserId2,
            StudentNumber = "2023002",
            DepartmentId = DepartmentConfiguration.ComputerEngineeringDepartmentId,
            EnrollDate = new DateTime(2023, 9, 1),
            StudentStatus = StudentStatus.Active,
            GraduationStatus = GraduationStatus.Pending,
            AssignedAdvisorId = AdvisorConfiguration.ComputerEngineeringAdvisorId1,
            RequiredCourseListId = RequiredCourseListConfiguration.ComputerEngineering1RequiredCourseListId,
            CreatedDate = DateTime.UtcNow
        };

        yield return new Student
        {
            Id = UserConfiguration.StudentUserId3,
            StudentNumber = "2023003",
            DepartmentId = DepartmentConfiguration.ComputerEngineeringDepartmentId,
            EnrollDate = new DateTime(2022, 9, 1),
            StudentStatus = StudentStatus.Active,
            GraduationStatus = GraduationStatus.Pending,
            AssignedAdvisorId = AdvisorConfiguration.ComputerEngineeringAdvisorId1,
            RequiredCourseListId = RequiredCourseListConfiguration.ComputerEngineering1RequiredCourseListId,
            CreatedDate = DateTime.UtcNow
        };

        yield return new Student
        {
            Id = UserConfiguration.StudentUserId4,
            StudentNumber = "2023004",
            DepartmentId = DepartmentConfiguration.ComputerEngineeringDepartmentId,
            EnrollDate = new DateTime(2022, 9, 1),
            StudentStatus = StudentStatus.Active,
            GraduationStatus = GraduationStatus.Pending,
            AssignedAdvisorId = AdvisorConfiguration.ComputerEngineeringAdvisorId1,
            RequiredCourseListId = RequiredCourseListConfiguration.ComputerEngineering1RequiredCourseListId,
            CreatedDate = DateTime.UtcNow
        };

        yield return new Student
        {
            Id = UserConfiguration.StudentUserId5,
            StudentNumber = "2023005",
            DepartmentId = DepartmentConfiguration.ComputerEngineeringDepartmentId,
            EnrollDate = new DateTime(2023, 9, 1),
            StudentStatus = StudentStatus.Active,
            GraduationStatus = GraduationStatus.Pending,
            AssignedAdvisorId = AdvisorConfiguration.ComputerEngineeringAdvisorId1,
            RequiredCourseListId = RequiredCourseListConfiguration.ElectricalEngineering1RequiredCourseListId,
            CreatedDate = DateTime.UtcNow
        };

        yield return new Student
        {
            Id = UserConfiguration.StudentUserId6,
            StudentNumber = "2023006",
            DepartmentId = DepartmentConfiguration.ComputerEngineeringDepartmentId,
            EnrollDate = new DateTime(2023, 9, 1),
            StudentStatus = StudentStatus.Active,
            GraduationStatus = GraduationStatus.Approved,
            AssignedAdvisorId = AdvisorConfiguration.ComputerEngineeringAdvisorId1,
            RequiredCourseListId = RequiredCourseListConfiguration.ElectricalEngineering1RequiredCourseListId,
            CreatedDate = DateTime.UtcNow
        };
        
        // Elektrik-Elektronik Mühendisliği Öğrencileri
        yield return new Student
        {
            Id = UserConfiguration.StudentUserId7,
            StudentNumber = "2023007",
            DepartmentId = DepartmentConfiguration.ElectricalEngineeringDepartmentId,
            EnrollDate = new DateTime(2022, 9, 1),
            StudentStatus = StudentStatus.Active,
            GraduationStatus = GraduationStatus.Pending,
            AssignedAdvisorId = AdvisorConfiguration.ElectricalEngineeringAdvisorId1,
            RequiredCourseListId = RequiredCourseListConfiguration.ElectricalEngineering1RequiredCourseListId,
            CreatedDate = DateTime.UtcNow
        };

        yield return new Student
        {
            Id = UserConfiguration.StudentUserId8,
            StudentNumber = "2023008",
            DepartmentId = DepartmentConfiguration.ElectricalEngineeringDepartmentId,
            EnrollDate = new DateTime(2022, 9, 1),
            StudentStatus = StudentStatus.Active,
            GraduationStatus = GraduationStatus.Pending,
            AssignedAdvisorId = AdvisorConfiguration.ElectricalEngineeringAdvisorId1,
            RequiredCourseListId = RequiredCourseListConfiguration.ElectricalEngineering1RequiredCourseListId,
            CreatedDate = DateTime.UtcNow
        };

        yield return new Student
        {
            Id = UserConfiguration.StudentUserId19,
            StudentNumber = "20230071",
            DepartmentId = DepartmentConfiguration.ElectricalEngineeringDepartmentId,
            EnrollDate = new DateTime(2022, 9, 1),
            StudentStatus = StudentStatus.Active,
            GraduationStatus = GraduationStatus.Approved,
            AssignedAdvisorId = AdvisorConfiguration.ElectricalEngineeringAdvisorId1,
            RequiredCourseListId = RequiredCourseListConfiguration.ElectricalEngineering1RequiredCourseListId,
            CreatedDate = DateTime.UtcNow
        };

        yield return new Student
        {
            Id = UserConfiguration.StudentUserId20,
            StudentNumber = "20230081",
            DepartmentId = DepartmentConfiguration.ElectricalEngineeringDepartmentId,
            EnrollDate = new DateTime(2022, 9, 1),
            StudentStatus = StudentStatus.Active,
            GraduationStatus = GraduationStatus.Pending,
            AssignedAdvisorId = AdvisorConfiguration.ElectricalEngineeringAdvisorId1,
            RequiredCourseListId = RequiredCourseListConfiguration.ElectricalEngineering1RequiredCourseListId,
            CreatedDate = DateTime.UtcNow
        };

        // Fizik Bölümü Öğrencileri
        yield return new Student
        {
            Id = UserConfiguration.StudentUserId9,
            StudentNumber = "2023009",
            DepartmentId = DepartmentConfiguration.PhysicsDepartmentId,
            EnrollDate = new DateTime(2023, 9, 1),
            StudentStatus = StudentStatus.Active,
            GraduationStatus = GraduationStatus.Pending,
            AssignedAdvisorId = AdvisorConfiguration.PhysicsAdvisorId1,
            RequiredCourseListId = RequiredCourseListConfiguration.Physics1RequiredCourseListId,
            CreatedDate = DateTime.UtcNow
        };

        yield return new Student
        {
            Id = UserConfiguration.StudentUserId10,
            StudentNumber = "2023010",
            DepartmentId = DepartmentConfiguration.PhysicsDepartmentId,
            EnrollDate = new DateTime(2023, 9, 1),
            StudentStatus = StudentStatus.Active,
            GraduationStatus = GraduationStatus.Pending,
            AssignedAdvisorId = AdvisorConfiguration.PhysicsAdvisorId1,
            RequiredCourseListId = RequiredCourseListConfiguration.Physics1RequiredCourseListId,
            CreatedDate = DateTime.UtcNow
        };

        yield return new Student
        {
            Id = UserConfiguration.StudentUserId11,
            StudentNumber = "2023011",
            DepartmentId = DepartmentConfiguration.PhysicsDepartmentId,
            EnrollDate = new DateTime(2022, 9, 1),
            StudentStatus = StudentStatus.Active,
            GraduationStatus = GraduationStatus.Pending,
            AssignedAdvisorId = AdvisorConfiguration.PhysicsAdvisorId1,
            RequiredCourseListId = RequiredCourseListConfiguration.Physics1RequiredCourseListId,
            CreatedDate = DateTime.UtcNow
        };

        yield return new Student
        {
            Id = UserConfiguration.StudentUserId12,
            StudentNumber = "2023012",
            DepartmentId = DepartmentConfiguration.PhysicsDepartmentId,
            EnrollDate = new DateTime(2022, 9, 1),
            StudentStatus = StudentStatus.Active,
            GraduationStatus = GraduationStatus.Pending,
            AssignedAdvisorId = AdvisorConfiguration.PhysicsAdvisorId1,
            RequiredCourseListId = RequiredCourseListConfiguration.Physics1RequiredCourseListId,
            CreatedDate = DateTime.UtcNow
        };

        // Kimya Bölümü Öğrencileri
        yield return new Student
        {
            Id = UserConfiguration.StudentUserId13,
            StudentNumber = "2023013",
            DepartmentId = DepartmentConfiguration.ChemistryDepartmentId,
            EnrollDate = new DateTime(2023, 9, 1),
            StudentStatus = StudentStatus.Active,
            GraduationStatus = GraduationStatus.Approved,
            AssignedAdvisorId = AdvisorConfiguration.ChemistryAdvisorId1,
            RequiredCourseListId = RequiredCourseListConfiguration.Chemistry1RequiredCourseListId,
            CreatedDate = DateTime.UtcNow
        };

        yield return new Student
        {
            Id = UserConfiguration.StudentUserId14,
            StudentNumber = "2023014",
            DepartmentId = DepartmentConfiguration.ChemistryDepartmentId,
            EnrollDate = new DateTime(2023, 9, 1),
            StudentStatus = StudentStatus.Active,
            GraduationStatus = GraduationStatus.Pending,
            AssignedAdvisorId = AdvisorConfiguration.ChemistryAdvisorId1,
            RequiredCourseListId = RequiredCourseListConfiguration.Chemistry1RequiredCourseListId,
            CreatedDate = DateTime.UtcNow
        };

        yield return new Student
        {
            Id = UserConfiguration.StudentUserId15,
            StudentNumber = "2023015",
            DepartmentId = DepartmentConfiguration.ChemistryDepartmentId,
            EnrollDate = new DateTime(2022, 9, 1),
            StudentStatus = StudentStatus.Active,
            GraduationStatus = GraduationStatus.Pending,
            AssignedAdvisorId = AdvisorConfiguration.ChemistryAdvisorId1,
            RequiredCourseListId = RequiredCourseListConfiguration.Chemistry1RequiredCourseListId,
            CreatedDate = DateTime.UtcNow
        };

        yield return new Student
        {
            Id = UserConfiguration.StudentUserId16,
            StudentNumber = "2023016",
            DepartmentId = DepartmentConfiguration.ChemistryDepartmentId,
            EnrollDate = new DateTime(2022, 9, 1),
            StudentStatus = StudentStatus.Active,
            GraduationStatus = GraduationStatus.Pending,
            AssignedAdvisorId = AdvisorConfiguration.ChemistryAdvisorId1,
            RequiredCourseListId = RequiredCourseListConfiguration.Chemistry1RequiredCourseListId,
            CreatedDate = DateTime.UtcNow
        };

        // Matematik Bölümü Öğrencileri
        yield return new Student
        {
            Id = UserConfiguration.StudentUserId17,
            StudentNumber = "2023017",
            DepartmentId = DepartmentConfiguration.MathematicsDepartmentId,
            EnrollDate = new DateTime(2023, 9, 1),
            StudentStatus = StudentStatus.Active,
            GraduationStatus = GraduationStatus.Pending,
            AssignedAdvisorId = AdvisorConfiguration.MathematicsAdvisorId1,
            RequiredCourseListId = RequiredCourseListConfiguration.Mathematics1RequiredCourseListId,
            CreatedDate = DateTime.UtcNow
        };

        yield return new Student
        {
            Id = UserConfiguration.StudentUserId18,
            StudentNumber = "2023018",
            DepartmentId = DepartmentConfiguration.MathematicsDepartmentId,
            EnrollDate = new DateTime(2023, 9, 1),
            StudentStatus = StudentStatus.Active,
            GraduationStatus = GraduationStatus.Approved,
            AssignedAdvisorId = AdvisorConfiguration.MathematicsAdvisorId1,
            RequiredCourseListId = RequiredCourseListConfiguration.Mathematics1RequiredCourseListId,
            CreatedDate = DateTime.UtcNow
        };

        yield return new Student
        {
            Id = UserConfiguration.StudentUserId21,
            StudentNumber = "2023021",
            DepartmentId = DepartmentConfiguration.MathematicsDepartmentId,
            EnrollDate = new DateTime(2022, 9, 1),
            StudentStatus = StudentStatus.Active,
            GraduationStatus = GraduationStatus.Pending,
            AssignedAdvisorId = AdvisorConfiguration.MathematicsAdvisorId1,
            RequiredCourseListId = RequiredCourseListConfiguration.Mathematics1RequiredCourseListId,
            CreatedDate = DateTime.UtcNow
        };

        yield return new Student
        {
            Id = UserConfiguration.StudentUserId22,
            StudentNumber = "2023022",
            DepartmentId = DepartmentConfiguration.MathematicsDepartmentId,
            EnrollDate = new DateTime(2022, 9, 1),
            StudentStatus = StudentStatus.Active,
            GraduationStatus = GraduationStatus.Pending,
            AssignedAdvisorId = AdvisorConfiguration.MathematicsAdvisorId1,
            RequiredCourseListId = RequiredCourseListConfiguration.Mathematics1RequiredCourseListId,
            CreatedDate = DateTime.UtcNow
        };

        // Makine Mühendisliği Öğrencileri
        yield return new Student
        {
            Id = UserConfiguration.StudentUserId23,
            StudentNumber = "2023023",
            DepartmentId = DepartmentConfiguration.MechanicalEngineeringDepartmentId,
            EnrollDate = new DateTime(2023, 9, 1),
            StudentStatus = StudentStatus.Active,
            GraduationStatus = GraduationStatus.Pending,
            AssignedAdvisorId = AdvisorConfiguration.MechanicalEngineeringAdvisorId1,
            RequiredCourseListId = RequiredCourseListConfiguration.MechanicalEngineering1RequiredCourseListId,
            CreatedDate = DateTime.UtcNow
        };

        yield return new Student
        {
            Id = UserConfiguration.StudentUserId24,
            StudentNumber = "2023024",
            DepartmentId = DepartmentConfiguration.MechanicalEngineeringDepartmentId,
            EnrollDate = new DateTime(2023, 9, 1),
            StudentStatus = StudentStatus.Active,
            GraduationStatus = GraduationStatus.Pending,
            AssignedAdvisorId = AdvisorConfiguration.MechanicalEngineeringAdvisorId1,
            RequiredCourseListId = RequiredCourseListConfiguration.MechanicalEngineering1RequiredCourseListId,
            CreatedDate = DateTime.UtcNow
        };

        yield return new Student
        {
            Id = UserConfiguration.StudentUserId25,
            StudentNumber = "2023025",
            DepartmentId = DepartmentConfiguration.MechanicalEngineeringDepartmentId,
            EnrollDate = new DateTime(2022, 9, 1),
            StudentStatus = StudentStatus.Active,
                GraduationStatus = GraduationStatus.Pending,
            AssignedAdvisorId = AdvisorConfiguration.MechanicalEngineeringAdvisorId1,
            RequiredCourseListId = RequiredCourseListConfiguration.MechanicalEngineering1RequiredCourseListId,
            CreatedDate = DateTime.UtcNow
        };

        yield return new Student
        {
            Id = UserConfiguration.StudentUserId26,
            StudentNumber = "2023026",
            DepartmentId = DepartmentConfiguration.MechanicalEngineeringDepartmentId,
            EnrollDate = new DateTime(2022, 9, 1),
            StudentStatus = StudentStatus.Active,
            GraduationStatus = GraduationStatus.Approved,
            AssignedAdvisorId = AdvisorConfiguration.MechanicalEngineeringAdvisorId1,
            RequiredCourseListId = RequiredCourseListConfiguration.MechanicalEngineering1RequiredCourseListId,
            CreatedDate = DateTime.UtcNow
        };
    }
}