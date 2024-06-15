using Functional_Student_Assessment.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Functional_Student_Assessment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        [Route("get-student-grade")]
        public IActionResult GetStudentGrade([FromQuery] string studentNumber)
        {
            var studentGrade = InMemoryDatabase.StudentGrades.FirstOrDefault(s => s.StudentNumber == studentNumber);

            if (studentGrade == null)
            {
                return NotFound();
            }

            var recommendedStrands = InMemoryDatabase.GetRecommendedStrands(studentGrade);


            studentGrade.FirstChoice = recommendedStrands.Item1;
            studentGrade.SecondChoice = recommendedStrands.Item2;

            // Redirect to StudentDetails action to display student information
            return Ok(studentGrade);
        }

      
    }
}
