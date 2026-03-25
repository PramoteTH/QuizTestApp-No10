using Microsoft.EntityFrameworkCore;
using QuizTestApp.Models;

namespace QuizTestApp.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<TestResultModel> testResultModel { get; set; }
}