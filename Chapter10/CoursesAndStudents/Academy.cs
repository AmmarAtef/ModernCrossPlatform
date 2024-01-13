using Microsoft.EntityFrameworkCore;
using static System.Console;

namespace CoursesAndStudents
{
    public class Academy : DbContext
    {
        public DbSet<Student>? Students { get; set; }
        public DbSet<Course>? Courses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=.;Initial Catalog=Academy;Integrated Security=true;MultipleActiveResultSets=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Fluent APi validation rules
            modelBuilder.Entity<Student>()
                .Property(s => s.LastName).HasMaxLength(30).IsRequired();

            // populate  database with sample data 
            Student alice = new Student
            {
                FirstName = "Alice",
                LastName = "Mohamed",
                StudentId = 1,
            };

            Student bob = new Student
            {
                FirstName = "Bob",
                LastName = "Mohamed",
                StudentId = 2
            };


            Student cecilia = new Student
            {
                FirstName = "Cecilia",
                LastName = "Mohamed",
                StudentId = 3
            };


            Course course = new Course
            {
                CourseId = 1,
                Title = "C# 10 and .Net 6"
            };

            Course webDev = new Course
            {
                CourseId = 2,
                Title = "Web Development"
            };

            Course python = new Course
            {
                CourseId = 3,
                Title = "Python for Beginners"
            };


            modelBuilder.Entity<Student>()
                .HasData(alice, cecilia, bob);

            modelBuilder.Entity<Course>()
                .HasData(webDev, python, course);

            modelBuilder.Entity<Course>()
                .HasMany(r => r.Students)
                .WithMany(c => c.Courses)
                .UsingEntity(e => e.HasData(
                        new { CoursesCourseId = 1, StudentsStudentId = 1 },
                        new { CoursesCourseId = 2, StudentsStudentId = 2 },
                        new { CoursesCourseId = 3, StudentsStudentId = 3 },
                        new { CoursesCourseId = 2, StudentsStudentId = 1 }
                    ));


        }
    }
}
