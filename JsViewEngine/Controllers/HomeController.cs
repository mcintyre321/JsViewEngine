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
            return RedirectToAction("Knockout");
            
        }

        public ActionResult Knockout()
        {
            return View(new
            {
                people = new[]
                {
                    new {firstName="Bert", lastName ="Bertington"},
                    new { firstName= "Charles", lastName= "Charlesforth" },
                }
  });
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
    }
}
