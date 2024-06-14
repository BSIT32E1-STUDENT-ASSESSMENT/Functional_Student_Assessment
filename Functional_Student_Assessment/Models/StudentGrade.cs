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
        public double History { get; set; }
        public double Values { get; set; }
        public double Filipino { get; set; }
        public double TLE { get; set; }
    }
}
