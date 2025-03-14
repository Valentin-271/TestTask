using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyTestTask.Entities;

namespace MyTestTask.Configurations;

public class ResultConfiguration : IEntityTypeConfiguration<Result>
{
    public void Configure(EntityTypeBuilder<Result> builder)
    {
        builder.HasIndex(r => r.InterviewId);
        
        builder.HasIndex(r => new { r.QuestionId, r.AnswerId });
    }
}