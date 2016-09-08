using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Mapping;
using Model;

namespace Data
{
    public class SchoolContext : DbContext
    {
        public SchoolContext()
            : base("ConnectionStringName")
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Classroom> Classrooms { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            // Direct mapping
            modelBuilder.Entity<Classroom>()
                .HasMany(x => x.Teachers)
                .WithMany(c => c.Classrooms)
                .Map(m =>
                {
                    m.MapLeftKey("ClassromId");
                    m.MapRightKey("TeacherId");
                    m.ToTable("Classrooms_Teachers");
                });

            // Using mapping configuration class
            modelBuilder.Configurations.Add(new StudentsMapping());
            modelBuilder.Configurations.Add(new TeacherMapping());
        }
    }
}