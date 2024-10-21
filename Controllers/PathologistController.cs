using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem.Controllers
{
    public class PathologistController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
