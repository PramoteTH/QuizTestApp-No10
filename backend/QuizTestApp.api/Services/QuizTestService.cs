using QuizTestApp.Models;
using QuizTestApp.Repository;

namespace QuizTestApp.Service;

public class QuizTestService : IQuizTestService
{
    private readonly IBaseRepository _baseRepository;
    public QuizTestService (IBaseRepository baseRepository)
    {
        _baseRepository = baseRepository;
    }
    public List<TestResultModel> GetAllAsync()
    {
        return _baseRepository.GetAllAsync();
    }
    public TestResultModel CreateAsync(TestResultModel model)
    {
        _baseRepository.AddAsync(model);
        return model;
    }
}