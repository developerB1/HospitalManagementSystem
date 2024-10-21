using HospitalManagementSystem.Models;
using HospitalManagementSystem.Repository;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem.Controllers
{
    public class NurseController : Controller
    {
        private readonly NurseRepository ns;
        public NurseController(NurseRepository nurseRepository)
        {
            this.ns = nurseRepository;

        }
        [HttpGet]
        public async Task<ActionResult> NurseList()
        {
            var allNurses = await ns.GetAllNurses();
            return Ok(allNurses);
        }
        [HttpPost]
        public async Task<ActionResult> AddNurse(Nurse an)
        {
            await ns.SaveNurse(an);
            return Ok(an);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> updateNurse(int id, [FromBody] Nurse vm)
        {
            await ns.updateNurse(id, vm);
            return Ok(vm);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> deleteNurse(int id)
        {
            await ns.DeleteNurse(id);
            return Ok();
        }
    }
}
