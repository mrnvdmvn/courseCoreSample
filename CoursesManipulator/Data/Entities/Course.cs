using System;

namespace CoursesManipulator.Data.Entities
{
    public class Course
    {
        public int CourseId { get; set; }
        public string Name { get; set; }
        public int Day { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }
}
