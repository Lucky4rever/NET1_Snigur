using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOTNET.Variant20.NET2.ComponentCreator
{
    class ComponentCreatorContext
    {
        private IComponentCreator _ComponentCreator;

        public ComponentCreatorContext() { }

        public void SetStrategy(IComponentCreator componentCreator)
        {
            this._ComponentCreator = componentCreator;
        }

        public void NewComponent()
        {
            this._ComponentCreator.NewComponent();
        }
    }
}
