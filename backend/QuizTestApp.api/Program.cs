using Microsoft.EntityFrameworkCore;
using QuizTestApp.Data;
using QuizTestApp.Repository;
using QuizTestApp.Service;
using QuizTestApp.BusinessFlow;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection") ?? "Data Source=app.db"));

builder.Services.AddScoped<IBaseRepository, BaseRepository>();
builder.Services.AddScoped<IQuizTestService, QuizTestService>();
builder.Services.AddScoped<QuizTestBusinessFlow>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins("http://localhost:5173")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated();
}

app.UseCors("AllowFrontend");
app.MapControllers();

app.Run();

public partial class Program { }