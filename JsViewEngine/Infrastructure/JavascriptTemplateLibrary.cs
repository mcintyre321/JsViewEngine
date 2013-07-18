using Jurassic;

namespace JsViewEngine.Infrastructure
{
    public abstract class JavascriptTemplateLibrary
    {
        public abstract void CreateRenderFunction(ScriptEngine engine);
        

        public abstract string LibraryPath { get; }
        public abstract string Extension { get; }
    }
}