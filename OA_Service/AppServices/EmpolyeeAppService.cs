using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OA_DAL.Models;
using OA_Repository.Identity;
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
    public class EmpolyeeAppService: BaseAppService<Empolyee>
    {
        public EmpolyeeAppService(IUnitOfWork _unit) : base(_unit)
        {
        }

        public List<EmpolyeeViewModel> GetAllEmpolyees()
        {
            //return TheUnitOfWork.Empolyee.GetAllEmpolyees();
            return Mapper.Map<List<EmpolyeeViewModel>>(TheUnitOfWork.Empolyee.GetAllEmpolyees());
        }

        public EmpolyeeViewModel GetById(int id)
        {
            return Mapper.Map<EmpolyeeViewModel>(TheUnitOfWork.Empolyee.GetEmpolyeeById(id));
        }

        public Empolyee GetByModelId(int id)
        {
            return TheUnitOfWork.Empolyee.GetEmpolyeeById(id);
        }


        public bool SaveNewEmpolyee(EmpolyeeViewModel EmpolyeeViewModel)
        {
            bool result = false;
            var Empolyee = Mapper.Map<Empolyee>(EmpolyeeViewModel);
            if (TheUnitOfWork.Empolyee.InsertEmpolyee(Empolyee))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;
        }

        public bool UpdateEmpolyee(EmpolyeeViewModel EmpolyeeViewModel)
        {
            var Empolyee = Mapper.Map<Empolyee>(EmpolyeeViewModel);
            TheUnitOfWork.Empolyee.UpdateEmpolyee(Empolyee);
            TheUnitOfWork.Commit();

            return true;
        }

        public bool UpdateEmpolyeeMyModel(Empolyee Empolyee)
        { 
            TheUnitOfWork.Empolyee.UpdateEmpolyee(Empolyee);
            TheUnitOfWork.Commit();

            return true;
        }
        public bool DeleteEmpolyee(int id)
        {
            TheUnitOfWork.Empolyee.DeleteEmpolyee(id);
            bool result = TheUnitOfWork.Commit() > new int();

            return result;
        }

        public bool CheckEmpolyeeExists(EmpolyeeViewModel EmpolyeeViewModel)
        {
            Empolyee Empolyee = Mapper.Map<Empolyee>(EmpolyeeViewModel);
            return TheUnitOfWork.Empolyee.CheckEmpolyeeExists(Empolyee);
        }
    }
}
