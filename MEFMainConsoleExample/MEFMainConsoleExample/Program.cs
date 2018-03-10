using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MEFConfig;

namespace MEFMainConsoleExample
{
    public class Program
    {
        public static void Main(string[] args)
        {


            AddPersonAndPreviewDatabase();
            //loading plugins when needed in the model creation
            Context.pluginImporter = new PluginsImporter();

            AddPersonAndPreviewDatabase();

            ModuleLoadDynamic();

            //ModuleLoadDynamic();


            Console.WriteLine("");
            Console.WriteLine("Program Ends!");
            Console.ReadKey();
        }

        public static void AddPersonAndPreviewDatabase()
        {

            try
            {

                var db = new Context();

                db.People.Add(new Person() { FirstName = "Hello" });
                db.SaveChanges();

                var db2 = new Context();

                db2.People.Add(new Person() { FirstName = "Xello" });
                db2.SaveChanges();
                foreach (var item in db2.People.ToList())
                {
                    Console.WriteLine(item.ID + ":" + item.FirstName);
                }



            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }

        }

        public static void ModuleLoadDynamic()
        {
            CompositionContainer _container;

            var catalog = new AggregateCatalog();
            //catalog.Catalogs.Add(Assembly.GetExecutingAssembly());
            catalog.Catalogs.Add(new DirectoryCatalog(@"..\..\..\MEFMainConsoleExample\External"));


            //Create the CompositionContainer with the parts in the catalog
            _container = new CompositionContainer(catalog);

            var importer = new Importer();



            //Fill the imports of this object
            try
            {
                _container.ComposeParts(importer);
                //foreach (var p in _container.Catalog.Parts) {

                //    Console.WriteLine(p.ToString());
                //}
                //Console.WriteLine();
                //foreach (var item in importer.Modules) {
                //    Console.WriteLine(item.message());
                //}

                foreach (var item in importer.Modules)
                {
                    item.display();
                }
            }
            catch (CompositionException compositionException)
            {
                Console.WriteLine(compositionException.ToString());
            }

        }
    }
}
