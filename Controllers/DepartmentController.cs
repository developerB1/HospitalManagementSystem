using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem.Controllers
{
    public class DepartmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
