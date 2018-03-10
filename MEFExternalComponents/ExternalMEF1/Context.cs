using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MEFConfig;

namespace ExternalMEF1 {
    [Export]
    public class DbSetup : IDbSetupPlugin {
        public void Setup(ref DbModelBuilder modelBuilder) {
            modelBuilder.Entity<Rambo>().ToTable("Rambos", "dbo");
            modelBuilder.Entity<David>().ToTable("David", "dbo");
            Console.WriteLine("Plugin db attached assumed!");
        }
    }
}
