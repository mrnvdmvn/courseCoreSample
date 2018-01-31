using CoursesManipulator.Services;
using CoursesManipulator.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CoursesManipulator.Controllers
{
    public class CourseController : BaseController
    {
        readonly ICourseService courseService;

        public CourseController(ICourseService courseService)
        {
            this.courseService = courseService;
        }

        [HttpGet("courses")]
        public IActionResult Courses()
        {
            return View();
        }


        [HttpGet("course/add")]
        public IActionResult Add()
        {
            ViewBag.IsEdit = false;
            return View("CourseModel");
        }

        [HttpGet("course/edit/{id}")]
        public IActionResult Edit(int id)
        {
            try
            {
                ViewBag.IsEdit = true;
                var found = courseService.GetCourse(id);
                return View("CourseModel",found);
            }
            catch(Exception)
            {
                return BadRequest("Failed to edit cource");
            }
        }

        [HttpPost]
        public IActionResult Edit(CourseViewModel model)
        {
            if (ModelState.IsValid)
            {
                courseService.Edit(model);
                return RedirectToAction("Courses");
            }
            else
            {
                return BadRequest("Failed to edit cource");
            }
        }


        [HttpPost]
        public IActionResult Add(CourseViewModel model)
        {
            if(ModelState.IsValid)
            {
                courseService.Add(model);
                return RedirectToAction("Courses");
            }
            else
            {
                return BadRequest("Failed to add cource");
            }
        }
    }
}
