namespace Functional_Student_Assessment.Models
{
    public class Strand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string RecommendedForFirstChoice { get; set; } // First choice recommendation based on grades
        public string RecommendedForSecondChoice { get; set; } // Second choice recommendation based on grades

        public static (string, string) GetRecommendedStrands(int math, int english, int science, int history, int values, int filipino, int tle)
        {
            // Determine the highest grade among all subjects
            int highestGrade = Math.Max(math, Math.Max(english, Math.Max(science, Math.Max(history, Math.Max(values, Math.Max(filipino, tle))))));

            // Variables to store recommended strands
            string firstChoice = "";
            string secondChoice = "";

            // Determine the recommended strands based on the highest grade
            if (highestGrade == science)
            {
                firstChoice = "STEM";
                secondChoice = "ICT";
            }
            else if (highestGrade == math)
            {
                firstChoice = "ABM";
                secondChoice = "STEM";
            }
            else if (highestGrade == english)
            {
                firstChoice = "HUMSS";
                secondChoice = "GAS";
            }
            else if (highestGrade == filipino)
            {
                firstChoice = "GAS";
                secondChoice = "HUMSS";
            }
            else if (highestGrade == values)
            {
                firstChoice = "HUMSS";
                secondChoice = "GAS";
            }
            else if (highestGrade == history)
            {
                firstChoice = "GAS";
                secondChoice = "STEM";
            }
            else if (highestGrade == tle)
            {
                firstChoice = "IA";
                secondChoice = "HE";
            }

            return (firstChoice, secondChoice);
        }
    }
}
