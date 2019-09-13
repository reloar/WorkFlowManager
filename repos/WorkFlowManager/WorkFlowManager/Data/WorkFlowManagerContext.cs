using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkFlowManager.Models;

namespace WorkFlowManager.Data
{
    public class WorkFlowManagerContext:DbContext
    {
        public WorkFlowManagerContext(DbContextOptions<WorkFlowManagerContext> options):base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Lecturer> Lecturers { get; set; }
        public DbSet<Courses> Courses { get; set; }
        public DbSet<Question> Questions { get; set; }

    }
}
