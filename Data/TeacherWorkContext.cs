using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TeacherWork.Models;

namespace TeacherWork.Data
{
    
    public class TeacherWorkContext : DbContext
    {
        public TeacherWorkContext (DbContextOptions<TeacherWorkContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder mBuilder)
        {
            base.OnModelCreating(mBuilder);
            mBuilder.Entity<Class>().HasKey(c => new { c.Profession, c.Index });
        }

        public DbSet<Teacher> Teacher { get; set; }

        public DbSet<Class> Class { get; set; }
        public DbSet<Subject> Subject { get; set; }
        public DbSet<Course> Course { get; set; }
    }
}
