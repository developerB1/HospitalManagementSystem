using HospitalManagementSystem.Data;
using HospitalManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementSystem.Repository
{
    public class DoctorRepository
    {
        private readonly ApplicationDbContext db;
        public DoctorRepository(ApplicationDbContext dbContext)
        {
            this.db = dbContext;
        }
        public async Task<List<Doctor>> GetAllDoctors()
        {
            return await db.Doctors.ToListAsync();
        }
        public async Task SaveDoctor(Doctor dr)
        {
            await db.Doctors.AddAsync(dr);
            await db.SaveChangesAsync();
        }
        public async Task updateDoctor(int id, Doctor obj)
        {
            var doctor = await db.Doctors.FindAsync(id);
            if (doctor == null)
            {
                throw new Exception("Doctor not found");
            }
            doctor.Name = obj.Name;
            doctor.Email = obj.Email;
            doctor.Mobile = obj.Mobile;
            doctor.Age = obj.Age;
            doctor.Gender = obj.Gender;

            await db.SaveChangesAsync();

        }

        public async Task DeleteDoctor(int id)
        {
            var doctor = await db.Doctors.FindAsync(id);
            if (doctor == null)
            {
                throw new Exception("Doctor not found");
            }
            db.Doctors.Remove(doctor);
            await db.SaveChangesAsync();
        }


    }
}
