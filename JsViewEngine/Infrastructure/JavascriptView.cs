using System.IO;
using System.Web.Mvc;

namespace JsViewEngine.Infrastructure
{
    public class JavascriptView : IView
    {
        private readonly string _physicalpath;

        public JavascriptView(string physicalpath)
        {
            _physicalpath = physicalpath;
        }

        public void Render(ViewContext viewContext, TextWriter writer)
        {
            var engine = new Jurassic.ScriptEngine();
            engine.SetGlobalValue("Model", new JsViewModel(engine, viewContext.ViewData.Model));
            engine.ExecuteFile(_physicalpath);
            viewContext.Writer.WriteLine((engine.GetGlobalValue<string>("output")));
        }
    }
}