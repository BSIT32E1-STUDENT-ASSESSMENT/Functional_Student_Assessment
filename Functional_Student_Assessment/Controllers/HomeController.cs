using Functional_Student_Assessment.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Functional_Student_Assessment.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [HttpPost]
        public IActionResult EnterStudentNumber(string studentNumber)
        {
            // Find the student based on the entered student number
            var studentGrade = InMemoryDatabase.StudentGrades.FirstOrDefault(s => s.StudentNumber == studentNumber);

            if (studentGrade == null)
            {
                // Student not found, handle accordingly (e.g., show an error message)
                return RedirectToAction("Index"); // Redirect back to homepage or show an error view
            }

            // Get recommended strands for the student
            var recommendedStrands = InMemoryDatabase.GetRecommendedStrands(studentGrade);

            // Pass the student grade and recommended strands to the view
            ViewBag.StudentGrade = studentGrade;
            ViewBag.RecommendedStrands = recommendedStrands;

            // Redirect to a page that displays the student's grade and recommended strands
            return RedirectToAction("StudentDetails");
        }

        public IActionResult StudentDetails()
        {
            // Retrieve ViewBag data and display the student's details
            var studentGrade = ViewBag.StudentGrade as StudentGrade;
            var recommendedStrands = ViewBag.RecommendedStrands as (Strand, Strand);

            if (studentGrade == null || recommendedStrands == (null, null))
            {
                // Handle scenario where data is missing or not found
                return RedirectToAction("Index"); // Redirect back to homepage or show an error view
            }

            return View(studentGrade);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
