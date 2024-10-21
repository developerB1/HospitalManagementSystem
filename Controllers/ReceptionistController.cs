using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem.Controllers
{
    public class ReceptionistController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
