using HospitalManagementSystem.Models;
using HospitalManagementSystem.Repository;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem.Controllers
{
    public class DoctorController : Controller
    {
        private readonly DoctorRepository dr;
        public DoctorController(DoctorRepository doctorRepository)
        {
            this.dr = doctorRepository;

        }
        [HttpGet]
        public async Task<ActionResult> DoctorList()
        {
            var allDoctors = await dr.GetAllDoctors();
            return Ok(allDoctors);
        }
        [HttpPost]
        public async Task<ActionResult> AddDoctor(Doctor ad)
        {
            await dr.SaveDoctor(ad);
            return Ok(ad);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> updateDoctor(int id, [FromBody] Doctor vm)
        {
            await dr.updateDoctor(id, vm);
            return Ok(vm);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> deleteDoctor(int id)
        {
            await dr.DeleteDoctor(id);
            return Ok();
        }
    }
}
