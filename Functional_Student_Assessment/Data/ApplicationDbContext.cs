﻿using Functional_Student_Assessment.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Functional_Student_Assessment.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Add DbSet for StudentGrade entity
        public DbSet<StudentGrade> StudentGrades { get; set; }
    }
}
