using Moq;
using QuizTestApp.Controllers;
using QuizTestApp.Models;
using QuizTestApp.Service;
using QuizTestApp.BusinessFlow;

namespace QuizTest.Tests.Controllers;

[TestClass]
public class QuizTestControllerTest
{
    private Mock<IQuizTestService> _serviceMock = null!;
    private Mock<QuizTestBusinessFlow> _businessFlowMock = null!;
    private QuizTestController _controller = null!;

    [TestInitialize]
    public void Setup()
    {
        _serviceMock = new Mock<IQuizTestService>();
        _businessFlowMock = new Mock<QuizTestBusinessFlow>(
            Mock.Of<QuizTestApp.Repository.IBaseRepository>(),
            _serviceMock.Object
        );
        _controller = new QuizTestController(_serviceMock.Object, _businessFlowMock.Object);
    }

    [TestMethod]
    public void GetTestAll_ReturnsListFromService()
    {
        List<TestResultModel> expected = new ()
        {
            new() { id = 1, name = "Tor", totalPoint = 2 },
            new() { id = 2, name = "Ann", totalPoint = 1 }
        };
        _serviceMock.Setup(s => s.GetAllAsync()).Returns(expected);

        List<TestResultModel> result = _controller.GetTestAll();

        Assert.AreEqual(2, result.Count);
        Assert.AreEqual("Tor", result[0].name);
    }

    [TestMethod]
    public void GetTestAll_WhenNoData_ReturnsEmptyList()
    {
        _serviceMock.Setup(s => s.GetAllAsync()).Returns(new List<TestResultModel>());

        List<TestResultModel> result = _controller.GetTestAll();

        Assert.AreEqual(0, result.Count);
    }

    [TestMethod]
    public void SubmitTest_ReturnsResultFromBusinessFlow()
    {
        TestRequest request = new() { name = "Tor", answer1 = 1, answer2 = 3 };
        TestResultModel expected = new() { id = 1, name = "Tor", totalPoint = 2 };
        _businessFlowMock.Setup(b => b.SubmitTest(request)).Returns(expected);

        TestResultModel result = _controller.SubmitTest(request);

        Assert.AreEqual("Tor", result.name);
        Assert.AreEqual(2, result.totalPoint);
    }

    [TestMethod]
    public void SubmitTest_CallsBusinessFlowOnce()
    {
        TestRequest request = new() { name = "Tor", answer1 = 1, answer2 = 3 };
        _businessFlowMock.Setup(b => b.SubmitTest(request)).Returns(new TestResultModel());

        _controller.SubmitTest(request);

        _businessFlowMock.Verify(b => b.SubmitTest(request), Times.Once);
    }
}
