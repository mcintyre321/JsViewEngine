using System.Web.Mvc;

namespace JsViewEngine.Infrastructure
{
    public class JsViewEngine : VirtualPathProviderViewEngine
    {
        public JsViewEngine()
        {
            // Define the location of the View file
            this.ViewLocationFormats = new string[] { "~/Views/{1}/{0}.jsview", "~/Views/Shared/{0}.jsview" };

            this.PartialViewLocationFormats = new string[] { "~/Views/{1}/{0}.jsview", "~/Views/Shared/{0}.jsview" };
        }

        protected override IView CreatePartialView
    (ControllerContext controllerContext, string partialPath)
        {
            var physicalpath = controllerContext.HttpContext.Server.MapPath(partialPath);
            return new JavascriptView(physicalpath);
        }

        protected override IView CreateView
    (ControllerContext controllerContext, string viewPath, string masterPath)
        {
            var physicalpath = controllerContext.HttpContext.Server.MapPath(viewPath);
            return new JavascriptView(physicalpath);
        }
    }
}