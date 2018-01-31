using CoursesManipulator.Data.Entities;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CoursesManipulator.Data
{
    public class CoursesSeed
    {
        readonly CoursesContext ctx;
        readonly IHostingEnvironment hosting;

        public CoursesSeed(CoursesContext ctx, IHostingEnvironment hosting)
        {
            this.ctx = ctx;
            this.hosting = hosting;
        }

        public void Seed()
        {
            ctx.Database.EnsureCreated();

            if(!ctx.Courses.Any())
            {
                var path = Path.Combine(hosting.ContentRootPath, "Data/sample.json");
                var json = File.ReadAllText(path);

                var courses = JsonConvert.DeserializeObject<IEnumerable<Course>>(json);
                ctx.Courses.AddRange(courses);
                ctx.SaveChanges();
            }
        }
    }
}
