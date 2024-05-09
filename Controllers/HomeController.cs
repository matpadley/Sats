using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Sats.Models;

namespace Sats.Controllers;

/// <summary>
/// Represents the controller for the home page and related actions.
/// </summary>
public class HomeController : Controller
{

    /// <summary>
    /// Displays the index page with a list of arithmetic questions.
    /// </summary>
    /// <returns>The view containing the list of arithmetic questions.</returns>
    public ActionResult Index()
    {
        var random = new Random();
        var questions = new List<ArithmeticQuestion>(random.Next(3));
        for (var i = 0; i < 36; i++)
        {
            questions.Add(new ArithmeticQuestion(random));
        }
        return View(questions);
    }
    
    /// <summary>
    /// Displays the fractions page with a list of fractions questions.
    /// </summary>
    /// <returns>The view containing the list of fractions questions.</returns>
    public ActionResult Fractions()
    {
        var questions = new List<FractionsQuestion>();
        for (var i = 0; i < 36; i++)
        {
            questions.Add(new FractionsQuestion());
        }
        return View(questions);
    }
    
    /// <summary>
    /// Displays the privacy page.
    /// </summary>
    /// <returns>The view for the privacy page.</returns>
    public IActionResult Privacy()
    {
        return View();
    }

    /// <summary>
    /// Displays the error page.
    /// </summary>
    /// <returns>The view for the error page.</returns>
    /// [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

}