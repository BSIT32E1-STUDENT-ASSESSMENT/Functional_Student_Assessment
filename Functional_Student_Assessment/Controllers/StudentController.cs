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
            var recommendations = GetRecommendedStrand(studentGrade);
            studentGrade.RecommendedStrandName1 = recommendations.Item1;
            studentGrade.RecommendedStrandDescription1 = recommendations.Item2;
            studentGrade.RecommendedStrandName2 = recommendations.Item3;
            studentGrade.RecommendedStrandDescription2 = recommendations.Item4;
        }

        return View(studentGrades);
    }

    private (string, string, string, string) GetRecommendedStrand(StudentGrade student)
    {
        string strandName1 = null;
        string strandDescription1 = null;
        string strandName2 = null;
        string strandDescription2 = null;

        if (student.Math >= 85 && student.Science >= 85)
        {
            strandName1 = "STEM";
            strandDescription1 = "Science, Technology, Engineering, and Mathematics";
            strandName2 = "ICT";
            strandDescription2 = "Information and Communication Technology";
        }
        else if (student.English >= 85 || student.Filipino >= 85)
        {
            strandName1 = "HUMSS";
            strandDescription1 = "Humanities and Social Sciences";
            strandName2 = "ABM";
            strandDescription2 = "Accountancy and Business Management";
        }
        else if (student.History >= 85)
        {
            strandName1 = "HUMSS";
            strandDescription1 = "Humanities and Social Sciences";
            strandName2 = "Home Economics";
            strandDescription2 = "Home Economics";
        }
        else if (student.Science >= 85)
        {
            strandName1 = "Industrial Arts";
            strandDescription1 = "Industrial Arts";
        }
        else if (student.Math >= 85)
        {
            strandName1 = "ABM";
            strandDescription1 = "Accountancy and Business Management";
            strandName2 = "ICT";
            strandDescription2 = "Information and Communication Technology";
        }

        return (strandName1, strandDescription1, strandName2, strandDescription2);
    }

    public IActionResult RecommendStrand(int id)
    {
        var studentGrade = _context.StudentGrades.FirstOrDefault(s => s.Id == id);
        if (studentGrade == null)
        {
            return NotFound();
        }

        var recommendations = GetRecommendedStrand(studentGrade);
        ViewBag.RecommendedStrand1 = recommendations.Item1;
        ViewBag.RecommendedStrandDescription1 = recommendations.Item2;
        ViewBag.RecommendedStrand2 = recommendations.Item3;
        ViewBag.RecommendedStrandDescription2 = recommendations.Item4;

        return View(studentGrade);
    }

    [HttpPost]
    public IActionResult AddGrade(StudentGrade studentGrade)
    {
        _context.StudentGrades.Add(studentGrade);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
}
