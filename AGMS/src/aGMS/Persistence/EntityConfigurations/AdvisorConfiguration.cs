using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class AdvisorConfiguration : IEntityTypeConfiguration<Advisor>
{
    // Bilgisayar Mühendisliği Danışmanları
    public static readonly Guid ComputerEngineeringAdvisorId1 = Guid.Parse("11111111-1111-1111-1111-111111111111");


    // Elektrik-Elektronik Mühendisliği Danışmanları
    public static readonly Guid ElectricalEngineeringAdvisorId1 = Guid.Parse("22222222-2222-2222-2222-222222222222");


    // Fizik Bölümü Danışmanları
    public static readonly Guid PhysicsAdvisorId1 = Guid.Parse("33333333-3333-3333-3333-333333333333");


    // Kimya Bölümü Danışmanları
    public static readonly Guid ChemistryAdvisorId1 = Guid.Parse("44444444-4444-4444-4444-444444444444");


    // Matematik Bölümü Danışmanları
    public static readonly Guid MathematicsAdvisorId1 = Guid.Parse("55555555-5555-5555-5555-555555555555");


    // Makine Mühendisliği Danışmanları
    public static readonly Guid MechanicalEngineeringAdvisorId1 = Guid.Parse("66666666-6666-6666-6666-666666666666");


    public void Configure(EntityTypeBuilder<Advisor> builder)
    {
        builder.ToTable("Advisors").HasKey(a => a.Id);

        builder.Property(a => a.Id).HasColumnName("Id").IsRequired();
        builder.Property(a => a.DepartmentId).HasColumnName("DepartmentId").IsRequired();
        builder.Property(a => a.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(a => a.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(a => a.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(a => !a.DeletedDate.HasValue);

        // Department ile ilişki
        builder.HasOne(a => a.Department)
               .WithMany(d => d.Advisors)
               .HasForeignKey(a => a.DepartmentId)
               .OnDelete(DeleteBehavior.Restrict);

        // User ile ilişki (TPT - Table Per Type)
        builder.HasOne(a => a.User)
               .WithOne()
               .HasForeignKey<Advisor>(a => a.Id)
               .OnDelete(DeleteBehavior.Restrict);

        // GraduationList ile ilişki
        builder.HasOne(a => a.GraduationList)
               .WithOne(gl => gl.Advisor)
               .HasForeignKey<GraduationList>(gl => gl.AdvisorId)
               .OnDelete(DeleteBehavior.Restrict);

        // Students ile ilişki
        builder.HasMany(a => a.Students)
               .WithOne(s => s.AssignedAdvisor)
               .HasForeignKey(s => s.AssignedAdvisorId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasData(GetSeeds());
    }

    private IEnumerable<Advisor> GetSeeds()
    {
        var now = DateTime.UtcNow;

        // Bilgisayar Mühendisliği Danışmanları
        yield return new Advisor
        {
            Id = ComputerEngineeringAdvisorId1,
            DepartmentId = DepartmentConfiguration.ComputerEngineeringDepartmentId,
            CreatedDate = now
        };



        // Elektrik-Elektronik Mühendisliği Danışmanları
        yield return new Advisor
        {
            Id = ElectricalEngineeringAdvisorId1,
            DepartmentId = DepartmentConfiguration.ElectricalEngineeringDepartmentId,
            CreatedDate = now,

        };



        // Fizik Bölümü Danışmanları
        yield return new Advisor
        {
            Id = PhysicsAdvisorId1,
            DepartmentId = DepartmentConfiguration.PhysicsDepartmentId,
            CreatedDate = now
        };



        // Kimya Bölümü Danışmanları
        yield return new Advisor
        {
            Id = ChemistryAdvisorId1,
            DepartmentId = DepartmentConfiguration.ChemistryDepartmentId,
            CreatedDate = now
        };



        // Matematik Bölümü Danışmanları
        yield return new Advisor
        {
            Id = MathematicsAdvisorId1,
            DepartmentId = DepartmentConfiguration.MathematicsDepartmentId,
            CreatedDate = now
        };

  

        // Makine Mühendisliği Danışmanları
        yield return new Advisor
        {
            Id = MechanicalEngineeringAdvisorId1,
            DepartmentId = DepartmentConfiguration.MechanicalEngineeringDepartmentId,
            CreatedDate = now
        };


    }
}