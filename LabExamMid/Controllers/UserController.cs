using LabExamMid.Models;
using LabExamMid.Repository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LabExamMid.Controllers
{
    public class UserController : Controller
    {
        // GET: Login

        IUserRepository uRep = new UserRepository();

       
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(User u)
        {
            try
            {
                var user= uRep.GetUser(u.Username);
                if (user == 1)
                {
                    TempData["error"] = "User Already exists!!!";
                    return RedirectToAction("Create");
                }
                else
                {
                    uRep.Insert(u);
                    return RedirectToAction("Login");
                }
            }
            catch {
                uRep.Insert(u);
                return RedirectToAction("Login");
            }
            
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View() ;
        }

        [HttpPost]
        public ActionResult Login(User u)
        {
            var user=uRep.GetUser(u);
            if(user==1)
            {
                Session["username"] = u.Username;
                return RedirectToAction("Index","Memory");
            }
            TempData["error"] = "User does not exist!!";
            return RedirectToAction("Login");
        }

        [HttpGet]
        public ActionResult Logout()
        {
            //Session.RemoveAll();
            Session.Clear();
            
            return RedirectToAction("Login");
        }
        


    }
}