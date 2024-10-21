using HospitalManagementSystem.Data;
using HospitalManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementSystem.Repository
{
    public class ReceptionistRepository
    {
        private readonly ApplicationDbContext db;
        public ReceptionistRepository(ApplicationDbContext dbContext)
        {
            this.db = dbContext;
        }
        public async Task<List<Receptionist>> GetAllReceptionists()
        {
            return await db.Receptionists.ToListAsync();
        }
        public async Task SaveReceptionist(Receptionist rt)
        {
            await db.Receptionists.AddAsync(rt);
            await db.SaveChangesAsync();
        }
        public async Task updateReceptionist(int id, Receptionist obj)
        {
            var receptionist = await db.Receptionists.FindAsync(id);
            if (receptionist == null)
            {
                throw new Exception("Receptionist not found");
            }
            receptionist.Name = obj.Name;
            receptionist.Email = obj.Email;
            receptionist.Mobile = obj.Mobile;
            receptionist.Age = obj.Age;
            receptionist.Gender = obj.Gender;

            await db.SaveChangesAsync();

        }

        public async Task DeleteReceptionist(int id)
        {
            var receptionist = await db.Receptionists.FindAsync(id);
            if (receptionist == null)
            {
                throw new Exception("Receptionist not found");
            }
            db.Receptionists.Remove(receptionist);
            await db.SaveChangesAsync();
        }


    }
}
