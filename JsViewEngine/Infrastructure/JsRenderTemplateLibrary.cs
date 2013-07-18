using Jurassic;

namespace JsViewEngine.Infrastructure
{
    public class JsRenderTemplateLibrary : JavascriptTemplateLibrary
    {
        public override void CreateRenderFunction(ScriptEngine engine)
        {
            engine.Execute(
                @"var render = function(model, rawTemplate){;
    var template = g.$.templates(rawTemplate);
    return template.render(Model);
};");
        }

        public override string LibraryPath
        {
            get { return "~/scripts/jsrender.js"; }
        }

        public override string Extension
        {
            get { return "jsrender.html"; }
        }
    }
}