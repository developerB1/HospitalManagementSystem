using HospitalManagementSystem.Data;
using HospitalManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementSystem.Repository
{
    public class NurseRepository
    {
        private readonly ApplicationDbContext db;
        public NurseRepository(ApplicationDbContext dbContext)
        {
            this.db = dbContext;
        }
        public async Task<List<Nurse>> GetAllNurses()
        {
            return await db.Nurses.ToListAsync();
        }
        public async Task SaveNurse(Nurse nr)
        {
            await db.Nurses.AddAsync(nr);
            await db.SaveChangesAsync();
        }
        public async Task updateNurse(int id, Nurse obj)
        {
            var nurse = await db.Nurses.FindAsync(id);
            if (nurse == null)
            {
                throw new Exception("Nurse not found");
            }
            nurse.Name = obj.Name;
            nurse.Email = obj.Email;
            nurse.Mobile = obj.Mobile;
            nurse.Age = obj.Age;
            nurse.Gender = obj.Gender;

            await db.SaveChangesAsync();

        }

        public async Task DeleteNurse(int id)
        {
            var nurse = await db.Nurses.FindAsync(id);
            if (nurse == null)
            {
                throw new Exception("Nurse not found");
            }
            db.Nurses.Remove(nurse);
            await db.SaveChangesAsync();
        }


    }
}
