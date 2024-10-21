using HospitalManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem.Controllers
{
    public class PathologistController : Controller
    {
        private readonly PathologistRepository ph;
        public PathologistController(PathologistRepository pathologistRepository)
        {
            this.ph = pathologistRepository;

        }
        [HttpGet]
        public async Task<ActionResult> PathologistList()
        {
            var allPathologists = await ph.GetAllPathologists();
            return Ok(allPathologists);
        }
        [HttpPost]
        public async Task<ActionResult> AddPathologist(Pathologist aph)
        {
            await ph.SavePatient(aph);
            return Ok(aph);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> updatePathologist(int id, [FromBody] Pathologist vm)
        {
            await ph.updatePatient(id, vm);
            return Ok(vm);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> deletePathologist(int id)
        {
            await ph.DeletePathologist(id);
            return Ok();
        }

    }
}
