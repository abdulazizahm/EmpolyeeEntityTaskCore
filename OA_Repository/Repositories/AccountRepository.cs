using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OA_DAL.Models;
using OA_Repository.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OA_Repository.Repositories
{
    public class AccountRepository: BaseRepository<ApplicationUser>
    {
        readonly UserManager<ApplicationUser> manager;

        public AccountRepository(UserManager<ApplicationUser> _manager, DbContext db) : base(db)
        {
            manager = _manager;
        }

        public IQueryable<ApplicationUser> GetAllUsers()
        {

            return  GetAll();
        }

        public ApplicationUser Find(string email, string password)
        {
            var user =  manager.FindByEmailAsync(email).Result;
            if  (user != null && manager.CheckPasswordAsync(user, password).Result)
            {
                return user;
            }
            return null;
        }

        public ApplicationUser FindByEmail(string email)
        {
            return GetAllUsers().FirstOrDefault(u => u.Email == email);
        }


        public ApplicationUser Find(string id)
        {
            return GetAllUsers().FirstOrDefault(u => u.Id == id);
        }

        public IdentityResult Edit(ApplicationUser user)
        {
            return manager.UpdateAsync(user).Result;
        }

        public IQueryable<ApplicationUser> Where(Expression<Func<ApplicationUser, bool>> filter)
        {
            return GetAllUsers().Where(filter);
        }

        public IdentityResult Register(ApplicationUser user)
        {
            user.Created_at = DateTime.Now;
            return manager.CreateAsync(user, user.PasswordHash).Result;
        }



        public IdentityResult AssignToRole(ApplicationUser user, string roleName)
        {
            return manager.AddToRoleAsync(user, roleName).Result;
        }


        //public IdentityResult RemoveFromRole(ApplicationUser user, string roleName)
        //{
        //    return manager.RemoveFromRoleAsync(user, roleName).Result;
        //}

        //public bool IsInRole(ApplicationUser user, Role_Name role)
        //{
        //    return manager.IsInRoleAsync(user, role.ToString()).Result;
        //}

        //public List<ApplicationUser> GetAllUsersByRole(Role_Name role)
        //{
        //    List<ApplicationUser> retval = new List<ApplicationUser>();
        //    var allusers = GetAllUsers().ToList();
        //    foreach (var user in allusers)
        //    {
        //        if (IsInRole(user, role))
        //        {
        //            retval.Add(user);
        //        }
        //    }
        //    return retval;
        //}
    }
}
