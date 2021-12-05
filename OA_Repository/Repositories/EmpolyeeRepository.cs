using Microsoft.EntityFrameworkCore;
using OA_DAL.Models;
using OA_Repository.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA_Repository.Repositories
{
    public class EmpolyeeRepository : BaseRepository<Empolyee>
    {
        public EmpolyeeRepository(DbContext db) : base(db)
        {
        }

        #region CRUB

        public IQueryable<Empolyee> GetAllEmpolyees()
        {
            return GetAll().Include(c => c.User);
        }

        public bool InsertEmpolyee(Empolyee Empolyee)
        {
            return Insert(Empolyee);
        }
        public void UpdateEmpolyee(Empolyee Empolyee)
        {
            Update(Empolyee);
        }
        public void DeleteEmpolyee(int id)
        {
            Delete(id);
        }

        public bool CheckEmpolyeeExists(Empolyee Empolyee)
        {
            return GetAny(b => b.Id == Empolyee.Id);
        }
        public Empolyee GetEmpolyeeById(int id)
        {
            return GetAllEmpolyees().FirstOrDefault(c => c.Id == id);
        }
        #endregion
    }
}
