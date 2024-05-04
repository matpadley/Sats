using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Sats.Models;
using Sats.Services;

namespace Sats.Controllers;

public class HomeController : Controller
{
    private readonly QuestionService _questionService;

    public HomeController()
    {
        _questionService = new QuestionService();
    }
/*
    public ActionResult Index()
    {
        var question = _questionService.GenerateQuestion();
        return View(question);
    }
  */  
    public ActionResult Index()
    {
        var questions = new List<ArithmeticQuestion>();
        for (int i = 0; i < 36; i++)
        {
            questions.Add(_questionService.GenerateQuestion());
        }
        return View(questions);
    }
    
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

}