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
        Strands.Add(new Strand { Id = 1, Name = "STEM", Description = "Science, Technology, Engineering, and Mathematics", RecommendedForFirstChoice = "Math", RecommendedForSecondChoice = "Science" });
        Strands.Add(new Strand { Id = 2, Name = "ABM", Description = "Accountancy, Business, and Management", RecommendedForFirstChoice = "English", RecommendedForSecondChoice = "Math" });
        Strands.Add(new Strand { Id = 3, Name = "HUMSS", Description = "Humanities and Social Sciences", RecommendedForFirstChoice = "English", RecommendedForSecondChoice = "Social Studies" });
        // Add more strands as needed
    }

    public static (Strand, Strand) GetRecommendedStrands(StudentGrade studentGrade)
    {
        // Determine the recommended strands based on the highest grades in subjects
        var recommendedStrandNames = Strand.GetRecommendedStrands(studentGrade.Math, studentGrade.English, studentGrade.Science, studentGrade.History, studentGrade.Values, studentGrade.Filipino, studentGrade.TLE);

        // Retrieve the recommended strands from the list of strands
        var firstChoiceStrand = Strands.FirstOrDefault(s => s.Name == recommendedStrandNames.Item1);
        var secondChoiceStrand = Strands.FirstOrDefault(s => s.Name == recommendedStrandNames.Item2);

        return (firstChoiceStrand, secondChoiceStrand);
    }
}
