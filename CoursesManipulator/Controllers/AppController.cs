using Microsoft.AspNetCore.Mvc;

namespace CoursesManipulator.Controllers
{
    public class AppController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
