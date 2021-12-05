using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OA_DAL.Models;
using OA_Service.AppServices;
using OA_Service.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace OA_Web.Controllers
{

    public class EmpolyeeController : Controller
    {
        private EmpolyeeAppService EmpolyeeAppService;
        private AccountAppService account;
     
        public EmpolyeeController(EmpolyeeAppService _Empolyee, AccountAppService _account)
        {
            EmpolyeeAppService = _Empolyee;
            account = _account;
          
        }
        public IActionResult Index()
        {

            return View(EmpolyeeAppService.GetAllEmpolyees());
        }

        public IActionResult AddEmpolyee()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddEmpolyee(EmpolyeeViewModel EmpolyeeView)
        {
            if (!ModelState.IsValid)
            {
                return View(EmpolyeeView);
            }

            try
            {
                ImageUploaderService photoUploader = new ImageUploaderService(EmpolyeeView.FormFileImage, Directories.Empolyees);

                EmpolyeeView.Image = photoUploader.GetImageName();
                if (User.Identity.IsAuthenticated) 
                {
                    EmpolyeeView.User_ID = account.FindByEmail(email: User.Identity.Name).Id;
                }
                EmpolyeeAppService.SaveNewEmpolyee(EmpolyeeView);
                photoUploader.SaveImageAsync();
                return RedirectToAction("Index", "Empolyee");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(EmpolyeeView);
            }

        }
        public IActionResult updateEmpolyee(int id)
        {
            var Empolyee = EmpolyeeAppService.GetById(id);
            return View(Empolyee);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult updateEmpolyee(EmpolyeeViewModel EmpolyeeView)
        {
            var Empolyee = EmpolyeeAppService.GetByModelId(EmpolyeeView.Id);
            //if (!ModelState.IsValid)
            //{
            //    return View(EmpolyeeView);
            //}

            try
            {
                if (EmpolyeeView.FormFileImage != null)
                {
                    ImageUploaderService photoUploader = new ImageUploaderService(EmpolyeeView.FormFileImage, Directories.Empolyees);

                    if (!EmpolyeeView.Image.Contains("default"))
                    {
                        ImageUploaderService.DeleteImage(EmpolyeeView.Image, Directories.Empolyees);
                    }

                    Empolyee.Image = photoUploader.GetImageName();
                    photoUploader.SaveImageAsync();
                }
                Empolyee.Job = EmpolyeeView.Job;
                EmpolyeeAppService.UpdateEmpolyeeMyModel(Empolyee);
                return RedirectToAction("Index", "Empolyee");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(EmpolyeeView);
            }

        }
        public IActionResult DeleteEmpolye(int id) 
        {
            EmpolyeeAppService.DeleteEmpolyee(id);
            return RedirectToAction("Index", "Empolyee");
        }

    }
}
