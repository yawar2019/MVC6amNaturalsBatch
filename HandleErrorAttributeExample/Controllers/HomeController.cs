using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HandleErrorAttributeExample.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        //[HandleError(View ="_Error1")]
        public ActionResult TestValue(string b)
        {
            try
            {
                int a = 10;
                int c = a / Convert.ToInt32(b);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return View();

        }

        [OutputCache(Duration =20)]
        public ActionResult TestOutPutCache()
        {
            return View();
        }
    }
}