using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryHiTech.Bussines
{
    public class Employee : Person
    {
        public int EmployeeID { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string JobTitle { get; set; }

        public Employee()
        {
            EmployeeID = 11111;
            PhoneNumber = "123456789";
            Email = "an1dres@";
            JobTitle = "Sales manager";

        }

        public Employee(int employeeid, string phonenumber, string email, string jobtitle, string firstname, string lastname) : base(firstname, lastname)
        {
            this.EmployeeID = employeeid;
            this.PhoneNumber = phonenumber;
            this.Email = email;
            this.JobTitle = jobtitle;

        }
    }
}
