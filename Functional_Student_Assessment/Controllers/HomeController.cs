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
        [HttpPost]
        public IActionResult Index(string studentNumber)
        {
            if (string.IsNullOrEmpty(studentNumber))
            {
                // Handle the case where studentNumber is not provided
                return RedirectToAction("Index"); // Redirect back to the homepage or show an error
            }

            var studentGrade = InMemoryDatabase.StudentGrades.FirstOrDefault(s => s.StudentNumber == studentNumber);

            if (studentGrade == null)
            {
                // Handle the case where student with given studentNumber is not found
                return RedirectToAction("Index"); // Redirect back to the homepage or show an error
            }

            var recommendedStrands = InMemoryDatabase.GetRecommendedStrands(studentGrade);
            ViewBag.RecommendedStrands = recommendedStrands;

            return RedirectToAction("StudentDetails", studentGrade);
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

        public IActionResult StudentDetails(StudentGrade studentGrade)
        {
            if (studentGrade == null)
            {
                return RedirectToAction("Index"); // Handle the case gracefully if studentGrade is null
            }

            var recommendedStrands = ViewBag.RecommendedStrands;

            return View(studentGrade);
        }

        public IActionResult RecommendStrand(string studentNumber)
        {
            var studentGrade = InMemoryDatabase.StudentGrades.FirstOrDefault(s => s.StudentNumber == studentNumber);
            if (studentGrade == null)
            {
                return NotFound(); // Return a 404 error if student not found
            }

            // Get recommended strands based on existing grades
            var recommendedStrands = InMemoryDatabase.GetRecommendedStrands(studentGrade);

            // Store recommended strands in ViewBag for displaying in the view
            ViewBag.RecommendedStrands = recommendedStrands;

            // Pass student grade object to the view
            return View("StudentDetails", studentGrade);
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
