using Microsoft.AspNetCore.Mvc;
using Functional_Student_Assessment.Models;
using System.Linq;
using Functional_Student_Assessment.Data;

public class StudentController : Controller
{
    private readonly ApplicationDbContext _context;

    public StudentController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var studentGrades = _context.StudentGrades.ToList();

        foreach (var studentGrade in studentGrades)
        {
            studentGrade.RecommendedStrandName = CalculateRecommendedStrandName(studentGrade);
            studentGrade.RecommendedStrandDescription = CalculateRecommendedStrandDescription(studentGrade);
        }

        return View(studentGrades);
    }

    private string CalculateRecommendedStrandName(StudentGrade studentGrade)
    {
        // Implement your logic here to determine the recommended strand name based on the student's grades
        return "Recommended Strand Name"; // Replace with your actual logic
    }

    private string CalculateRecommendedStrandDescription(StudentGrade studentGrade)
    {
        // Implement your logic here to determine the recommended strand description based on the student's grades
        return "Recommended Strand Description"; // Replace with your actual logic
    }

    public IActionResult AddGrade()
    {
        return View();
    }

    [HttpPost]
    public IActionResult AddGrade(StudentGrade studentGrade)
    {
        studentGrade.RecommendedStrandName = "Default Strand Name";
        studentGrade.RecommendedStrandDescription = "Default Strand Description";

        _context.StudentGrades.Add(studentGrade);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    public IActionResult RecommendStrand(int id)
    {
        var studentGrade = _context.StudentGrades.FirstOrDefault(s => s.Id == id);
        if (studentGrade == null)
        {
            return NotFound();
        }
        var recommendedStrand = CalculateRecommendedStrandName(studentGrade);
        ViewBag.RecommendedStrand = recommendedStrand;
        return View(studentGrade);
    }
}
