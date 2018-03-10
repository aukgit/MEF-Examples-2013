using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using MEFConfig;

namespace MEFMainConsoleExample
{
    public class PluginsImporter {
        [ImportMany(AllowRecomposition = true)]
        public List<IDbSetupPlugin> MefLoadedPlugins;
        [ImportMany(AllowRecomposition=true)]
        public List<IEntity> ExternalEntites;

        public void LoadPlugins() {
            CompositionContainer _container;

            var catalog = new AggregateCatalog();
            //catalog.Catalogs.Add(Assembly.GetExecutingAssembly());
            catalog.Catalogs.Add(new DirectoryCatalog(@"..\..\..\External"));


            //Create the CompositionContainer with the parts in the catalog
            _container = new CompositionContainer(catalog);

            
            //Fill the imports of this object
            try {
                _container.ComposeParts(this);
                foreach (var p in _container.Catalog.Parts) {
                    Console.WriteLine(p.ToString());
                }
                Console.WriteLine();
                Console.WriteLine("Plugins Load Complete!");
            } catch (CompositionException compositionException) {
                Console.WriteLine(compositionException.ToString());
            }

        }
    }
}