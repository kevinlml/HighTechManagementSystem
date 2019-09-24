using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibraryHiTech.Bussines;
using ClassLibraryHiTech.DataAcces;

namespace ClassLibraryHiTech.Validation
{
    public class Validator
    {
        public static bool IsValidID(TextBox text)
        {
            int tempID;
            if ((text.TextLength != 5) || !((Int32.TryParse(text.Text, out tempID))))
            {
                MessageBox.Show("Invalid ID, it must be a 5 digit number");
                text.Clear();
                text.Focus();
                return false;
            }
            return true;
        }
        public static bool ISBNID(TextBox text)
        {
            int tempID;
            if ((text.TextLength != 7) || !((Int32.TryParse(text.Text, out tempID))))
            {
                MessageBox.Show("Invalid ID, it must be a 5 digit number");
                text.Clear();
                text.Focus();
                return false;
            }
            return true;
        }
        public static bool IsValidName(TextBox text)
        {
            for (int i = 0; i < text.TextLength; i++)
            {
                if (char.IsDigit(text.Text, i))
                {
                    MessageBox.Show("Invalid Name,Please enter another name.", "INVALID NAME");
                    text.Clear();
                    text.Focus();
                    return false;
                }
            }
            return true;
        }
        public static bool AuthenticEmployeeID(TextBox text)
        {
            Employee emp = EmployeeDA.Search(Convert.ToInt32(text.Text));

            while (text.Text != null)
            {
                if (emp == null)
                {
                   
                    return true;
                }
                 else   if (Convert.ToInt32(text.Text) == emp.EmployeeID)
                {
                    MessageBox.Show("Duplicated ID, Please put another ID");
                    text.Clear();
                    text.Focus();
                    return false;
                }
                
                
            }
            return true;
        }
        public static bool AuthenticUserID(TextBox text)
        {
            User us = UserDA.Search(Convert.ToString(text.Text));

            while (text.Text != null)
            {
                if (us == null)
                {

                    return true;
                }
                else if (Convert.ToString(text.Text) == us.UserID)
                {
                    MessageBox.Show("Duplicated ID, Please put another ID");
                    text.Clear();
                    text.Focus();
                    return false;
                }


            }
            return true;
        }

        public static bool AvalaibleEmployee(TextBox text)
        {
            Employee us = EmployeeDA.Search(Convert.ToInt32(text.Text));

            
                if (us.JobTitle == "Out")
                {
                    MessageBox.Show("The employee is not avalaible", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    text.Clear();
                    text.Focus();
                    return false;
                }
            else if (us == null)
            {

                return true;
            }


            return true;
        }
    }
}
