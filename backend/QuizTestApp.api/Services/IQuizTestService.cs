using QuizTestApp.Models;

namespace QuizTestApp.Service;

public interface IQuizTestService
{
    List<TestResultModel> GetAllAsync();
    TestResultModel CreateAsync(TestResultModel model);
}