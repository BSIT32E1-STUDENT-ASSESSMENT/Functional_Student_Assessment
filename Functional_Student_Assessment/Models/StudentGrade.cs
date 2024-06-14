
namespace Functional_Student_Assessment.Models
{
    public class StudentGrade
    {
        public int Id { get; set; }
        public string StudentName { get; set; }
        public int GradeLevel { get; set; }
        public int Math { get; set; }
        public int English { get; set; }
        public int Science { get; set; }
        public int Filipino { get; set; }
        public int History { get; set; }

        // Properties for recommendations
        public string RecommendedStrandName1 { get; set; }
        public string RecommendedStrandDescription1 { get; set; }
        public string RecommendedStrandName2 { get; set; }
        public string RecommendedStrandDescription2 { get; set; }
    }

}
