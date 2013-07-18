using System.IO;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;

namespace JsViewEngine.Infrastructure
{
    public class JavascriptView : IView
    {
        private readonly string _virtualPath;
        private readonly JavascriptTemplateLibrary _templateLibrary;

        public JavascriptView(string virtualPath, JavascriptTemplateLibrary templateLibrary)
        {
            _virtualPath = virtualPath;
            _templateLibrary = templateLibrary;
        }

        public void Render(ViewContext viewContext, TextWriter writer)
        {
            var engine = new Jurassic.ScriptEngine();
            engine.SetGlobalValue("Model", new JsViewModel(engine, viewContext.ViewData.Model));
            
            string jsRenderPath = viewContext.HttpContext.Server.MapPath(_templateLibrary.LibraryPath);
            var jsRender = File.ReadAllText(jsRenderPath);
            
            engine.Execute(jsRender);
            using (var stream = VirtualPathProvider.OpenFile(_virtualPath.TrimStart('~')))
            using (var streamReader = new StreamReader(stream))
            {
                engine.SetGlobalValue("rawTemplate", streamReader.ReadToEnd());
            }
            engine.Execute("var output = render(Model, rawTemplate);");
            _templateLibrary.CreateRenderFunction(engine);
         
            viewContext.Writer.WriteLine((engine.GetGlobalValue<string>("output")));
        }
    }
}