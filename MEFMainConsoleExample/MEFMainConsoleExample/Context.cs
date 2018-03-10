using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MEFConfig;
using System.Data.Entity;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition;

namespace MEFMainConsoleExample {


    public class Context : DatabaseContext {
        public static PluginsImporter pluginImporter;

        public Context() {
            Console.WriteLine("Created.");
        }


        public DbSet<Bird> Birds { get; set; }
        public DbSet<Penguin> Penguins { get; set; }


  

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            pluginImporter.LoadPlugins();

            if (pluginImporter.MefLoadedPlugins != null) {
                Console.WriteLine("Plugins found: " + pluginImporter.MefLoadedPlugins.Count());
                foreach (var pluginContext in pluginImporter.MefLoadedPlugins) {
                    try {
                        Console.WriteLine(pluginContext.ToString());
                        pluginContext.Setup(ref modelBuilder);
                    } catch (Exception ex) {
                        Console.WriteLine(ex.Message.ToString());
                    }                    
                }
            } else {
                Console.WriteLine("no db plugin found.");
            }


            if (pluginImporter.ExternalEntites != null) {
                Console.WriteLine("External Entities found: " + pluginImporter.ExternalEntites.Count());
                foreach (var entity in pluginImporter.ExternalEntites) {
                    try {
                        Console.WriteLine(entity.ToString());
                    } catch (Exception ex) {
                        Console.WriteLine(ex.Message.ToString());
                    }
                }

            } else {
                Console.WriteLine("no external db entites found.");

            }
        }

        

    }
}
