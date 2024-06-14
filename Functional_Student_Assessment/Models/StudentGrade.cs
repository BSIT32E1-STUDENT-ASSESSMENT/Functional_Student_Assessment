
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

    // New properties for recommended strand
    public string RecommendedStrandName { get; set; }
    public string RecommendedStrandDescription { get; set; }
}

}
