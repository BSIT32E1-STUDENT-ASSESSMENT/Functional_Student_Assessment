@model YourNamespace.ViewModels.TeacherDashboardViewModel

<h1> Teacher Dashboard</h1>
<form asp-action="InputGrades" method="post">
    <label for="studentId">Student ID:</ label >
    < input type = "text" id = "studentId" name = "studentId" >
    < label for= "subject" > Subject:</ label >
    < input type = "text" id = "subject" name = "subject" >
    < label for= "grade" > Grade:</ label >
    < input type = "text" id = "grade" name = "grade" >
    < button type = "submit" > Submit </ button >
</ form >
