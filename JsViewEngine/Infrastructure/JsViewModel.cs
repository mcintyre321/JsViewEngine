using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jurassic;
using Jurassic.Library;

namespace JsViewEngine.Infrastructure
{
    class JsViewModel : ObjectInstance
    {

        public JsViewModel(ScriptEngine engine, object model) : base(engine)
        {
            foreach (var propertyNameAndValue in model.GetType().GetProperties())
            {
                this[propertyNameAndValue.Name] = propertyNameAndValue.GetValue(model, null);
            }
        }
    }
}
