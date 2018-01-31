using CoursesManipulator.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CoursesManipulator.Controllers
{
    [Route("api/[Controller]")]
    public class CourceController : BaseController
    {
        readonly ICourseService courseService;

        public CourceController(ICourseService courseService)
        {
            this.courseService = courseService;
        }

        [HttpGet]
        public IActionResult Courses()
        {
            try
            {
                var found = courseService.GetCourses();
                return Ok(found);
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to get cources");
            }

        }

        [HttpDelete("{id}")]
        public IActionResult Course(int id)
        {
            try
            {
                var found = courseService.Delete(id);
                return Ok(found);
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to get cources");
            }

        }
    }
}