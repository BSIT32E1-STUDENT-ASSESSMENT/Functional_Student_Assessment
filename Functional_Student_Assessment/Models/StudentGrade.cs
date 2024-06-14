namespace Functional_Student_Assessment.Models
{
    public class StudentGrade
    {
        public string StudentNumber { get; set; } // New property for student number
        public int Id { get; set; }
        public string StudentName { get; set; }
        public string GradeLevel { get; set; }
        public int Math { get; set; }
        public int English { get; set; }
        public int Science { get; set; }
        public int History { get; set; }
        public int Values { get; set; }
        public int Filipino { get; set; }
        public int TLE { get; set; }
        public string FirstChoice { get; set; }
        public string SecondChoice { get; set; }
    }
}
