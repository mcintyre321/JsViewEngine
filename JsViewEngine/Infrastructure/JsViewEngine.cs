using System.Collections.Generic;
using System.Web.Mvc;

namespace JsViewEngine.Infrastructure
{
    public class JsViewEngine : VirtualPathProviderViewEngine
    {
        private readonly JavascriptTemplateLibrary _library;

        public JsViewEngine(JavascriptTemplateLibrary library)
        {
            _library = library;
            // Define the location of the View file
            this.ViewLocationFormats = new string[] { "~/Views/{1}/{0}." + _library.Extension, "~/Views/Shared/{0}." + _library.Extension };

            this.PartialViewLocationFormats = new string[] { "~/Views/{1}/{0}." + _library.Extension, "~/Views/Shared/{0}" + _library.Extension };
        }

        protected override IView CreatePartialView
    (ControllerContext controllerContext, string partialPath)
        {

            return new JavascriptView(partialPath, new JsRenderTemplateLibrary());
        }

        protected override IView CreateView
    (ControllerContext controllerContext, string viewPath, string masterPath)
        {
            return new JavascriptView(viewPath, new JsRenderTemplateLibrary());
        }
    }
}