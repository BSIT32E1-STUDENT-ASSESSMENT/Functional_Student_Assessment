@model Student

@using (Html.BeginForm("SubmitGrades", "Teacher", FormMethod.Post))
{
    @* Your input fields for grades here *@
    <input type="submit" value="Submit Grades" />
}