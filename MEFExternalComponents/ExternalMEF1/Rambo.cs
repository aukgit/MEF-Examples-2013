using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MEFConfig;

namespace ExternalMEF1 {
    [Export]
    public class Rambo : IEntity {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastNmae { get; set; }
    }
}
