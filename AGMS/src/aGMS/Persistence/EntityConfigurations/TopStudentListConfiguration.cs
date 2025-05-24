using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class TopStudentListConfiguration : IEntityTypeConfiguration<TopStudentList>
{
    public void Configure(EntityTypeBuilder<TopStudentList> builder)
    {
        builder.ToTable("TopStudentLists").HasKey(tsl => tsl.Id);

        builder.Property(tsl => tsl.Id).HasColumnName("Id").IsRequired();
        builder.Property(tsl => tsl.TopStudentListType).HasColumnName("TopStudentListType").IsRequired();
        builder.Property(tsl => tsl.StudentAffairsApproval).HasColumnName("StudentAffairsApproval").IsRequired();
        builder.Property(tsl => tsl.StudentAffairsStaffId).HasColumnName("StudentAffairsStaffId").IsRequired();
        builder.Property(tsl => tsl.RectorateApproval).HasColumnName("RectorateApproval").IsRequired();
        builder.Property(tsl => tsl.RectorateStaffId).HasColumnName("RectorateStaffId").IsRequired();
        builder.Property(tsl => tsl.SendRectorate).HasColumnName("SendRectorate").IsRequired();
        builder.Property(tsl => tsl.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(tsl => tsl.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(tsl => tsl.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(tsl => !tsl.DeletedDate.HasValue);

        // Staff ilişkileri
        builder.HasOne(tsl => tsl.StudentAffairsStaff)
               .WithMany(s => s.StudentAffairsTopStudentLists)
               .HasForeignKey(tsl => tsl.StudentAffairsStaffId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(tsl => tsl.RectorateStaff)
               .WithMany(s => s.RectorateTopStudentLists)
               .HasForeignKey(tsl => tsl.RectorateStaffId)
               .OnDelete(DeleteBehavior.Restrict);

        // Student many-to-many ilişkisi
        builder.HasMany(tsl => tsl.Students)
               .WithMany()
               .UsingEntity(j => j.ToTable("TopStudentListStudents"));
    }
}