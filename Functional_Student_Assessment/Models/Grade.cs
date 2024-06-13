namespace Functional_Student_Assessment.Models
{
    public class Grade
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public string Subject { get; set; }
        public int Year { get; set; }
        public double Score { get; set; }
    }

}
