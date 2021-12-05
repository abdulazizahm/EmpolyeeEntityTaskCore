using Microsoft.AspNetCore.Identity;
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
    public class RoleRepository : BaseRepository<IdentityRole>
    {
        public RoleRepository(DbContext db) : base(db)
        {
        }

        #region CRUB

        public List<IdentityRole> GetAllRoles()
        {
            return GetAll().ToList();
        }

        public bool CheckRoleExists(string role_name)
        {
            return GetAny(b => b.Name == role_name);
        }
        #endregion
    }
}
