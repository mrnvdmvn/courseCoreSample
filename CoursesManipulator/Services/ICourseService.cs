using CoursesManipulator.ViewModels;
using System.Collections.Generic;

namespace CoursesManipulator.Services
{
    public interface ICourseService
    {
        IEnumerable<CourseViewModel> GetCourses();
        CourseViewModel Delete(int id);
        CourseViewModel GetCourse(int id);
        void Add(CourseViewModel model);
        void Edit(CourseViewModel model);
    }
}
