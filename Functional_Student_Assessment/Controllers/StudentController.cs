using Microsoft.AspNetCore.Mvc;


using Functional_Student_Assessment.Models;

public class StudentController : Controller
{
    public ActionResult Index()
    {
        return View(InMemoryDatabase.StudentGrades);
    }

    public ActionResult AddGrade()
    {
        return View();
    }

    [HttpPost]
    public ActionResult AddGrade(StudentGrade studentGrade)
    {
        InMemoryDatabase.StudentGrades.Add(studentGrade);
        return RedirectToAction("Index");
    }

    public ActionResult RecommendStrand(int id)
    {
        var studentGrade = InMemoryDatabase.StudentGrades.FirstOrDefault(s => s.Id == id);
        if (studentGrade == null)
        {
            return NotFound(); // Change this line
        }
        var recommendedStrand = InMemoryDatabase.GetRecommendedStrand(studentGrade);
        ViewBag.RecommendedStrand = recommendedStrand;
        return View(studentGrade);
    }

}

