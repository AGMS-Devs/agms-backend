using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class MessageConfiguration : IEntityTypeConfiguration<Message>
{
    public void Configure(EntityTypeBuilder<Message> builder)
    {
        builder.ToTable("Messages").HasKey(m => m.Id);

        builder.Property(m => m.Id).HasColumnName("Id").IsRequired();
        builder.Property(m => m.Content).HasColumnName("Content");
        builder.Property(m => m.SentAt).HasColumnName("SentAt");
        builder.Property(m => m.AdvisorId).HasColumnName("AdvisorId");
        builder.Property(m => m.StudentNumber).HasColumnName("StudentNumber");
        builder.Property(m => m.IsRead).HasColumnName("IsRead");
        builder.Property(m => m.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(m => m.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(m => m.DeletedDate).HasColumnName("DeletedDate");

        // Foreign Key relationship - Advisor
        builder.HasOne(m => m.Advisor)
               .WithMany()
               .HasForeignKey(m => m.AdvisorId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasQueryFilter(m => !m.DeletedDate.HasValue);
    }
}