using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvcRegistrationform.Models;

namespace mvcRegistrationform.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {
            User userModel = new User();
            return View(userModel);
        }
        [HttpPost]
        public ActionResult AddOrEdit(User userModel)
        {
            using (DbModels DbModels = new DbModels())
            {
                if(DbModels.Users.Any(x=>x.Username==userModel.Username))
                {
                    ViewBag.DuplicateMessage = "Username already exits.";
                    return View("AddOrEdit",userModel);
                }
                DbModels.Users.Add(userModel);
                DbModels.SaveChanges();
            }
            ModelState.Clear();
            ViewBag.SuccessMessage = "Registration Successfuly.";
            return View("AddOrEdit", new User());
        }
    }
}