using AutoMapper;
using CoursesManipulator.Data.Entities;
using CoursesManipulator.Data.Repositories;
using CoursesManipulator.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoursesManipulator.Services
{
    public class CourseService : ICourseService
    {
        readonly ICourseRepository repo;
        readonly IMapper mapper;

        public CourseService(ICourseRepository repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }

        public IEnumerable<CourseViewModel> GetCourses()
        {
            var result = repo.GetAll();
            return mapper.Map<IEnumerable<Course>, IEnumerable<CourseViewModel>>(result);
        }

        public CourseViewModel GetCourse(int id)
        {
            var result = repo.Get(id);
            return mapper.Map<Course, CourseViewModel>(result);
        }

        public void Add(CourseViewModel model)
        {
            var entity = mapper.Map<CourseViewModel, Course>(model);
            repo.Add(entity);
            repo.SaveChanges();
        }

        public void Edit(CourseViewModel model)
        {
            var found = repo.Get(model.CourseId.Value);
            mapper.Map(model, found);
            repo.Update(found);
            repo.SaveChanges();
        }

        public CourseViewModel Delete(int id)
        {
            try
            {
                var found = repo.Get(id);
                repo.Delete(found);
                repo.SaveChanges();
                return mapper.Map<Course, CourseViewModel>(found);

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
