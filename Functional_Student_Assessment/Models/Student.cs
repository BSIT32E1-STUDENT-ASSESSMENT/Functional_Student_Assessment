public class Student
{
    public int StudentId { get; set; }
    public string Name { get; set; }
    public int GradeLevel { get; set; }
    public Dictionary<string, int> Grades { get; set; } = new Dictionary<string, int>();
    public StrandChoice StrandChoices { get; set; } = new StrandChoice();
}

public class StrandChoice
{
    public string FirstChoice { get; set; }
    public string SecondChoice { get; set; }
}
