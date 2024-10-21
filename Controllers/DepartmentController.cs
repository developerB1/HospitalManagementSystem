using HospitalManagementSystem.Models;
using HospitalManagementSystem.Repository;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly DepartmentRepository dp;
        public DepartmentController(DepartmentRepository departmentRepository)
        {
            this.dp = departmentRepository;

        }
        [HttpGet]
        public async Task<ActionResult> DepartmentList()
        {
            var allDepartments = await dp.GetAllDepartments();
            return Ok(allDepartments);
        }
        [HttpPost]
        public async Task<ActionResult> AddDepartment(Department ad)
        {
            await dp.SaveDepartment(ad);
            return Ok(ad);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> updateDepartment(int id, [FromBody] Department vm)
        {
            await dp.updateDepartment(id, vm);
            return Ok(vm);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> deleteDepartment(int id)
        {
            await dp.DeleteDepartment(id);
            return Ok();
        }
    }
}
