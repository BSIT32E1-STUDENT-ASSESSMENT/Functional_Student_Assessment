using Functional_Student_Assessment.Models;
using System.Collections.Generic;
using System.Linq;

public static class InMemoryDatabase
{
    public static List<StudentGrade> StudentGrades { get; set; } = new List<StudentGrade>();
    public static List<Strand> Strands { get; set; } = new List<Strand>();

    static InMemoryDatabase()
    {
        // Seed with some strands for demonstration purposes
        Strands.Add(new Strand { Id = 1, Name = "STEM", Description = "Science, Technology, Engineering, and Mathematics", RecommendedFor = "Math, Science" });
        Strands.Add(new Strand { Id = 2, Name = "ABM", Description = "Accountancy, Business, and Management", RecommendedFor = "English, Math" });
        Strands.Add(new Strand { Id = 3, Name = "HUMSS", Description = "Humanities and Social Sciences", RecommendedFor = "English, Social Studies" });
        // Add more strands as needed
    }

    public static Strand GetRecommendedStrand(StudentGrade studentGrade)
    {
        // Simplified logic to recommend strand based on average grade
        var averageGrade = (studentGrade.Math + studentGrade.English + studentGrade.Science) / 3;
        if (averageGrade > 85)
        {
            return Strands.FirstOrDefault(s => s.Name == "STEM");
        }
        else if (averageGrade > 75)
        {
            return Strands.FirstOrDefault(s => s.Name == "ABM");
        }
        else
        {
            return Strands.FirstOrDefault(s => s.Name == "HUMSS");
        }
    }
}