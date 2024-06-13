public class Student
{
    public string Name { get; set; }
    public Dictionary<string, Dictionary<string, double>> Grades { get; set; } // Dictionary<GradeLevel, Dictionary<Subject, Grade>>
    public string Strand { get; set; }
}