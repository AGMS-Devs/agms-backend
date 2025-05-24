using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class RequiredCourseListCourseConfiguration : IEntityTypeConfiguration<RequiredCourseListCourse>
{
    public void Configure(EntityTypeBuilder<RequiredCourseListCourse> builder)
    {
        builder.ToTable("RequiredCourseListCourses").HasKey(rclc => rclc.Id);

        builder.Property(rclc => rclc.Id).HasColumnName("Id").IsRequired();
        builder.Property(rclc => rclc.RequiredCourseListId).HasColumnName("RequiredCourseListId").IsRequired();
        builder.Property(rclc => rclc.CourseId).HasColumnName("CourseId").IsRequired();
        builder.Property(rclc => rclc.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(rclc => rclc.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(rclc => rclc.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(rclc => !rclc.DeletedDate.HasValue);

        // RequiredCourseList ile ilişki
        builder.HasOne(rclc => rclc.RequiredCourseList)
               .WithMany(rcl => rcl.RequiredCourseListCourses)
               .HasForeignKey(rclc => rclc.RequiredCourseListId)
               .OnDelete(DeleteBehavior.Restrict);

        // Course ile ilişki
        builder.HasOne(rclc => rclc.Course)
               .WithMany(c => c.RequiredCourseListCourses)
               .HasForeignKey(rclc => rclc.CourseId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasData(GetSeeds());
    }

    private IEnumerable<RequiredCourseListCourse> GetSeeds()
    {
        // Bilgisayar Mühendisliği 1. Öğrenci Zorunlu Dersleri
        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.ComputerEngineering1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG111Id,
            CreatedDate = DateTime.UtcNow
        };

        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.ComputerEngineering1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG113Id,
            CreatedDate = DateTime.UtcNow
        };

        // Bilgisayar Mühendisliği 2. Öğrenci Zorunlu Dersleri
        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.ComputerEngineering1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG115Id,
            CreatedDate = DateTime.UtcNow
        };

        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.ComputerEngineering1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG112Id,
            CreatedDate = DateTime.UtcNow
        };

        // Bilgisayar Mühendisliği 3. Öğrenci Zorunlu Dersleri
        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.ComputerEngineering1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG211Id,
            CreatedDate = DateTime.UtcNow
        };

        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.ComputerEngineering1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG213Id,
            CreatedDate = DateTime.UtcNow
        };

        // Elektrik-Elektronik Mühendisliği 1. Öğrenci Zorunlu Dersleri
        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.ComputerEngineering1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG215Id,
            CreatedDate = DateTime.UtcNow
        };

        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.ComputerEngineering1RequiredCourseListId,
            CourseId = CourseConfiguration.MATH144Id,
            CreatedDate = DateTime.UtcNow
        };

        // Elektrik-Elektronik Mühendisliği 2. Öğrenci Zorunlu Dersleri
        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.ComputerEngineering1RequiredCourseListId,
            CourseId = CourseConfiguration.HIST201Id,
            CreatedDate = DateTime.UtcNow
        };

        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.ComputerEngineering1RequiredCourseListId,
            CourseId = CourseConfiguration.TURK201Id,
            CreatedDate = DateTime.UtcNow
        };

        // Elektrik-Elektronik Mühendisliği 3. Öğrenci Zorunlu Dersleri
        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.ComputerEngineering1RequiredCourseListId,
            CourseId = CourseConfiguration.HIST202Id,
            CreatedDate = DateTime.UtcNow
        };

        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.ComputerEngineering1RequiredCourseListId,
            CourseId = CourseConfiguration.TURK202Id,
            CreatedDate = DateTime.UtcNow
        };

        // Kimya Bölümü 1. Öğrenci Zorunlu Dersleri
        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.ComputerEngineering1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG212Id,
            CreatedDate = DateTime.UtcNow
        };

        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.ComputerEngineering1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG214Id,
            CreatedDate = DateTime.UtcNow
        };

        // Kimya Bölümü 2. Öğrenci Zorunlu Dersleri
        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.ComputerEngineering1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG216Id,
            CreatedDate = DateTime.UtcNow
        };

        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.ComputerEngineering1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG218Id,
            CreatedDate = DateTime.UtcNow
        };

        // Kimya Bölümü 3. Öğrenci Zorunlu Dersleri
        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.ComputerEngineering1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG222Id,
            CreatedDate = DateTime.UtcNow
        };

        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.ComputerEngineering1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG311Id,
            CreatedDate = DateTime.UtcNow
        };

        // Makine Mühendisliği 1. Öğrenci Zorunlu Dersleri
        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.ComputerEngineering1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG315Id,
            CreatedDate = DateTime.UtcNow
        };

        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.ComputerEngineering1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG323Id,
            CreatedDate = DateTime.UtcNow
        };

        // Makine Mühendisliği 2. Öğrenci Zorunlu Dersleri
        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.ComputerEngineering1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG312Id,
            CreatedDate = DateTime.UtcNow
        };

        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.ComputerEngineering1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG316Id,
            CreatedDate = DateTime.UtcNow
        };

        // Makine Mühendisliği 3. Öğrenci Zorunlu Dersleri
        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.ComputerEngineering1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG318Id,
            CreatedDate = DateTime.UtcNow
        };

        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.ComputerEngineering1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG322Id,
            CreatedDate = DateTime.UtcNow
        };

        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.ComputerEngineering1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG400Id,
            CreatedDate = DateTime.UtcNow
        };

        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.ComputerEngineering1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG411Id,
            CreatedDate = DateTime.UtcNow
        };

        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.ComputerEngineering1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG415Id,
            CreatedDate = DateTime.UtcNow
        };

        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.ComputerEngineering1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG416Id,
            CreatedDate = DateTime.UtcNow
        };

        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.ComputerEngineering1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG418Id,
            CreatedDate = DateTime.UtcNow
        };

        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.ComputerEngineering1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG424Id,
            CreatedDate = DateTime.UtcNow
        };  

        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.ComputerEngineering1RequiredCourseListId,
            CourseId = CourseConfiguration.MATH141Id,
            CreatedDate = DateTime.UtcNow
        };

        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.ComputerEngineering1RequiredCourseListId,
            CourseId = CourseConfiguration.MATH142Id,
            CreatedDate = DateTime.UtcNow
        };

        yield return new RequiredCourseListCourse   
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.ComputerEngineering1RequiredCourseListId,
            CourseId = CourseConfiguration.MATH255Id,
            CreatedDate = DateTime.UtcNow
        };

        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.ComputerEngineering1RequiredCourseListId,
            CourseId = CourseConfiguration.PHYS121Id,
            CreatedDate = DateTime.UtcNow
        };

        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.ComputerEngineering1RequiredCourseListId,
            CourseId = CourseConfiguration.PHYS122Id,
            CreatedDate = DateTime.UtcNow
        };

       

        // Bilgisayar Mühendisliği 1. Öğrenci Zorunlu Dersleri
        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.ElectricalEngineering1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG111Id,
            CreatedDate = DateTime.UtcNow
        };

        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.ElectricalEngineering1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG113Id,
            CreatedDate = DateTime.UtcNow
        };

        // Bilgisayar Mühendisliği 2. Öğrenci Zorunlu Dersleri
        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.ElectricalEngineering1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG115Id,
            CreatedDate = DateTime.UtcNow
        };

        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.ElectricalEngineering1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG112Id,
            CreatedDate = DateTime.UtcNow
        };

        // Bilgisayar Mühendisliği 3. Öğrenci Zorunlu Dersleri
        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.ElectricalEngineering1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG211Id,
            CreatedDate = DateTime.UtcNow
        };

        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.ElectricalEngineering1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG213Id,
            CreatedDate = DateTime.UtcNow
        };

        // Elektrik-Elektronik Mühendisliği 1. Öğrenci Zorunlu Dersleri
        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.ElectricalEngineering1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG215Id,
            CreatedDate = DateTime.UtcNow
        };

        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.ElectricalEngineering1RequiredCourseListId,
            CourseId = CourseConfiguration.MATH144Id,
            CreatedDate = DateTime.UtcNow
        };

        // Elektrik-Elektronik Mühendisliği 2. Öğrenci Zorunlu Dersleri
        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.ElectricalEngineering1RequiredCourseListId,
            CourseId = CourseConfiguration.HIST201Id,
            CreatedDate = DateTime.UtcNow
        };

        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.ElectricalEngineering1RequiredCourseListId,
            CourseId = CourseConfiguration.TURK201Id,
            CreatedDate = DateTime.UtcNow
        };

        // Elektrik-Elektronik Mühendisliği 3. Öğrenci Zorunlu Dersleri
        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.ElectricalEngineering1RequiredCourseListId,
            CourseId = CourseConfiguration.HIST202Id,
            CreatedDate = DateTime.UtcNow
        };

        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.ElectricalEngineering1RequiredCourseListId,
            CourseId = CourseConfiguration.TURK202Id,
            CreatedDate = DateTime.UtcNow
        };

        // Kimya Bölümü 1. Öğrenci Zorunlu Dersleri
        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.ElectricalEngineering1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG212Id,
            CreatedDate = DateTime.UtcNow
        };

        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.ElectricalEngineering1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG214Id,
            CreatedDate = DateTime.UtcNow
        };

        // Kimya Bölümü 2. Öğrenci Zorunlu Dersleri
        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.ElectricalEngineering1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG216Id,
            CreatedDate = DateTime.UtcNow
        };

        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.ElectricalEngineering1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG218Id,
            CreatedDate = DateTime.UtcNow
        };

        // Kimya Bölümü 3. Öğrenci Zorunlu Dersleri
        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.ElectricalEngineering1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG222Id,
            CreatedDate = DateTime.UtcNow
        };

        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.ElectricalEngineering1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG311Id,
            CreatedDate = DateTime.UtcNow
        };

        // Makine Mühendisliği 1. Öğrenci Zorunlu Dersleri
        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.ElectricalEngineering1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG315Id,
            CreatedDate = DateTime.UtcNow
        };

        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.ElectricalEngineering1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG323Id,
            CreatedDate = DateTime.UtcNow
        };

        // Makine Mühendisliği 2. Öğrenci Zorunlu Dersleri
        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.ElectricalEngineering1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG312Id,
            CreatedDate = DateTime.UtcNow
        };

        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.ElectricalEngineering1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG316Id,
            CreatedDate = DateTime.UtcNow
        };

        // Makine Mühendisliği 3. Öğrenci Zorunlu Dersleri
        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.ElectricalEngineering1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG318Id,
            CreatedDate = DateTime.UtcNow
        };

        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.ElectricalEngineering1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG322Id,
            CreatedDate = DateTime.UtcNow
        };

        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.ElectricalEngineering1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG400Id,
            CreatedDate = DateTime.UtcNow
        };

        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.ElectricalEngineering1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG411Id,
            CreatedDate = DateTime.UtcNow
        };

        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.ElectricalEngineering1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG415Id,
            CreatedDate = DateTime.UtcNow
        };

        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.ElectricalEngineering1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG416Id,
            CreatedDate = DateTime.UtcNow
        };

        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.ElectricalEngineering1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG418Id,
            CreatedDate = DateTime.UtcNow
        };

        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.ElectricalEngineering1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG424Id,
            CreatedDate = DateTime.UtcNow
        };  

        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.ElectricalEngineering1RequiredCourseListId,
            CourseId = CourseConfiguration.MATH141Id,
            CreatedDate = DateTime.UtcNow
        };

        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.ElectricalEngineering1RequiredCourseListId,
            CourseId = CourseConfiguration.MATH142Id,
            CreatedDate = DateTime.UtcNow
        };

        yield return new RequiredCourseListCourse   
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.ElectricalEngineering1RequiredCourseListId,
            CourseId = CourseConfiguration.MATH255Id,
            CreatedDate = DateTime.UtcNow
        };

        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.ElectricalEngineering1RequiredCourseListId,
            CourseId = CourseConfiguration.PHYS121Id,
            CreatedDate = DateTime.UtcNow
        };

        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.ElectricalEngineering1RequiredCourseListId,
            CourseId = CourseConfiguration.PHYS122Id,
            CreatedDate = DateTime.UtcNow
        };



       

        // Bilgisayar Mühendisliği 1. Öğrenci Zorunlu Dersleri
        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.Physics1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG111Id,
            CreatedDate = DateTime.UtcNow
        };

        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.Physics1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG113Id,
            CreatedDate = DateTime.UtcNow
        };

        // Bilgisayar Mühendisliği 2. Öğrenci Zorunlu Dersleri
        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.Physics1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG115Id,
            CreatedDate = DateTime.UtcNow
        };

        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.Physics1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG112Id,
            CreatedDate = DateTime.UtcNow
        };

        // Bilgisayar Mühendisliği 3. Öğrenci Zorunlu Dersleri
        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.Physics1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG211Id,
            CreatedDate = DateTime.UtcNow
        };

        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.Physics1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG213Id,
            CreatedDate = DateTime.UtcNow
        };

        // Elektrik-Elektronik Mühendisliği 1. Öğrenci Zorunlu Dersleri
        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.Physics1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG215Id,
            CreatedDate = DateTime.UtcNow
        };

        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.Physics1RequiredCourseListId,
            CourseId = CourseConfiguration.MATH144Id,
            CreatedDate = DateTime.UtcNow
        };

        // Elektrik-Elektronik Mühendisliği 2. Öğrenci Zorunlu Dersleri
        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.Physics1RequiredCourseListId,
            CourseId = CourseConfiguration.HIST201Id,
            CreatedDate = DateTime.UtcNow
        };

        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.Physics1RequiredCourseListId,
            CourseId = CourseConfiguration.TURK201Id,
            CreatedDate = DateTime.UtcNow
        };

        // Elektrik-Elektronik Mühendisliği 3. Öğrenci Zorunlu Dersleri
        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.Physics1RequiredCourseListId,
            CourseId = CourseConfiguration.HIST202Id,
            CreatedDate = DateTime.UtcNow
        };

        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.Physics1RequiredCourseListId,
            CourseId = CourseConfiguration.TURK202Id,
            CreatedDate = DateTime.UtcNow
        };

        // Kimya Bölümü 1. Öğrenci Zorunlu Dersleri
        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.Physics1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG212Id,
            CreatedDate = DateTime.UtcNow
        };

        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.Physics1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG214Id,
            CreatedDate = DateTime.UtcNow
        };

        // Kimya Bölümü 2. Öğrenci Zorunlu Dersleri
        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.Physics1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG216Id,
            CreatedDate = DateTime.UtcNow
        };

        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.Physics1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG218Id,
            CreatedDate = DateTime.UtcNow
        };

        // Kimya Bölümü 3. Öğrenci Zorunlu Dersleri
        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.Physics1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG222Id,
            CreatedDate = DateTime.UtcNow
        };

        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.Physics1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG311Id,
            CreatedDate = DateTime.UtcNow
        };

        // Makine Mühendisliği 1. Öğrenci Zorunlu Dersleri
        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.Physics1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG315Id,
            CreatedDate = DateTime.UtcNow
        };

        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.Physics1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG323Id,
            CreatedDate = DateTime.UtcNow
        };

        // Makine Mühendisliği 2. Öğrenci Zorunlu Dersleri
        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.Physics1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG312Id,
            CreatedDate = DateTime.UtcNow
        };

        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.Physics1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG316Id,
            CreatedDate = DateTime.UtcNow
        };

        // Makine Mühendisliği 3. Öğrenci Zorunlu Dersleri
        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.Physics1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG318Id,
            CreatedDate = DateTime.UtcNow
        };

        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.Physics1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG322Id,
            CreatedDate = DateTime.UtcNow
        };

        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.Physics1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG400Id,
            CreatedDate = DateTime.UtcNow
        };

        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.Physics1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG411Id,
            CreatedDate = DateTime.UtcNow
        };

        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.Physics1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG415Id,
            CreatedDate = DateTime.UtcNow
        };

        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.Physics1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG416Id,
            CreatedDate = DateTime.UtcNow
        };

        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.Physics1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG418Id,
            CreatedDate = DateTime.UtcNow
        };

        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.Physics1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG424Id,
            CreatedDate = DateTime.UtcNow
        };  

        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.Physics1RequiredCourseListId,
            CourseId = CourseConfiguration.MATH141Id,
            CreatedDate = DateTime.UtcNow
        };

        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.Physics1RequiredCourseListId,
            CourseId = CourseConfiguration.MATH142Id,
            CreatedDate = DateTime.UtcNow
        };

        yield return new RequiredCourseListCourse   
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.Physics1RequiredCourseListId,
            CourseId = CourseConfiguration.MATH255Id,
            CreatedDate = DateTime.UtcNow
        };

        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.Physics1RequiredCourseListId,
            CourseId = CourseConfiguration.PHYS121Id,
            CreatedDate = DateTime.UtcNow
        };

        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.Physics1RequiredCourseListId,
            CourseId = CourseConfiguration.PHYS122Id,
            CreatedDate = DateTime.UtcNow
        };

       

        // Bilgisayar Mühendisliği 1. Öğrenci Zorunlu Dersleri
        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.Chemistry1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG111Id,
            CreatedDate = DateTime.UtcNow
        };

        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.Chemistry1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG113Id,
            CreatedDate = DateTime.UtcNow
        };

        // Bilgisayar Mühendisliği 2. Öğrenci Zorunlu Dersleri
        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.Chemistry1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG115Id,
            CreatedDate = DateTime.UtcNow
        };

        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.Chemistry1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG112Id,
            CreatedDate = DateTime.UtcNow
        };

        // Bilgisayar Mühendisliği 3. Öğrenci Zorunlu Dersleri
        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.Chemistry1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG211Id,
            CreatedDate = DateTime.UtcNow
        };

        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.Chemistry1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG213Id,
            CreatedDate = DateTime.UtcNow
        };

        // Elektrik-Elektronik Mühendisliği 1. Öğrenci Zorunlu Dersleri
        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.Chemistry1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG215Id,
            CreatedDate = DateTime.UtcNow
        };

        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.Chemistry1RequiredCourseListId,
            CourseId = CourseConfiguration.MATH144Id,
            CreatedDate = DateTime.UtcNow
        };

        // Elektrik-Elektronik Mühendisliği 2. Öğrenci Zorunlu Dersleri
        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.Chemistry1RequiredCourseListId,
            CourseId = CourseConfiguration.HIST201Id,
            CreatedDate = DateTime.UtcNow
        };

        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.Chemistry1RequiredCourseListId,
            CourseId = CourseConfiguration.TURK201Id,
            CreatedDate = DateTime.UtcNow
        };

        // Elektrik-Elektronik Mühendisliği 3. Öğrenci Zorunlu Dersleri
        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.Chemistry1RequiredCourseListId,
            CourseId = CourseConfiguration.HIST202Id,
            CreatedDate = DateTime.UtcNow
        };

        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.Chemistry1RequiredCourseListId,
            CourseId = CourseConfiguration.TURK202Id,
            CreatedDate = DateTime.UtcNow
        };

        // Kimya Bölümü 1. Öğrenci Zorunlu Dersleri
        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.Chemistry1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG212Id,
            CreatedDate = DateTime.UtcNow
        };

        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.Chemistry1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG214Id,
            CreatedDate = DateTime.UtcNow
        };

        // Kimya Bölümü 2. Öğrenci Zorunlu Dersleri
        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.Chemistry1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG216Id,
            CreatedDate = DateTime.UtcNow
        };

        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.Chemistry1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG218Id,
            CreatedDate = DateTime.UtcNow
        };

        // Kimya Bölümü 3. Öğrenci Zorunlu Dersleri
        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.Chemistry1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG222Id,
            CreatedDate = DateTime.UtcNow
        };

        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.Chemistry1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG311Id,
            CreatedDate = DateTime.UtcNow
        };

        // Makine Mühendisliği 1. Öğrenci Zorunlu Dersleri
        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.Chemistry1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG315Id,
            CreatedDate = DateTime.UtcNow
        };

        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.Chemistry1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG323Id,
            CreatedDate = DateTime.UtcNow
        };

        // Makine Mühendisliği 2. Öğrenci Zorunlu Dersleri
        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.Chemistry1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG312Id,
            CreatedDate = DateTime.UtcNow
        };

        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.Chemistry1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG316Id,
            CreatedDate = DateTime.UtcNow
        };

        // Makine Mühendisliği 3. Öğrenci Zorunlu Dersleri
        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.Chemistry1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG318Id,
            CreatedDate = DateTime.UtcNow
        };

        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.Chemistry1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG322Id,
            CreatedDate = DateTime.UtcNow
        };

        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.Chemistry1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG400Id,
            CreatedDate = DateTime.UtcNow
        };

        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.Chemistry1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG411Id,
            CreatedDate = DateTime.UtcNow
        };

        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.Chemistry1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG415Id,
            CreatedDate = DateTime.UtcNow
        };

        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.Chemistry1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG416Id,
            CreatedDate = DateTime.UtcNow
        };

        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.Chemistry1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG418Id,
            CreatedDate = DateTime.UtcNow
        };

        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.Chemistry1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG424Id,
            CreatedDate = DateTime.UtcNow
        };  

        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.Chemistry1RequiredCourseListId,
            CourseId = CourseConfiguration.MATH141Id,
            CreatedDate = DateTime.UtcNow
        };

        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.Chemistry1RequiredCourseListId,
            CourseId = CourseConfiguration.MATH142Id,
            CreatedDate = DateTime.UtcNow
        };

        yield return new RequiredCourseListCourse   
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.Chemistry1RequiredCourseListId,
            CourseId = CourseConfiguration.MATH255Id,
            CreatedDate = DateTime.UtcNow
        };

        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.Chemistry1RequiredCourseListId,
            CourseId = CourseConfiguration.PHYS121Id,
            CreatedDate = DateTime.UtcNow
        };

        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.Chemistry1RequiredCourseListId,
            CourseId = CourseConfiguration.PHYS122Id,
            CreatedDate = DateTime.UtcNow
        };

       


        // Bilgisayar Mühendisliği 1. Öğrenci Zorunlu Dersleri
        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.Mathematics1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG111Id,
            CreatedDate = DateTime.UtcNow
        };

        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.Mathematics1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG113Id,
            CreatedDate = DateTime.UtcNow
        };

        // Bilgisayar Mühendisliği 2. Öğrenci Zorunlu Dersleri
        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.Mathematics1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG115Id,
            CreatedDate = DateTime.UtcNow
        };

        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.Mathematics1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG112Id,
            CreatedDate = DateTime.UtcNow
        };

        // Bilgisayar Mühendisliği 3. Öğrenci Zorunlu Dersleri
        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.Mathematics1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG211Id,
            CreatedDate = DateTime.UtcNow
        };

        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.Mathematics1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG213Id,
            CreatedDate = DateTime.UtcNow
        };

        // Elektrik-Elektronik Mühendisliği 1. Öğrenci Zorunlu Dersleri
        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.Mathematics1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG215Id,
            CreatedDate = DateTime.UtcNow
        };

        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.Mathematics1RequiredCourseListId,
            CourseId = CourseConfiguration.MATH144Id,
            CreatedDate = DateTime.UtcNow
        };

        // Elektrik-Elektronik Mühendisliği 2. Öğrenci Zorunlu Dersleri
        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.Mathematics1RequiredCourseListId,
            CourseId = CourseConfiguration.HIST201Id,
            CreatedDate = DateTime.UtcNow
        };

        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.Mathematics1RequiredCourseListId,
            CourseId = CourseConfiguration.TURK201Id,
            CreatedDate = DateTime.UtcNow
        };

        // Elektrik-Elektronik Mühendisliği 3. Öğrenci Zorunlu Dersleri
        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.Mathematics1RequiredCourseListId,
            CourseId = CourseConfiguration.HIST202Id,
            CreatedDate = DateTime.UtcNow
        };

        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.Mathematics1RequiredCourseListId,
            CourseId = CourseConfiguration.TURK202Id,
            CreatedDate = DateTime.UtcNow
        };

        // Kimya Bölümü 1. Öğrenci Zorunlu Dersleri
        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.Mathematics1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG212Id,
            CreatedDate = DateTime.UtcNow
        };

        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.Mathematics1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG214Id,
            CreatedDate = DateTime.UtcNow
        };

        // Kimya Bölümü 2. Öğrenci Zorunlu Dersleri
        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.Mathematics1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG216Id,
            CreatedDate = DateTime.UtcNow
        };

        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.Mathematics1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG218Id,
            CreatedDate = DateTime.UtcNow
        };

        // Kimya Bölümü 3. Öğrenci Zorunlu Dersleri
        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.Mathematics1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG222Id,
            CreatedDate = DateTime.UtcNow
        };

        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.Mathematics1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG311Id,
            CreatedDate = DateTime.UtcNow
        };

        // Makine Mühendisliği 1. Öğrenci Zorunlu Dersleri
        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.Mathematics1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG315Id,
            CreatedDate = DateTime.UtcNow
        };

        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.Mathematics1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG323Id,
            CreatedDate = DateTime.UtcNow
        };

        // Makine Mühendisliği 2. Öğrenci Zorunlu Dersleri
        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.Mathematics1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG312Id,
            CreatedDate = DateTime.UtcNow
        };

        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.Mathematics1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG316Id,
            CreatedDate = DateTime.UtcNow
        };

        // Makine Mühendisliği 3. Öğrenci Zorunlu Dersleri
        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.Mathematics1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG318Id,
            CreatedDate = DateTime.UtcNow
        };

        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.Mathematics1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG322Id,
            CreatedDate = DateTime.UtcNow
        };

        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.Mathematics1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG400Id,
            CreatedDate = DateTime.UtcNow
        };

        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.Mathematics1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG411Id,
            CreatedDate = DateTime.UtcNow
        };

        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.Mathematics1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG415Id,
            CreatedDate = DateTime.UtcNow
        };

        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.Mathematics1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG416Id,
            CreatedDate = DateTime.UtcNow
        };

        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.Mathematics1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG418Id,
            CreatedDate = DateTime.UtcNow
        };

        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.Mathematics1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG424Id,
            CreatedDate = DateTime.UtcNow
        };  

        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.Mathematics1RequiredCourseListId,
            CourseId = CourseConfiguration.MATH141Id,
            CreatedDate = DateTime.UtcNow
        };

        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.Mathematics1RequiredCourseListId,
            CourseId = CourseConfiguration.MATH142Id,
            CreatedDate = DateTime.UtcNow
        };

        yield return new RequiredCourseListCourse   
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.Mathematics1RequiredCourseListId,
            CourseId = CourseConfiguration.MATH255Id,
            CreatedDate = DateTime.UtcNow
        };

        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.Mathematics1RequiredCourseListId,
            CourseId = CourseConfiguration.PHYS121Id,
            CreatedDate = DateTime.UtcNow
        };

        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.Mathematics1RequiredCourseListId,
            CourseId = CourseConfiguration.PHYS122Id,
            CreatedDate = DateTime.UtcNow
        };

        // Bilgisayar Mühendisliği 1. Öğrenci Zorunlu Dersleri
        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.MechanicalEngineering1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG111Id,
            CreatedDate = DateTime.UtcNow
        };

        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.MechanicalEngineering1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG113Id,
            CreatedDate = DateTime.UtcNow
        };

        // Bilgisayar Mühendisliği 2. Öğrenci Zorunlu Dersleri
        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.MechanicalEngineering1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG115Id,
            CreatedDate = DateTime.UtcNow
        };

        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.MechanicalEngineering1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG112Id,
            CreatedDate = DateTime.UtcNow
        };

        // Bilgisayar Mühendisliği 3. Öğrenci Zorunlu Dersleri
        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.MechanicalEngineering1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG211Id,
            CreatedDate = DateTime.UtcNow
        };

        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.MechanicalEngineering1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG213Id,
            CreatedDate = DateTime.UtcNow
        };

        // Elektrik-Elektronik Mühendisliği 1. Öğrenci Zorunlu Dersleri
        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.MechanicalEngineering1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG215Id,
            CreatedDate = DateTime.UtcNow
        };

        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.MechanicalEngineering1RequiredCourseListId,
            CourseId = CourseConfiguration.MATH144Id,
            CreatedDate = DateTime.UtcNow
        };

        // Elektrik-Elektronik Mühendisliği 2. Öğrenci Zorunlu Dersleri
        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.MechanicalEngineering1RequiredCourseListId,
            CourseId = CourseConfiguration.HIST201Id,
            CreatedDate = DateTime.UtcNow
        };

        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.MechanicalEngineering1RequiredCourseListId,
            CourseId = CourseConfiguration.TURK201Id,
            CreatedDate = DateTime.UtcNow
        };

        // Elektrik-Elektronik Mühendisliği 3. Öğrenci Zorunlu Dersleri
        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.MechanicalEngineering1RequiredCourseListId,
            CourseId = CourseConfiguration.HIST202Id,
            CreatedDate = DateTime.UtcNow
        };

        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.MechanicalEngineering1RequiredCourseListId,
            CourseId = CourseConfiguration.TURK202Id,
            CreatedDate = DateTime.UtcNow
        };

        // Kimya Bölümü 1. Öğrenci Zorunlu Dersleri
        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.MechanicalEngineering1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG212Id,
            CreatedDate = DateTime.UtcNow
        };

        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.MechanicalEngineering1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG214Id,
            CreatedDate = DateTime.UtcNow
        };

        // Kimya Bölümü 2. Öğrenci Zorunlu Dersleri
        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.MechanicalEngineering1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG216Id,
            CreatedDate = DateTime.UtcNow
        };

        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.MechanicalEngineering1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG218Id,
            CreatedDate = DateTime.UtcNow
        };

        // Kimya Bölümü 3. Öğrenci Zorunlu Dersleri
        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.MechanicalEngineering1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG222Id,
            CreatedDate = DateTime.UtcNow
        };

        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.MechanicalEngineering1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG311Id,
            CreatedDate = DateTime.UtcNow
        };

        // Makine Mühendisliği 1. Öğrenci Zorunlu Dersleri
        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.MechanicalEngineering1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG315Id,
            CreatedDate = DateTime.UtcNow
        };

        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.MechanicalEngineering1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG323Id,
            CreatedDate = DateTime.UtcNow
        };

        // Makine Mühendisliği 2. Öğrenci Zorunlu Dersleri
        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.MechanicalEngineering1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG312Id,
            CreatedDate = DateTime.UtcNow
        };

        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.MechanicalEngineering1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG316Id,
            CreatedDate = DateTime.UtcNow
        };

        // Makine Mühendisliği 3. Öğrenci Zorunlu Dersleri
        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.MechanicalEngineering1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG318Id,
            CreatedDate = DateTime.UtcNow
        };

        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.MechanicalEngineering1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG322Id,
            CreatedDate = DateTime.UtcNow
        };

        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.MechanicalEngineering1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG400Id,
            CreatedDate = DateTime.UtcNow
        };

        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.MechanicalEngineering1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG411Id,
            CreatedDate = DateTime.UtcNow
        };

        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.MechanicalEngineering1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG415Id,
            CreatedDate = DateTime.UtcNow
        };

        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.MechanicalEngineering1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG416Id,
            CreatedDate = DateTime.UtcNow
        };

        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.MechanicalEngineering1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG418Id,
            CreatedDate = DateTime.UtcNow
        };

        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.MechanicalEngineering1RequiredCourseListId,
            CourseId = CourseConfiguration.CENG424Id,
            CreatedDate = DateTime.UtcNow
        };  

        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.MechanicalEngineering1RequiredCourseListId,
            CourseId = CourseConfiguration.MATH141Id,
            CreatedDate = DateTime.UtcNow
        };

        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.MechanicalEngineering1RequiredCourseListId,
            CourseId = CourseConfiguration.MATH142Id,
            CreatedDate = DateTime.UtcNow
        };

        yield return new RequiredCourseListCourse   
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.MechanicalEngineering1RequiredCourseListId,
            CourseId = CourseConfiguration.MATH255Id,
            CreatedDate = DateTime.UtcNow
        };

        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.MechanicalEngineering1RequiredCourseListId,
            CourseId = CourseConfiguration.PHYS121Id,
            CreatedDate = DateTime.UtcNow
        };

        yield return new RequiredCourseListCourse
        {
            Id = Guid.NewGuid(),
            RequiredCourseListId = RequiredCourseListConfiguration.MechanicalEngineering1RequiredCourseListId,
            CourseId = CourseConfiguration.PHYS122Id,
            CreatedDate = DateTime.UtcNow
        };

      
    }
}