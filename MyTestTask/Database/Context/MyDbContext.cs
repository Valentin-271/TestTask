using Microsoft.EntityFrameworkCore;
using MyTestTask.Configurations;
using MyTestTask.Entities;

namespace MyTestTask.Database.Context;

public class MyDbContext(DbContextOptions<MyDbContext> options)
    : DbContext(options)
{
    public DbSet<Survey> Surveys { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<Answer> Answers { get; set; }
    public DbSet<Interview> Interviews { get; set; }
    public DbSet<Result> Results { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new QuestionConfiguration());
        modelBuilder.ApplyConfiguration(new InterviewConfiguration());
        modelBuilder.ApplyConfiguration(new AnswerConfiguration());
        modelBuilder.ApplyConfiguration(new ResultConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}