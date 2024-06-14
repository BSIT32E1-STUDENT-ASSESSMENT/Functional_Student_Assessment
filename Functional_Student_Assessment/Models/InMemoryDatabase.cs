using Functional_Student_Assessment.Models;
using System.Collections.Generic;
using System.Linq;

public static class InMemoryDatabase
{
    public static List<StudentGrade> StudentGrades { get; set; } = new List<StudentGrade>();
    public static List<Strand> Strands { get; set; } = new List<Strand>();

    static InMemoryDatabase()
    {
        // Example: Adding dummy student grades for testing
        StudentGrades.Add(new StudentGrade
        {
            StudentNumber = "12345",
            StudentName = "John Doe",
            Math = 85,
            English = 90,
            Science = 88,
            History = 82,
            Values = 75,
            Filipino = 87,
            TLE = 80
        });

        // Seed with some strands for demonstration purposes
        Strands.Add(new Strand { Id = 1, Name = "STEM", Description = "Science, Technology, Engineering, and Mathematics", RecommendedForFirstChoice = "Math", RecommendedForSecondChoice = "Science" });
        Strands.Add(new Strand { Id = 2, Name = "ABM", Description = "Accountancy, Business, and Management", RecommendedForFirstChoice = "English", RecommendedForSecondChoice = "Math" });
        Strands.Add(new Strand { Id = 3, Name = "HUMSS", Description = "Humanities and Social Sciences", RecommendedForFirstChoice = "English", RecommendedForSecondChoice = "Social Studies" });
        // Add more strands as needed
    }

    public static (string, string) GetRecommendedStrands(StudentGrade studentGrade)
    {
        // Determine the recommended strands based on the highest grades in subjects
        var recommendedStrandNames = Strand.GetRecommendedStrands(studentGrade.Math, studentGrade.English, studentGrade.Science, studentGrade.History, studentGrade.Values, studentGrade.Filipino, studentGrade.TLE);

        // Return the recommended strand names
        return recommendedStrandNames;
    }
}
