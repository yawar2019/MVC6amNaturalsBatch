using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC6amNaturalsBatch.Models;
using System.Web.Security;

namespace MVC6amNaturalsBatch.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login

        StateEntities db = new StateEntities();
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserDetail user)
        {
            UserDetail ValidUser = db.UserDetails.Where(s => s.UserName == user.UserName && s.Password == user.Password).SingleOrDefault();
            if (ValidUser != null)
            {
                FormsAuthentication.SetAuthCookie(user.UserName, false);
                return Redirect("~/Login/Dashboard");
            }
            ViewBag.info = "UserName and Password is Incorrect";
            return View(ValidUser);
        }
        [Authorize]
        public ActionResult Dashboard()
        {
            return View();
        }

        [Authorize(Roles="Admin")]
        public ActionResult AboutUs()
        {
            return View();
        }
        [Authorize(Roles ="Admin,Manager")]
        public ActionResult ContactUs()
        {
            return View();
        }

        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return Redirect("~/Login/Login");
        }

        public ActionResult ServiceTest()
        {
         //   ServiceReference1.MyServiceSoapClient obj = new ServiceReference1.MyServiceSoapClient();
         //var result=  obj.Add(12, 21);
         //   ServiceReference2.Service1Client obj1 = new ServiceReference2.Service1Client();
         //  var result1= obj1.Add(12,43);
            ServiceReference3.Service1Client obj3 = new ServiceReference3.Service1Client("NetTcpBinding_IService1");
            var result5 = obj3.Add(56, 49);
            return Content(result5.ToString());

        }
    }
}