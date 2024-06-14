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

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult RecommendStrand(string studentNumber)
        {
            var studentGrade = InMemoryDatabase.StudentGrades.FirstOrDefault(s => s.StudentNumber == studentNumber);
            if (studentGrade == null)
            {
                return NotFound(); // Return a 404 error if student not found
            }

            var recommendedStrands = Strand.GetRecommendedStrands(studentGrade.Math, studentGrade.English, studentGrade.Science,
                                                                  studentGrade.History, studentGrade.Values, studentGrade.Filipino,
                                                                  studentGrade.TLE);

            ViewBag.RecommendedStrands = recommendedStrands;

            return View("StudentDetails", studentGrade);
        }

        [HttpPost]
        public IActionResult Index(string studentNumber)
        {
            if (string.IsNullOrEmpty(studentNumber))
            {
                return RedirectToAction("Index"); // Redirect back to the homepage or show an error
            }

            var studentGrade = InMemoryDatabase.StudentGrades.FirstOrDefault(s => s.StudentNumber == studentNumber);

            if (studentGrade == null)
            {
                return RedirectToAction("Index"); // Redirect back to the homepage or show an error
            }

            var recommendedStrands = InMemoryDatabase.GetRecommendedStrands(studentGrade);
            ViewBag.RecommendedStrands = recommendedStrands;

            return RedirectToAction("StudentDetails", studentGrade);
        }
        [HttpPost]
        public IActionResult EnterStudentNumber(string studentNumber)
        {  
            var studentGrade = InMemoryDatabase.StudentGrades.FirstOrDefault(s => s.StudentNumber == studentNumber);

            if (studentGrade == null)
            {
                return RedirectToAction("Index"); // Redirect back to homepage or show an error view
            }

            var recommendedStrands = InMemoryDatabase.GetRecommendedStrands(studentGrade);

            ViewBag.StudentGrade = studentGrade;
            ViewBag.RecommendedStrands = recommendedStrands;

            // Redirect to a page that displays the student's grade and recommended strand
            return RedirectToAction("StudentDetails");
        }

        public IActionResult StudentDetails(StudentGrade studentGrade)
        {
            if (studentGrade == null)
            {
                return RedirectToAction("Index"); // Handle the case gracefully if studentGrade is null
            }

            var recommendedStrands = ViewBag.RecommendedStrands;

            return View(studentGrade);
        }

       
        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
