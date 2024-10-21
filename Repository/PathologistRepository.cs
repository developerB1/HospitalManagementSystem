using HospitalManagementSystem.Data;
using HospitalManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementSystem.Repository
{
    public class PathologistRepository
    {
        private readonly ApplicationDbContext db;
        public PathologistRepository(ApplicationDbContext dbContext)
        {
            this.db = dbContext;
        }
        public async Task<List<Pathologist>> GetAllPathologists()
        {
            return await db.Pathologists.ToListAsync();
        }
        public async Task SavePathologist(Pathologist ph)
        {
            await db.Pathologists.AddAsync(ph);
            await db.SaveChangesAsync();
        }
        public async Task updatePathologist(int id, Pathologist obj)
        {
            var pathologist = await db.Pathologists.FindAsync(id);
            if (pathologist == null)
            {
                throw new Exception("Pathologist not found");
            }
            pathologist.Name = obj.Name;
            pathologist.Email = obj.Email;
            pathologist.Mobile = obj.Mobile;
            pathologist.Age = obj.Age;
            pathologist.Gender = obj.Gender;

            await db.SaveChangesAsync();

        }

        public async Task DeletePathologist(int id)
        {
            var pathologist = await db.Pathologists.FindAsync(id);
            if (pathologist == null)
            {
                throw new Exception("Pathologist not found");
            }
            db.Pathologists.Remove(pathologist);
            await db.SaveChangesAsync();
        }


    }
}
