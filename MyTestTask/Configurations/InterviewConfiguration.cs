using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyTestTask.Entities;

namespace MyTestTask.Configurations;

public class InterviewConfiguration : IEntityTypeConfiguration<Interview>
{
    public void Configure(EntityTypeBuilder<Interview> builder)
    {
        builder
            .HasMany(i => i.Results)
            .WithOne(r => r.Interview)
            .HasForeignKey(r => r.InterviewId);
    }
}