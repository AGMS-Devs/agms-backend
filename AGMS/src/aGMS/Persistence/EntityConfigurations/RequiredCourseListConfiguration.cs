using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class RequiredCourseListConfiguration : IEntityTypeConfiguration<RequiredCourseList>
{
    // Bilgisayar Mühendisliği
    public static readonly Guid ComputerEngineering1RequiredCourseListId = new Guid("c66c4c18-7cff-4ca2-9b66-c6d2d883397e");
    // public static readonly Guid ComputerEngineering2RequiredCourseListId = new Guid("d77d5d29-8dff-5db3-ac77-d7e3e994408f");
    // public static readonly Guid ComputerEngineering3RequiredCourseListId = new Guid("e88e6e3a-9eff-6ec4-bd88-e8f4fa551190");

    // Elektrik-Elektronik Mühendisliği
    public static readonly Guid ElectricalEngineering1RequiredCourseListId = new Guid("0b8fcf71-6994-4a27-b309-5dcb10110c71");
    // public static readonly Guid ElectricalEngineering2RequiredCourseListId = new Guid("1c9fd082-7a95-5b38-c41a-6edc21221d82");
    // public static readonly Guid ElectricalEngineering3RequiredCourseListId = new Guid("2da0e193-8b96-6c49-d52b-7fed32332e93");

    // Fizik Bölümü
    public static readonly Guid Physics1RequiredCourseListId = new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f89");
    // public static readonly Guid Physics2RequiredCourseListId = new Guid("e5f6a7b8-c9da-4e1f-2a3b-4c5d6e7f89a0");
    // public static readonly Guid Physics3RequiredCourseListId = new Guid("f6a7b8c9-dae1-4f2a-3b4c-5d6e7f89a0b1");

    // Kimya
    public static readonly Guid Chemistry1RequiredCourseListId = new Guid("7bbe170d-9ce7-4eb1-9bd4-5b47fc1edb10");
    // public static readonly Guid Chemistry2RequiredCourseListId = new Guid("8ccf281e-adf8-4fc2-ace5-6c58fd2fec21");
    // public static readonly Guid Chemistry3RequiredCourseListId = new Guid("9dd0392f-bef9-4ad3-bdf6-7d69ae3afd32");

    // Matematik Bölümü
    public static readonly Guid Mathematics1RequiredCourseListId = new Guid("c9d0e1f2-a3b4-4c5d-6e7f-890123456abc");
    // public static readonly Guid Mathematics2RequiredCourseListId = new Guid("dae1f2a3-b4c5-4d6e-7f89-901234567bcd");
    // public static readonly Guid Mathematics3RequiredCourseListId = new Guid("ebf2a3b4-c5d6-4e7f-89a0-123456789cde");

    // Makine Mühendisliği
    public static readonly Guid MechanicalEngineering1RequiredCourseListId = new Guid("746570e3-58d1-477d-b49d-84b272af6b18");
    // public static readonly Guid MechanicalEngineering2RequiredCourseListId = new Guid("857681f4-69e2-488e-c5ae-95c383ba7c29");
    // public static readonly Guid MechanicalEngineering3RequiredCourseListId = new Guid("968792a5-7af3-499f-d6bf-a6d494ca8d3a");

    public void Configure(EntityTypeBuilder<RequiredCourseList> builder)
    {
        builder.ToTable("RequiredCourseLists").HasKey(rcl => rcl.Id);

        builder.Property(rcl => rcl.Id).HasColumnName("Id").IsRequired();
        builder.Property(rcl => rcl.Name).HasColumnName("Name").IsRequired();
        builder.Property(rcl => rcl.Description).HasColumnName("Description");
        builder.Property(rcl => rcl.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(rcl => rcl.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(rcl => rcl.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(rcl => !rcl.DeletedDate.HasValue);

        builder.HasMany(rcl => rcl.Students)
               .WithOne(s => s.RequiredCourseList)
               .HasForeignKey(s => s.RequiredCourseListId)
               .OnDelete(DeleteBehavior.Restrict);


        builder.HasMany(rcl => rcl.RequiredCourseListCourses)
               .WithOne(rclc => rclc.RequiredCourseList)
               .HasForeignKey(rclc => rclc.RequiredCourseListId);

        builder.HasMany(rcl => rcl.Courses)
               .WithMany(c => c.RequiredCourseLists)
               .UsingEntity<RequiredCourseListCourse>();

        builder.HasData(GetSeeds());
    }

    private IEnumerable<RequiredCourseList> GetSeeds()
    {
        // Bilgisayar Mühendisliği zorunlu ders listesi
        yield return new RequiredCourseList
        {
            Id = ComputerEngineering1RequiredCourseListId,
            Name = "Bilgisayar Mühendisliği Zorunlu Dersler",
            Description = "Bilgisayar Mühendisliği bölümü öğrencileri için gerekli zorunlu dersler",
            CreatedDate = DateTime.UtcNow
        };

        // Elektrik-Elektronik Mühendisliği zorunlu ders listesi
        yield return new RequiredCourseList
        {
            Id = ElectricalEngineering1RequiredCourseListId,
            Name = "Elektrik-Elektronik Mühendisliği Zorunlu Dersler",
            Description = "Elektrik-Elektronik Mühendisliği bölümü öğrencileri için gerekli zorunlu dersler",
            CreatedDate = DateTime.UtcNow
        };

        // Fizik Bölümü zorunlu ders listesi
        yield return new RequiredCourseList
        {
            Id = Physics1RequiredCourseListId,
            Name = "Fizik Bölümü Zorunlu Dersler",
            Description = "Fizik bölümü öğrencileri için gerekli zorunlu dersler",
            CreatedDate = DateTime.UtcNow
        };

        // Kimya Bölümü zorunlu ders listesi
        yield return new RequiredCourseList
        {
            Id = Chemistry1RequiredCourseListId,
            Name = "Kimya Bölümü Zorunlu Dersler",
            Description = "Kimya bölümü öğrencileri için gerekli zorunlu dersler",
            CreatedDate = DateTime.UtcNow
        };

        // Matematik Bölümü zorunlu ders listesi
        yield return new RequiredCourseList
        {
            Id = Mathematics1RequiredCourseListId,
            Name = "Matematik Bölümü Zorunlu Dersler",
            Description = "Matematik bölümü öğrencileri için gerekli zorunlu dersler",
            CreatedDate = DateTime.UtcNow
        };

        // Makine Mühendisliği zorunlu ders listesi
        yield return new RequiredCourseList
        {
            Id = MechanicalEngineering1RequiredCourseListId,
            Name = "Makine Mühendisliği Zorunlu Dersler",
            Description = "Makine Mühendisliği bölümü öğrencileri için gerekli zorunlu dersler",
            CreatedDate = DateTime.UtcNow
        };
    }
}