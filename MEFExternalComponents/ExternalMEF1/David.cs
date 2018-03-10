using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MEFConfig;

namespace ExternalMEF1 {
    [Export]
    public class David : IEntity {
        public int ID { get; set; }
        public string FirstName { get; set; }
    }
}
