
namespace Functional_Student_Assessment.Models
{
    public class StudentGrade
    {
        public int Id { get; set; }
        public string StudentName { get; set; }
        public int GradeLevel { get; set; }
        public double Math { get; set; }
        public double English { get; set; }
        public double Science { get; set; }
        // Add other subjects as needed
    }

}
