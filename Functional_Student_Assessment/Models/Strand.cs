namespace Functional_Student_Assessment.Models
{
    public class Strand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string RecommendedFor { get; set; } // Add logic to determine recommendation based on grades
    }

}
