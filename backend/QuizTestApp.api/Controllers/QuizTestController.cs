using Microsoft.AspNetCore.Mvc;
using QuizTestApp.Models;
using QuizTestApp.Repository;
using QuizTestApp.Service;
using QuizTestApp.BusinessFlow;

namespace QuizTestApp.Controllers;

[ApiController]
public class QuizTestController : ControllerBase
{
    private readonly IQuizTestService _service;
    private readonly QuizTestBusinessFlow _quizTestBusinessFlow;
    public QuizTestController(IQuizTestService service, QuizTestBusinessFlow quizTestBusinessFlow)
    {
        _service = service;
        _quizTestBusinessFlow = quizTestBusinessFlow;
    }
    
    [HttpGet("api/test-all")]
    public List<TestResultModel> GetTestAll()
    {
        return _service.GetAllAsync();
    }

    [HttpPost("api/submit-test")] 
    public TestResultModel SubmitTest(TestRequest request)
    {
        return _quizTestBusinessFlow.SubmitTest(request);
    }
}