using COMP2139_Labs.Areas.ProjectManagement.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace COMP2139_Labs.Data
{
    public class ApplicationDbContext: IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        
        //tables
            public DbSet<Project> Projects { get; set; }
            public DbSet<ProjectTask> ProjectTasks { get; set; }
            public DbSet<ProjectComment> ProjectComments { get; set; }
            //Add DbSet for other entities like Tasks in the Future

    }
}