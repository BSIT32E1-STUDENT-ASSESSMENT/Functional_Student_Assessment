
namespace Functional_Student_Assessment.Models
{
    public class StudentGrade
    {
        public int Id { get; set; }
        public string StudentName { get; set; }
        public string GradeLevel { get; set; }
        public double Math { get; set; }
        public double English { get; set; }
        public double Science { get; set; }
        public double Grade { get; set; }
        // Add other subjects as needed
    }

}
