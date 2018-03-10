using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MEFConfig {
    public class Person : IEntity{
        public int ID { get; set; }
        public string FirstName { get; set; }

    }
}
