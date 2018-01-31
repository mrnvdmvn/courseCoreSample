using CoursesManipulator.Data.Entities;

namespace CoursesManipulator.Data.Repositories
{
    public class CourseRepository : BaseRepository<Course>, ICourseRepository
    {

        public CourseRepository(CoursesContext context)
            :base(context)
        {

        }

    }
}
