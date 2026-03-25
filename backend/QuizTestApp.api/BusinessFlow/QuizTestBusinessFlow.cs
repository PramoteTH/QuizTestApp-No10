using QuizTestApp.Models;
using QuizTestApp.Repository;
using QuizTestApp.Service;
using QuizTestApp.BusinessLogic;

namespace QuizTestApp.BusinessFlow;

public class QuizTestBusinessFlow
{
    private readonly IBaseRepository _baseRepository;
    private readonly IQuizTestService _service;
    public QuizTestBusinessFlow (IBaseRepository baseRepository, IQuizTestService service)
    {
        _baseRepository = baseRepository;
        _service = service;
    }
    public virtual TestResultModel SubmitTest(TestRequest request)
    {
        TestResultModel result = QuizTestBusinessLogic.ChcekTestAnswer(request);
        _service.CreateAsync(result);
        return result;
    }
}