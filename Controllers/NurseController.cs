using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem.Controllers
{
    public class NurseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
