using HospitalManagementSystem.Models;
using HospitalManagementSystem.Repository;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceptionistController : Controller
    {
        private readonly ReceptionistRepository rt;
        public ReceptionistController(ReceptionistRepository receptionistRepository)
        {
            this.rt = receptionistRepository;

        }
        [HttpGet]
        public async Task<ActionResult> ReceptionistList()
        {
            var allReceptionists = await rt.GetAllReceptionists();
            return Ok(allReceptionists);
        }
        [HttpPost]
        public async Task<ActionResult> AddReceptionist(Receptionist ar)
        {
            await rt.SaveReceptionist(ar);
            return Ok(ar);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> updateReceptionist(int id, [FromBody] Receptionist vm)
        {
            await rt.updateReceptionist(id, vm);
            return Ok(vm);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> deleteReceptionist(int id)
        {
            await rt.DeleteReceptionist(id);
            return Ok();
        }
    }
}
