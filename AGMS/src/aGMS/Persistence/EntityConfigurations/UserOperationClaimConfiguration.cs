using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.EntityConfigurations;

namespace Persistence.EntityConfigurations;

public class UserOperationClaimConfiguration : IEntityTypeConfiguration<UserOperationClaim>
{
    public void Configure(EntityTypeBuilder<UserOperationClaim> builder)
    {
        builder.ToTable("UserOperationClaims").HasKey(uoc => uoc.Id);

        builder.Property(uoc => uoc.Id).HasColumnName("Id").IsRequired();
        builder.Property(uoc => uoc.UserId).HasColumnName("UserId").IsRequired();
        builder.Property(uoc => uoc.OperationClaimId).HasColumnName("OperationClaimId").IsRequired();
        builder.Property(uoc => uoc.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(uoc => uoc.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(uoc => uoc.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(uoc => !uoc.DeletedDate.HasValue);

        builder.HasOne(uoc => uoc.User)
               .WithMany(u => u.UserOperationClaims)
               .HasForeignKey(uoc => uoc.UserId);

        builder.HasOne(uoc => uoc.OperationClaim)
               .WithMany()
               .HasForeignKey(uoc => uoc.OperationClaimId);

        builder.HasData(GetSeeds());
    }

    private IEnumerable<UserOperationClaim> GetSeeds()
    {
        // System Admin - Admin rolü
        yield return new UserOperationClaim
        {
            Id = Guid.NewGuid(),
            UserId = UserConfiguration.SystemAdminUserId,
            OperationClaimId = OperationClaimConfiguration.AdminId,
            CreatedDate = DateTime.UtcNow
        };

        // Öğrenciler - Student rolü
        yield return new UserOperationClaim
        {
            Id = Guid.NewGuid(),
            UserId = UserConfiguration.StudentUserId,
            OperationClaimId = OperationClaimConfiguration.StudentId,
            CreatedDate = DateTime.UtcNow
        };

        yield return new UserOperationClaim
        {
            Id = Guid.NewGuid(),
            UserId = UserConfiguration.StudentUserId2,
            OperationClaimId = OperationClaimConfiguration.StudentId,
            CreatedDate = DateTime.UtcNow
        };

        yield return new UserOperationClaim
        {
            Id = Guid.NewGuid(),
            UserId = UserConfiguration.StudentUserId3,
            OperationClaimId = OperationClaimConfiguration.StudentId,
            CreatedDate = DateTime.UtcNow
        };

        yield return new UserOperationClaim
        {
            Id = Guid.NewGuid(),
            UserId = UserConfiguration.StudentUserId4,
            OperationClaimId = OperationClaimConfiguration.StudentId,
            CreatedDate = DateTime.UtcNow
        };

        yield return new UserOperationClaim
        {
            Id = Guid.NewGuid(),
            UserId = UserConfiguration.StudentUserId5,
            OperationClaimId = OperationClaimConfiguration.StudentId,
            CreatedDate = DateTime.UtcNow
        };

        yield return new UserOperationClaim
        {
            Id = Guid.NewGuid(),
            UserId = UserConfiguration.StudentUserId6,
            OperationClaimId = OperationClaimConfiguration.StudentId,
            CreatedDate = DateTime.UtcNow
        };

        yield return new UserOperationClaim
        {
            Id = Guid.NewGuid(),
            UserId = UserConfiguration.StudentUserId7,
            OperationClaimId = OperationClaimConfiguration.StudentId,
            CreatedDate = DateTime.UtcNow
        };

        yield return new UserOperationClaim
        {
            Id = Guid.NewGuid(),
            UserId = UserConfiguration.StudentUserId8,
            OperationClaimId = OperationClaimConfiguration.StudentId,
            CreatedDate = DateTime.UtcNow
        };

        yield return new UserOperationClaim
        {
            Id = Guid.NewGuid(),
            UserId = UserConfiguration.StudentUserId9,
            OperationClaimId = OperationClaimConfiguration.StudentId,
            CreatedDate = DateTime.UtcNow
        };

        yield return new UserOperationClaim
        {
            Id = Guid.NewGuid(),
            UserId = UserConfiguration.StudentUserId10,
            OperationClaimId = OperationClaimConfiguration.StudentId,
            CreatedDate = DateTime.UtcNow
        };

        yield return new UserOperationClaim
        {
            Id = Guid.NewGuid(),
            UserId = UserConfiguration.StudentUserId11,
            OperationClaimId = OperationClaimConfiguration.StudentId,
            CreatedDate = DateTime.UtcNow
        };

        yield return new UserOperationClaim
        {
            Id = Guid.NewGuid(),
            UserId = UserConfiguration.StudentUserId12,
            OperationClaimId = OperationClaimConfiguration.StudentId,
            CreatedDate = DateTime.UtcNow
        };

        yield return new UserOperationClaim
        {
            Id = Guid.NewGuid(),
            UserId = UserConfiguration.StudentUserId13,
            OperationClaimId = OperationClaimConfiguration.StudentId,
            CreatedDate = DateTime.UtcNow
        };

        yield return new UserOperationClaim
        {
            Id = Guid.NewGuid(),
            UserId = UserConfiguration.StudentUserId14,
            OperationClaimId = OperationClaimConfiguration.StudentId,
            CreatedDate = DateTime.UtcNow
        };

        yield return new UserOperationClaim
        {
            Id = Guid.NewGuid(),
            UserId = UserConfiguration.StudentUserId15,
            OperationClaimId = OperationClaimConfiguration.StudentId,
            CreatedDate = DateTime.UtcNow
        };

        yield return new UserOperationClaim
        {
            Id = Guid.NewGuid(),
            UserId = UserConfiguration.StudentUserId16,
            OperationClaimId = OperationClaimConfiguration.StudentId,
            CreatedDate = DateTime.UtcNow
        };

        yield return new UserOperationClaim
        {
            Id = Guid.NewGuid(),
            UserId = UserConfiguration.StudentUserId17,
            OperationClaimId = OperationClaimConfiguration.StudentId,
            CreatedDate = DateTime.UtcNow
        };

        yield return new UserOperationClaim
        {
            Id = Guid.NewGuid(),
            UserId = UserConfiguration.StudentUserId18,
            OperationClaimId = OperationClaimConfiguration.StudentId,
            CreatedDate = DateTime.UtcNow
        };

        // Student Affairs Staff - StudentAffairsStaff rolü
        yield return new UserOperationClaim
        {
            Id = Guid.NewGuid(),
            UserId = UserConfiguration.StudentAffairsStaffUserId,
            OperationClaimId = OperationClaimConfiguration.StudentAffairsStaffId,
            CreatedDate = DateTime.UtcNow
        };

        // Danışmanlar - Advisor rolü
        yield return new UserOperationClaim
        {
            Id = Guid.NewGuid(),
            UserId = UserConfiguration.ComputerEngineeringAdvisorUserId1,
            OperationClaimId = OperationClaimConfiguration.AdvisorId,
            CreatedDate = DateTime.UtcNow
        };



        yield return new UserOperationClaim
        {
            Id = Guid.NewGuid(),
            UserId = UserConfiguration.ElectricalEngineeringAdvisorUserId1,
            OperationClaimId = OperationClaimConfiguration.AdvisorId,
            CreatedDate = DateTime.UtcNow
        };



        yield return new UserOperationClaim
        {
            Id = Guid.NewGuid(),
            UserId = UserConfiguration.PhysicsAdvisorUserId1,
            OperationClaimId = OperationClaimConfiguration.AdvisorId,
            CreatedDate = DateTime.UtcNow
        };


        yield return new UserOperationClaim
        {
            Id = Guid.NewGuid(),
            UserId = UserConfiguration.ChemistryAdvisorUserId1,
            OperationClaimId = OperationClaimConfiguration.AdvisorId,
            CreatedDate = DateTime.UtcNow
        };



        yield return new UserOperationClaim
        {
            Id = Guid.NewGuid(),
            UserId = UserConfiguration.MathematicsAdvisorUserId1,
            OperationClaimId = OperationClaimConfiguration.AdvisorId,
            CreatedDate = DateTime.UtcNow
        };



        yield return new UserOperationClaim
        {
            Id = Guid.NewGuid(),
            UserId = UserConfiguration.MechanicalEngineeringAdvisorUserId1,
            OperationClaimId = OperationClaimConfiguration.AdvisorId,
            CreatedDate = DateTime.UtcNow
        };



        // Department Secretary - DepartmentSecretary rolü
        yield return new UserOperationClaim
        {
            Id = Guid.NewGuid(),
            UserId = UserConfiguration.DepartmentSecretaryUserId,
            OperationClaimId = OperationClaimConfiguration.DepartmentSecretaryId,
            CreatedDate = DateTime.UtcNow
        };

        // Elektrik-Elektronik Mühendisliği Bölüm Sekreteri - DepartmentSecretary rolü
        yield return new UserOperationClaim
        {
            Id = Guid.NewGuid(),
            UserId = UserConfiguration.ElectricalEngineeringDepartmentSecretaryUserId,
            OperationClaimId = OperationClaimConfiguration.DepartmentSecretaryId,
            CreatedDate = DateTime.UtcNow
        };

        // Fizik Bölümü Sekreteri - DepartmentSecretary rolü
        yield return new UserOperationClaim
        {
            Id = Guid.NewGuid(),
            UserId = UserConfiguration.PhysicsDepartmentSecretaryUserId,
            OperationClaimId = OperationClaimConfiguration.DepartmentSecretaryId,
            CreatedDate = DateTime.UtcNow
        };

        // Deans Office Staff - DeansOfficeStaff rolü
        yield return new UserOperationClaim
        {
            Id = Guid.NewGuid(),
            UserId = UserConfiguration.DeansOfficeStaffUserId,
            OperationClaimId = OperationClaimConfiguration.DeansOfficeStaffId,
            CreatedDate = DateTime.UtcNow
        };

        // Fen Fakültesi Dekanlık Personeli - DeansOfficeStaff rolü
        yield return new UserOperationClaim
        {
            Id = Guid.NewGuid(),
            UserId = UserConfiguration.ScienceFacultyDeansOfficeStaffUserId,
            OperationClaimId = OperationClaimConfiguration.DeansOfficeStaffId,
            CreatedDate = DateTime.UtcNow
        };
    }
}
