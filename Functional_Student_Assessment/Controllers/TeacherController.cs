using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Web.Mvc;
using YourNamespace.Models; // Adjust the namespace to match your project

public class TeacherController : Controller
{
    // Action to display input form for grades
    public ActionResult InputGrades()
    {
        return View();
    }

    // Action to handle submitted grades
    [HttpPost]
    public ActionResult SubmitGrades(Student student)
    {
        // Calculate strand based on grades
        student.Strand = CalculateStrand(student.Grades);

        // Save the student to a database or perform any other necessary operations

        return View("StrandResult", student);
    }

    // Method to calculate the strand based on grades
    private string CalculateStrand(Dictionary<string, Dictionary<string, double>> grades)
    {
        // Your logic to determine the best strand based on grades
        // For simplicity, let's assume we return "STEM"
        return "STEM";
    }
}