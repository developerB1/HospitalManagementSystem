using HospitalManagementSystem.Models;
using HospitalManagementSystem.Repository;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
            await ph.SavePathologist(aph);
            return Ok(aph);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> updatePathologist(int id, [FromBody] Pathologist vm)
        {
            await ph.updatePathologist(id, vm);
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
