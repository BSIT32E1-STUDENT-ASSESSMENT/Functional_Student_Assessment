using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;

@model YourNamespace.ViewModels.StudentDashboardViewModel

<h1> Student Dashboard</h1>
<table>
    <thead>
        <tr>
            <th>Subject</th>
            <th>Grade</th>
        </tr>
    </thead>
    <tbody>
        @foreach (var grade in Model.Grades)
        {
            <tr>
                <td>@grade.Key</td>
                <td>@grade.Value</td>
            </tr>
        }
    </ tbody >
</ table >
< h2 > Strand Choices </ h2 >
< p > First Choice: @Model.StrandChoices.FirstChoice </ p >
< p > Second Choice: @Model.StrandChoices.SecondChoice </ p >
