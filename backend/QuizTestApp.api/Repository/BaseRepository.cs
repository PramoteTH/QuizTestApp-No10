using QuizTestApp.Data;
using QuizTestApp.Models;
using Microsoft.EntityFrameworkCore;

namespace QuizTestApp.Repository;

public class BaseRepository : IBaseRepository
{
    private readonly AppDbContext _context;

    public BaseRepository(AppDbContext context)
    {
        _context = context;
    }

    public TestResultModel AddAsync(TestResultModel item)
    {
        _context.testResultModel.Add(item);
        _context.SaveChanges();
        return item;
    }

    public List<TestResultModel> GetAllAsync()
    {
        return _context.testResultModel
            .ToList();
    }
}
