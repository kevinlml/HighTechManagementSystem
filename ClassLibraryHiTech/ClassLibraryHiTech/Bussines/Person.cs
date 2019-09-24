using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryHiTech.Bussines
{
    public class Person
    {
        private string Firstname;
        private string Lastname;

        public Person()

        {
            Firstname = "";
            Lastname = "";
        }
        public Person(string Firstname, string Lastname)
        {
            this.Firstname = FirstName;
            this.Lastname = LastName;
        }
        public string FirstName
        {
            get
            {
                return Firstname;
                //throw new System.NotImplementedException();
            }

            set
            {
                Firstname = value;
            }
        }

        public string LastName
        {
            get
            {
                return Lastname;
                //throw new System.NotImplementedException();
            }

            set
            {
                Lastname = value;
            }
        }
    }
}
