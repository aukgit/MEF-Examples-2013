using System.Collections.Generic;
using System.ComponentModel.Composition;
using MEFConfig;

namespace MEFMainConsoleExample
{
    class Importer {
        [ImportMany]
        public IEnumerable<IExternalModule> Modules;
    }
}