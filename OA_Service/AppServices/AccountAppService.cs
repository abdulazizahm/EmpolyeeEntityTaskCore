using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OA_DAL.Models;
using OA_Service.Bases;
using OA_Service.Interfaces;
using OA_Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA_Service.AppServices
{
    public class AccountAppService : BaseAppService<ApplicationUser>
    {
        public AccountAppService(IUnitOfWork _unit) : base(_unit)
        { 
        }

        public ApplicationUser Find(string emial, string password)
        {
            return TheUnitOfWork.Account.Find(emial, password);
        }

        public ApplicationUser FindById(string id) 
        {
            return TheUnitOfWork.Account.Find(id);
        }
        public ProfileViewModel FindProfile(string email)
        {
            return Mapper.Map<ProfileViewModel>(TheUnitOfWork.Account.FindByEmail(email));
        }
       

        public ProfileViewModel FindProfileById(string id)
        {
            return Mapper.Map<ProfileViewModel>(FindById(id));
        }


        public ApplicationUser FindByEmail(string email)
        {
            return TheUnitOfWork.Account.FindByEmail(email);
        }
        
 

        public ApplicationUser FindUserById(string id)
        {
            return TheUnitOfWork.Account.Where(u => u.Id == id).FirstOrDefault();
        }

        //public AdminDisplayUserViewModel FindAdminUserById(string id)
        //{
        //    AdminDisplayUserViewModel user = Mapper.Map<AdminDisplayUserViewModel>(TheUnitOfWork.Account.Where(u => u.Id == id).FirstOrDefault());
        //    return user;
        //}


        //public ProfileEditViewModel GetForEdit(string username)
        //{
        //    return Mapper.Map<ProfileEditViewModel>(Find(username));
        //}

        //public IdentityResult Register(RegisterViewModel userModel)
        //{
        //    ApplicationUser user = Mapper.Map<ApplicationUser>(userModel);
        //    return TheUnitOfWork.Account.Register(user);
        //}

        public IdentityResult AssignToRole(string userId, string role_name)
        {
            var user = FindUserById(userId);
            return TheUnitOfWork.Account.AssignToRole(user, role_name);
        }


        //public ApplicationUser FindByEmailAndPassword(string email, string password)
        //{
        //    return TheUnitOfWork.Account.FindByEmailAndPassword(email, password);
        //}

        public IdentityResult Update(ApplicationUser user)
        {
            return TheUnitOfWork.Account.Edit(user);
        }

        //public IdentityResult AssignToRole(string userId, string roleName)
        //{
        //    return TheUnitOfWork.Account.AssignToRole(userId, roleName);
        //}

        //public IdentityResult RemoveFromRole(string userId, string roleName)
        //{
        //    if (!IsInRole(userId, Role_Name.User))
        //        AssignToRole(userId, Role_Name.User);
        //    return TheUnitOfWork.Account.RemoveFromRole(userId, roleName);
        //}

        //public bool IsInRole(string user_id, string role_name)
        //{
        //    var user = FindById(user_id);
        //    return TheUnitOfWork.Account.IsInRole(user, role_name);
        //}

        //public bool HasEmail(string email)
        //{
        //    return TheUnitOfWork.Account.HasEmail(email);
        //}



    }
}
