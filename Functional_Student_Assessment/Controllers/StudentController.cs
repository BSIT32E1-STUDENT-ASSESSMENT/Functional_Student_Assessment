using Microsoft.AspNetCore.Mvc;
using Functional_Student_Assessment.Data;
using Functional_Student_Assessment.Models;
using System.Linq;
using System.Collections.Generic;

namespace Functional_Student_Assessment.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Action for teachers to enter grades
        [HttpGet]
        public IActionResult EnterGrades()
        {
            return View();
        }

        [HttpPost]
        public IActionResult EnterGrades(int studentId, List<Grade> grades)
        {
            var student = _context.Students.Find(studentId);
            if (student != null)
            {
                student.Grades.AddRange(grades);
                _context.SaveChanges();
            }
            return RedirectToAction("Index", "Home");
        }

        // Action for students to view their strand
        public IActionResult ViewStrand(int studentId)
        {
            var student = _context.Students.Find(studentId);
            if (student != null)
            {
                student.Strand = DetermineStrand(student);
                _context.SaveChanges();
                return View(student);
            }
            return NotFound();
        }

        private string DetermineStrand(Student student)
        {
            // Implement your logic to determine the strand based on grades
            // Example logic (simplified):
            double average = student.Grades.Average(g => g.Score);
            if (average >= 90) return "STEM";
            if (average >= 75) return "ABM";
            return "HUMSS";
        }
    }
}
