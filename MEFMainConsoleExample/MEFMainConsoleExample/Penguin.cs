using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MEFConfig;

namespace MEFMainConsoleExample {
    public class Penguin : IEntity {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
