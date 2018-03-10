using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MEFConfig {
    [Export]
    public abstract class DatabaseContext : DbContext {
        public DatabaseContext()
            : base("DbArc")
        { }
        public DbSet<Person> People { get; set; }
        public int MyProperty { get; set; }
    }
}
