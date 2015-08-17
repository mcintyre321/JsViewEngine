using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JsViewEngine.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("Handlebars");
            
        }



        public ActionResult JsRender()
        {
            return View(
                new
                {
                    name = "Robert",
                    nickname = "Bob",
                    showNickname = true

                });
        }
        public ActionResult Handlebars()
        {
            return View(
                new
                {
                    name = "Robert",
                    nickname = "Bob",
                    showNickname = true

                });
        }
    }
}
