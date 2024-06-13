using Humanizer;
using Microsoft.AspNetCore.Mvc.Rendering;

@model YourNamespace.Models.Student

@using(Html.BeginForm("SubmitGrades", "Teacher", FormMethod.Post))
{
    <div>
        < label > Name:</ label >
        @Html.TextBoxFor(m => m.Name)
    </ div >
    < div >
        < label > Grades:</ label >
        @*You will need to add input fields for each grade level and subject *@
    </ div >
    < input type = "submit" value = "Submit Grades" />
}