using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MEFConfig;

namespace ExternalMEF1 {

    public class MyDB : DatabaseContext {
        public MyDB() { }
      
        public DbSet<Rambo> Rambos { get; set; }
        public DbSet<David> Davids { get; set; }
    }

    [Export(typeof(IExternalModule))]

    public class Ext1 : IExternalModule {
        #region IExternalModule Members

        public string Title {
            get { return "External Module 1"; }
        }

        public void display() {
            try {
                var db = new MyDB();
                var rambo = new Rambo() { FirstName = "Rambo" ,LastNmae = "labo2" };

                db.Rambos.Add(rambo);
                db.SaveChanges();
                rambo.FirstName += " " + rambo.ID;
                db.SaveChanges();

                Console.WriteLine("Created Rambos.");
                Console.WriteLine("Created Rambos are:");


                foreach (var item in db.Rambos.ToList()) {
                    Console.WriteLine(item.FirstName);

                }

            } catch (Exception ex) {
                Console.WriteLine(ex.Message.ToString());
            }
 

            Console.WriteLine(Title);
        }

        public string message() {
            return Title + " Message.";
        }

        #endregion
    }
    [Export(typeof(IExternalModule))]
    public class Ext2 : IExternalModule {
        #region IExternalModule Members
        //Context db = new Context();

        //public Ext2() {
        //    db.People.Add(new Person() { FirstName = "Alice : " + DateTime.Now.TimeOfDay.ToString() });
        //    db.SaveChanges();
        //}


        public string Title {
            get { return "External Module 2"; }
        }

        public void display() {
            Console.WriteLine(Title);
        }

        public string message() {
            //foreach (var person in db.People) {
            //    Console.WriteLine("Person :" + person.FirstName);

            //}

            return Title + " Message.";
        }

        #endregion
    }
}
