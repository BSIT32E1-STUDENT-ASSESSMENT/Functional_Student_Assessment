using Functional_Student_Assessment.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Functional_Student_Assessment.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View(InMemoryDatabase.StudentGrades);
        }

        public IActionResult AddGrade()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddGrade(StudentGrade studentGrade)
        {
            InMemoryDatabase.StudentGrades.Add(studentGrade);
            return RedirectToAction("Index");
        }

        public IActionResult RecommendStrands(int id)
        {
            var studentGrade = InMemoryDatabase.StudentGrades.FirstOrDefault(s => s.Id == id);
            if (studentGrade == null)
            {
                return NotFound();
            }

            var recommendedStrands = InMemoryDatabase.GetRecommendedStrands(studentGrade);
            ViewBag.RecommendedStrands = recommendedStrands;

            return View("RecommendStrands", studentGrade); // Here
        }

    }
}