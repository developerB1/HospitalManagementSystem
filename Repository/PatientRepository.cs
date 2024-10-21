using HospitalManagementSystem.Data;
using HospitalManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementSystem.Repository
{
    public class PatientRepository
    {
        private readonly ApplicationDbContext db;
        public PatientRepository(ApplicationDbContext dbContext)
        {
            this.db = dbContext;
        }
        public async Task<List<Patient>> GetAllPatients()
        {
            return await db.Patients.ToListAsync();
        }
        public async Task SavePatient(Patient pt)
        {
            await db.Patients.AddAsync(pt);
            await db.SaveChangesAsync();
        }
        public async Task updatePatient(int id, Patient obj)
        {
            var patient = await db.Patients.FindAsync(id);
            if (patient == null)
            {
                throw new Exception("Patient not found");
            }
            patient.Name = obj.Name;
            patient.Email = obj.Email;
            patient.Mobile = obj.Mobile;
            patient.Age = obj.Age;
            patient.Gender = obj.Gender;

            await db.SaveChangesAsync();

        }

        public async Task DeletePatient(int id)
        {
            var patient = await db.Patients.FindAsync(id);
            if (patient == null)
            {
                throw new Exception("Patient not found");
            }
            db.Patients.Remove(patient);
            await db.SaveChangesAsync();
        }
    }
}