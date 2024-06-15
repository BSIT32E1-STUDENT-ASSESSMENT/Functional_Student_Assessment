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

        public IActionResult Test()
        {
            return Ok("test");
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
        public IActionResult EnterStudentNumber(string studentNumber)
        {
            var studentGrade = InMemoryDatabase.StudentGrades.FirstOrDefault(s => s.StudentNumber == studentNumber);

            if (studentGrade == null)
            {
                return RedirectToAction("Index"); // Handle the case where student is not found
            }

            var recommendedStrands = InMemoryDatabase.GetRecommendedStrands(studentGrade);

            ViewBag.StudentGrade = studentGrade;
            ViewBag.RecommendedStrands = recommendedStrands;

            studentGrade.FirstChoice = recommendedStrands.Item1;
            studentGrade.SecondChoice = recommendedStrands.Item2;

            // Redirect to StudentDetails action to display student information
            return RedirectToAction("StudentDetails",studentGrade);
        }

        [HttpGet]
        
        public IActionResult GetStudentGrade([FromQuery] string studentNumber)
        {
            var studentGrade = InMemoryDatabase.StudentGrades.FirstOrDefault(s => s.StudentNumber == studentNumber);

            if (studentGrade == null)
            {
                return RedirectToAction("Index"); // Handle the case where student is not found
            }

            var recommendedStrands = InMemoryDatabase.GetRecommendedStrands(studentGrade);

          
            studentGrade.FirstChoice = recommendedStrands.Item1;
            studentGrade.SecondChoice = recommendedStrands.Item2;

            // Redirect to StudentDetails action to display student information
            return Ok(studentGrade);
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
