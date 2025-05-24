using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class GraduationListConfiguration : IEntityTypeConfiguration<GraduationList>
{
    public static readonly Guid CengList1Id = new("b07416a8-3151-48bf-a2e1-e3c5863f2683");
    public static readonly Guid CengList2Id = new("45de4353-3db3-4e30-99b9-68b04cdb7089");
    public static readonly Guid CengList3Id = new("3c3ddd76-1bc8-4a70-8fc2-e8f6ba85b379");
    public static readonly Guid EeList1Id = new("abfb59be-9c96-490f-9c4e-100c15c0c337");
    public static readonly Guid EeList2Id = new("3a3e59d7-21d6-4aa0-880e-f471039d2227");
    public static readonly Guid EeList3Id = new("75a619fa-2d6b-486b-b0a4-748a1bf6e3e9");
    public static readonly Guid PhysList1Id = new("a44b3d2f-ab86-4f4e-92ef-fd61b2894bf1");
    public static readonly Guid PhysList2Id = new("57fea0a1-99b2-420d-a1f5-73045996a0ce");
    public static readonly Guid PhysList3Id = new("9ad495f5-e393-4584-9aac-1c2ed24104bb");
    public static readonly Guid ChemList1Id = new("d47dc5ec-0974-4ed7-a24d-99bfba1aac06");
    public static readonly Guid ChemList2Id = new("67a92d78-3ea9-4374-a01d-edcb3b14d566");
    public static readonly Guid MathList1Id = new("c70e2d92-b390-4511-978b-e058c34c9099");
    public static readonly Guid MathList2Id = new("9cc804b6-cad5-484f-8806-4cb8d28d05df");
    public static readonly Guid MeList1Id = new("655cc5b8-b540-4d45-b716-bf095f0e7ba4");
    public static readonly Guid MeList2Id = new("79cace77-5720-434d-97b6-0d47a61468a3");

    public void Configure(EntityTypeBuilder<GraduationList> builder)
    {
        builder.ToTable("GraduationLists").HasKey(gl => gl.Id);

        builder.Property(gl => gl.Id).HasColumnName("Id").IsRequired();
        builder.Property(gl => gl.GraduationListNumber).HasColumnName("GraduationListNumber");
        builder.Property(gl => gl.AdvisorId).HasColumnName("AdvisorId").IsRequired();
        builder.Property(gl => gl.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(gl => gl.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(gl => gl.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(gl => !gl.DeletedDate.HasValue);

        builder.HasOne(gl => gl.Advisor)
               .WithOne(a => a.GraduationList)
               .HasForeignKey<GraduationList>(gl => gl.AdvisorId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(gl => gl.GraduationProcesses)
               .WithOne(gp => gp.GraduationList)
               .HasForeignKey(gp => gp.GraduationListId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasData(GetSeeds());
    }

    private IEnumerable<GraduationList> GetSeeds()
    {
        // Bilgisayar Mühendisliği Bölümü
        yield return new GraduationList
        {
            Id = CengList1Id,
            GraduationListNumber = "CENG-2024-001",
            AdvisorId = UserConfiguration.ComputerEngineeringAdvisorUserId1,
            CreatedDate = DateTime.UtcNow
        };





        // Elektrik-Elektronik Mühendisliği Bölümü
        yield return new GraduationList
        {
            Id = EeList1Id,
            GraduationListNumber = "EE-2024-001",
            AdvisorId = UserConfiguration.ElectricalEngineeringAdvisorUserId1,
            CreatedDate = DateTime.UtcNow
        };



        // Fizik Bölümü
        yield return new GraduationList
        {
            Id = PhysList1Id,
            GraduationListNumber = "PHYS-2024-001",
            AdvisorId = UserConfiguration.PhysicsAdvisorUserId1,
            CreatedDate = DateTime.UtcNow
        };



        // Kimya Bölümü
        yield return new GraduationList
        {
            Id = ChemList1Id,
            GraduationListNumber = "CHEM-2024-001",
            AdvisorId = UserConfiguration.ChemistryAdvisorUserId1,
            CreatedDate = DateTime.UtcNow
        };

 

        // Matematik Bölümü
        yield return new GraduationList
        {
            Id = MathList1Id,
            GraduationListNumber = "MATH-2024-001",
            AdvisorId = UserConfiguration.MathematicsAdvisorUserId1,
            CreatedDate = DateTime.UtcNow
        };



        // Makine Mühendisliği Bölümü
        yield return new GraduationList
        {
            Id = MeList1Id,
            GraduationListNumber = "ME-2024-001",
            AdvisorId = UserConfiguration.MechanicalEngineeringAdvisorUserId1,
            CreatedDate = DateTime.UtcNow
        };


    }
}