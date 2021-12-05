using Microsoft.AspNetCore.Identity;
using OA_DAL.Models;
using OA_Service.Bases;
using OA_Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA_Service.AppServices
{
    public class RoleAppService: BaseAppService<IdentityRole>
    {
        public RoleAppService(IUnitOfWork _unit): base(_unit)
        {
        }

        public List<IdentityRole> GetAllRoles()
        {
            return TheUnitOfWork.Role.GetAllRoles();
        }

        public bool CheckIfRoleExist(string role_name)
        {
            return TheUnitOfWork.Role.CheckRoleExists(role_name);
        }
    }
}
