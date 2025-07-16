using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using MOJTask.Models;
using System.Collections.Generic;

namespace MOJTask.Data
{
    public class MOJTaskDbContext : DbContext
    {
        public MOJTaskDbContext(DbContextOptions<MOJTaskDbContext> options) : base(options)
        {

        }
        public DbSet<CaseWorkerTask> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CaseWorkerTask>().HasData(
                new CaseWorkerTask
                {
                    Id = 1,
                    Title = "Check all court order",
                    Description = "They are expected for the end of the month",
                    Status = "Pending",
                    DueDate = new DateTime(2025, 6, 1)
                },
                new CaseWorkerTask
                {
                    Id = 2,
                    Title = "Read and submit the arraignment policies",
                    Description = "Needed for August evaluations",
                    Status = "InProgress",
                    DueDate = new DateTime(2025, 6,2)
                },
                new CaseWorkerTask
                {
                    Id = 3,
                    Title = "Finish report",
                    Description = "Report done",
                    Status = "Done",
                    DueDate = new DateTime(2025, 6, 3)
                }
            );

        }

        // For dev only
        public void Initialise()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
    }
}
