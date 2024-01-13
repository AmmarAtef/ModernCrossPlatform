using static System.Console;
using Microsoft.EntityFrameworkCore;
using CoursesAndStudents;


using (Academy a = new Academy())
{
    bool deleted = await a.Database.EnsureDeletedAsync();
    WriteLine($"Database deleted: {deleted}");


    bool created = await a.Database.EnsureCreatedAsync();
    WriteLine($"Database created: {created}");

    WriteLine("SQL script used to create database:");
    WriteLine(a.Database.GenerateCreateScript());

    foreach (Student st in a.Students.Include(x => x.Courses))
    {
        WriteLine($"{st.FirstName} {st.LastName} attends the following {st.Courses.Count} courses: ");

        foreach (Course course in st.Courses)
        {
            WriteLine($"{course.Title}");
        }
    }
}