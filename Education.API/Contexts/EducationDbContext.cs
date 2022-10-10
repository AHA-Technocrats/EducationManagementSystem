using Education.API.Model;
using Microsoft.EntityFrameworkCore;

namespace Education.API.Contexts
{
    public class EducationDbContext:DbContext
    {
        public  EducationDbContext(DbContextOptions options):base(options)
        {

        }

        // Dbset 

        public DbSet<Students> Students { get; set; }
        public DbSet<Courses> Courses { get; set; }
        public DbSet<Teachers> Teachers { get; set; }
        public DbSet<Grades> Grades { get; set; }
        public DbSet<Subjects> Subjects { get; set; }
        public DbSet<CourseSubjectsMapping> CourseSubjectsMapping { get; set; }
        public DbSet<TeacherStudentsMapping> TeacherStudentsMapping { get; set; }
    }
}
