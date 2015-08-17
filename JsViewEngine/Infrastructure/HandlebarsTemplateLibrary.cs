using Jurassic;

namespace JsViewEngine.Infrastructure
{
    public class HandlebarsTemplateLibrary : JavascriptTemplateLibrary
    {
        public override void CreateRenderFunction(ScriptEngine engine)
        {
            engine.Execute(
                @"var render = function(model, rawTemplate){;
    var template = Handlebars.compile(rawTemplate);
    return template(Model);
};");


        }

        public override string[] LibraryPath
        {
            get { return new []
            {
                "~/scripts/handlebars-v3.0.3.js",
                //"~/scripts/express-hbs.js"
            }; }
        }

        public override string Extension
        {
            get { return "hbs"; }
        }
    }
}