using System.Collections.Generic;
using System.ComponentModel.Composition;
using MEFConfig;

namespace MEFMainConsoleExample
{
    class ImporterModules {
        [ImportMany]
        public IEnumerable<IExternalModule> Modules;
    }
}