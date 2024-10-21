using HospitalManagementSystem.Data;
using HospitalManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementSystem.Repository
{
    public class DepartmentRepository
    {
        private readonly ApplicationDbContext db;
        public DepartmentRepository(ApplicationDbContext dbContext)
        {
            this.db = dbContext;
        }
        public async Task<List<Department>> GetAllDepartments()
        {
            return await db.Departments.ToListAsync();
        }
        public async Task SaveDepartment(Department dt)
        {
            await db.Departments.AddAsync(dt);
            await db.SaveChangesAsync();
        }
        public async Task updateDepartment(int id, Department obj)
        {
            var department = await db.Departments.FindAsync(id);
            if (department == null)
            {
                throw new Exception("Department not found");
            }
            department.DepartmentName = obj.DepartmentName;
            department.DepartmentNumber = obj.DepartmentNumber;

            await db.SaveChangesAsync();

        }

        public async Task DeleteDepartment(int id)
        {
            var department = await db.Departments.FindAsync(id);
            if (department == null)
            {
                throw new Exception("Department not found");
            }
            db.Departments.Remove(department);
            await db.SaveChangesAsync();
        }


    }
}
