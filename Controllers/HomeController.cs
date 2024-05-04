using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Sats.Models;
using Sats.Services;

namespace Sats.Controllers;

public class HomeController : Controller
{
    private readonly QuestionService _questionService = new();

    public ActionResult Index()
    {
        var questions = new List<ArithmeticQuestion>();
        for (int i = 0; i < 36; i++)
        {
            questions.Add(new ArithmeticQuestion());
        }
        return View(questions);
    }
    
    public ActionResult Fractions()
    {
        var questions = new List<FractionsQuestion>();
        for (int i = 0; i < 36; i++)
        {
            questions.Add(_questionService.GenerateFractionsQuestion());
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