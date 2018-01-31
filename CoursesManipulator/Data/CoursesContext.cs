using CoursesManipulator.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoursesManipulator.Data
{
    public class CoursesContext : DbContext
    {
        public CoursesContext(DbContextOptions<CoursesContext> options) 
            : base(options)
        {

        }

        public DbSet<Course> Courses  { get; set; }
    }
}
