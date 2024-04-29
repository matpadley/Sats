using Microsoft.AspNetCore.Mvc;

namespace Sats.Controllers;

public class QuestionController : Controller
{
    private readonly QuestionService _questionService;

    public QuestionController()
    {
        _questionService = new QuestionService();
    }

    public ActionResult Index()
    {
        var question = _questionService.GenerateQuestion();
        return View(question);
    }
    
    public ActionResult Multiple()
    {
        var questions = new List<ArithmeticQuestion>();
        for (int i = 0; i < 36; i++)
        {
            questions.Add(_questionService.GenerateQuestion());
        }
        return View(questions);
    }

}