using HospitalManagementSystem.Models;
using HospitalManagementSystem.Repository;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly PatientRepository pt;
        public PatientController(PatientRepository patientRepository)
        {
            this.pt = patientRepository;

        }
        [HttpGet]
        public async Task<ActionResult> PatientList()
        {
            var allPatients = await pt.GetAllPatients();
            return Ok(allPatients);
        }
        [HttpPost]
        public async Task<ActionResult> AddPatient(Patient ap)
        {
            await pt.SavePatient(ap);
            return Ok(ap);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> updatePatient(int id, [FromBody] Patient vm)
        {
            await pt.updatePatient(id, vm);
            return Ok(vm);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> deletePatient(int id)
        {
            await pt.DeletePatient(id);
            return Ok();
        }
    }
}
