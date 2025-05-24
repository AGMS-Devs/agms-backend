using Application.Features.Auth.Constants;
using Application.Features.OperationClaims.Constants;
using Application.Features.UserOperationClaims.Constants;
using Application.Features.Users.Constants;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NArchitecture.Core.Security.Constants;
using Application.Features.Students.Constants;
using Application.Features.Rectorates.Constants;
using Application.Features.Advisors.Constants;
using Application.Features.Messages.Constants;
using Application.Features.Staffs.Constants;
using Application.Features.Courses.Constants;
using Application.Features.Transcripts.Constants;
using Application.Features.FileAttachments.Constants;
using Application.Features.FacultyDeansOffices.Constants;

namespace Persistence.EntityConfigurations;

public class OperationClaimConfiguration : IEntityTypeConfiguration<OperationClaim>
{
    public void Configure(EntityTypeBuilder<OperationClaim> builder)
    {
        builder.ToTable("OperationClaims").HasKey(oc => oc.Id);

        builder.Property(oc => oc.Id).HasColumnName("Id").IsRequired();
        builder.Property(oc => oc.Name).HasColumnName("Name").IsRequired();
        builder.Property(oc => oc.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(oc => oc.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(oc => oc.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(oc => !oc.DeletedDate.HasValue);

        builder.HasData(_seeds);
    }

    // Sabit ID'ler
    public static Guid AdminId => new("11111111-1111-1111-1111-111111111111");
    public static Guid StudentId => new("22222222-2222-2222-2222-222222222222");
    public static Guid StudentAffairsStaffId => new("33333333-3333-3333-3333-333333333333");
    public static Guid AdvisorId => new("44444444-4444-4444-4444-444444444444");
    public static Guid DepartmentSecretaryId => new("55555555-5555-5555-5555-555555555555");
    public static Guid DeansOfficeStaffId => new("66666666-6666-6666-6666-666666666666");

    private static readonly HashSet<OperationClaim> _seeds = new()
    {
        new() { Id = AdminId, Name = "Admin" },
        new() { Id = StudentId, Name = "Student" },
        new() { Id = StudentAffairsStaffId, Name = "StudentAffairsStaff" },
        new() { Id = AdvisorId, Name = "Advisor" },
        new() { Id = DepartmentSecretaryId, Name = "DepartmentSecretary" },
        new() { Id = DeansOfficeStaffId, Name = "DeansOfficeStaff" }
    };

    private static HashSet<OperationClaim> GetFeatureOperationClaims()
    {
        HashSet<OperationClaim> featureOperationClaims = new();
        // Feature-specific claims can be added here
        return featureOperationClaims;
    }
}