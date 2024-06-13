using System.Diagnostics;

namespace Functional_Student_Assessment.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Grade> Grades { get; set; }
        public string Strand { get; set; }
    }
}
