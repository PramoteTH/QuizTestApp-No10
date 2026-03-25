using QuizTestApp.Data;
using QuizTestApp.Models;
using Microsoft.EntityFrameworkCore;

namespace QuizTestApp.Repository;

public interface IBaseRepository
{
    TestResultModel AddAsync(TestResultModel item);
    List<TestResultModel> GetAllAsync();
}
