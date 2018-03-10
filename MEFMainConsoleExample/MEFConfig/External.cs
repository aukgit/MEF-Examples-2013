using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MEFConfig {
    public class External :IExternalModule{
        #region IExternalModule Members

        public string Title {
            get {
                return "no title";
            }
        }

        public string message() {
            return "none";
        }

        public void display() {
            Console.WriteLine("None");
        }

        #endregion
    }
}
