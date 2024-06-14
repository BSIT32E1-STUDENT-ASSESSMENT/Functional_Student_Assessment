using Functional_Student_Assessment.Models;
using System.Collections.Generic;
using System.Linq;

namespace Functional_Student_Assessment
{
    public static class InMemoryDatabase
    {
        public static List<StudentGrade> StudentGrades { get; } = new List<StudentGrade>();

        public static List<string> GetRecommendedStrands(StudentGrade studentGrade)
        {
            var recommendedStrands = new List<string>();

            // Determine the subject with the highest grade
            var maxGradeSubject = new Dictionary<string, double>
    {
        { "Math", studentGrade.Math },
        { "Science", studentGrade.Science },
        { "English", studentGrade.English },
        { "Filipino", studentGrade.Filipino },
        { "Values", studentGrade.Values },
        { "History", studentGrade.History }
    }.OrderByDescending(x => x.Value)
            .First().Key;

            // Check the highest grade subject and recommend strands accordingly
            if (maxGradeSubject == "Math" || maxGradeSubject == "Science")
            {
                recommendedStrands.Add("STEM");
                recommendedStrands.Add("ABM");
            }
            else if (maxGradeSubject == "English" || maxGradeSubject == "Filipino")
            {
                recommendedStrands.Add("ABM");
                recommendedStrands.Add("HUMSS");
            }
            else
            {
                recommendedStrands.Add("ABM");
                recommendedStrands.Add("HE");
            }

            return recommendedStrands;
        }


    }
}