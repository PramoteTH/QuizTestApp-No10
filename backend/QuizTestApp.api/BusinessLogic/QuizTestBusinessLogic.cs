using QuizTestApp.Models;

namespace QuizTestApp.BusinessLogic;

public static class QuizTestBusinessLogic
{
    public static TestResultModel ChcekTestAnswer(TestRequest request)
    {
        int totalPoint = 0;
        TestResultModel result = new();
        if (request.answer1 == 9)
        {
            totalPoint +=1;
        }
        if (request.answer2 == 2)
        {
            totalPoint +=1;
        }
        result.name = request.name;
        result.totalPoint = totalPoint;
        return result;
    }
}