using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibraryHiTech.Bussines;
using ClassLibraryHiTech.DataAcces;
using ClassLibraryHiTech.Validation;

namespace Hi_Tech_Management_System.GUI
{
    public partial class MIS_manager : Form
    {
        public MIS_manager()
        {
            InitializeComponent();
        }

        private List<Employee> listEmployee = new List<Employee>();
        private List<User> listUser = new List<User>();

        private void ClearAllEmployee()
        {
            textBoxEmployeeID.Clear();
            textBoxFirstNameEm.Clear();
            textBoxLastNameEM.Clear();
            maskedTextBoxEmployee.Clear();
            comboBoxJobTitleEmployee.SelectedIndex = -1;
            textBoxEmailEM.Clear();


        }

        private void ClearAllUser() 
        {
            textBoxUserID.Clear();
            textBoxPassword.Clear();
            textBoxAccountStatus.Clear();
            comboBoxJobTitleUser.SelectedIndex = -1;

        }

        private void buttonSave2_Click(object sender, EventArgs e)
        {
            /* if (!Validator.AuthenticUserID(textBoxUserID) && (!Validator.AvalaibleEmployee(textBox1)))
             { }
             else
             {
                 User uUser = new User();


                 uUser.UserID = textBoxUserID.Text;
                 uUser.Password = textBoxPassword.Text;
                 uUser.JobTitle = comboBoxJobTitleUser.Text;
                 uUser.YearBorn = textBoxAccountStatus.Text;
                 UserDA.Save(uUser);
                 //      listUser.Add(uUser);


                 buttonList2.Enabled = true;
                 ClearAllUser();
             }*/
            Employee emp = EmployeeDA.Search(Convert.ToInt32(textBox1.Text));
            if ((emp.JobTitle == "Avalaible") || (emp.JobTitle == "MIS Manager") || (emp.JobTitle == "Sales Manager") || (emp.JobTitle == "Inventory Controller") || (emp.JobTitle == "Order Clerks"))
            {
                
                if ((textBoxUserID.Text == "") || (textBoxPassword.Text == "") || (comboBoxJobTitleUser.Text == "") || (textBoxAccountStatus.Text == ""))
                {
                    MessageBox.Show("You have to fill out all the boxes, try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }
                else if (!Validator.AuthenticUserID(textBoxUserID))
                {
                    MessageBox.Show("Duplicate ID, please enter a unique one.");
                }

                else
                {
                    User uUser = new User();


                    uUser.UserID = textBoxUserID.Text;
                    uUser.Password = textBoxPassword.Text;
                    uUser.JobTitle = comboBoxJobTitleUser.Text;
                    uUser.YearBorn = textBoxAccountStatus.Text;
                    UserDA.Save(uUser);
                    listUser.Add(uUser);


                    buttonList2.Enabled = true;
                    ClearAllUser();
                }

            }
            else if (emp.JobTitle == "Out")
            {
                MessageBox.Show("The employee is not avalaible", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ClearAllUser();
            }
            else
            {
                MessageBox.Show("Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        
    }

        private void buttonUpdate2_Click(object sender, EventArgs e)
        {
            if ((textBoxPassword.Text == "") && (comboBoxJobTitleUser.Text == ""))
            {
                MessageBox.Show("Please enter a valid User ID", "Missing Data");
                textBoxEmployeeID.Clear();
                textBoxEmployeeID.Focus();
                return;
            }
            else
            {
                User Us = new User();
                Us.UserID = textBoxUserID.Text;
                Us.Password = textBoxPassword.Text;
                Us.JobTitle = comboBoxJobTitleUser.Text;
                Us.YearBorn = textBoxAccountStatus.Text;
                DialogResult ans = MessageBox.Show("Do you really want to update this User?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (ans == DialogResult.Yes)
                {
                    UserDA.Update(Us);
                    MessageBox.Show("User record has been updated successfully", "Confirmation");
                }
                textBoxUserID.Enabled = true;
                ClearAllUser();
            }
        }

        private void buttonList2_Click(object sender, EventArgs e)
        {
            listView2Users.Items.Clear();


            UserDA.ListUsers(listView2Users);
        }

        private void buttonSearch2_Click(object sender, EventArgs e)
        {
            User Us = UserDA.Search(textBoxSearcher2.Text);
            if (Us != null)
            {
                textBoxUserID.Text = Us.UserID;
                textBoxPassword.Text = Us.Password;
                comboBoxJobTitleUser.Text = Us.JobTitle;
                textBoxAccountStatus.Text = (Us.YearBorn).ToString();
                textBoxUserID.Enabled = false;

            }

            else
            {
                MessageBox.Show("User not Found!");
                textBoxSearcher.Clear();
                textBoxSearcher.Focus();
            }
        }

        private void buttonBack2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login log = new Login();
            log.Show();
        }

        private void buttonExit2_Click(object sender, EventArgs e)
        {
            DialogResult answer = MessageBox.Show("Are you sure to exit the application?", "Confirmation",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (answer == DialogResult.Yes)
            {
                Application.Exit();
            }
            else if (answer == DialogResult.No)
            {


            }
        }

        private void buttonDelete2_Click(object sender, EventArgs e)
        {
            UserDA.Delete(textBoxUserID.Text);
            MessageBox.Show(" User record has been deleted successfully", "Confirmation");
        }

        private void buttonSaveEmployee_Click(object sender, EventArgs e)
        {
            if ((!Validator.AuthenticEmployeeID(textBoxEmployeeID) && (!Validator.IsValidID(textBoxEmployeeID)) && (!Validator.IsValidName(textBoxFirstNameEm)) && (!Validator.IsValidName(textBoxLastNameEM))))
            { }
            else
            {
                Employee eEmployee = new Employee();

                eEmployee.EmployeeID = Convert.ToInt32(textBoxEmployeeID.Text);
                eEmployee.FirstName = textBoxFirstNameEm.Text;
                eEmployee.LastName = textBoxLastNameEM.Text;
                eEmployee.PhoneNumber = maskedTextBoxEmployee.Text;
                eEmployee.Email = textBoxEmailEM.Text;
                eEmployee.JobTitle = comboBoxJobTitleEmployee.Text;
                EmployeeDA.Save(eEmployee);
                ClearAllEmployee();
            }

            
        }

        private void buttonUpdateEmployee_Click(object sender, EventArgs e)
        {
            if ((textBoxFirstNameEm.Text == "") || (textBoxLastNameEM.Text == "") || (maskedTextBoxEmployee.Text == "") || (textBoxEmailEM.Text == "") || (comboBoxJobTitleEmployee.Text == ""))
            {
                MessageBox.Show("Please enter a valid employee ID", "Missing Data");
                textBoxEmployeeID.Clear();
                textBoxEmployeeID.Focus();
                return;
            }
            else
            {
                Employee Emp = new Employee();
                Emp.EmployeeID = Convert.ToInt32(textBoxEmployeeID.Text);
                Emp.FirstName = textBoxFirstNameEm.Text;
                Emp.LastName = textBoxLastNameEM.Text;
                Emp.PhoneNumber = maskedTextBoxEmployee.Text;
                Emp.Email = textBoxEmailEM.Text;
                Emp.JobTitle = comboBoxJobTitleEmployee.Text;
                DialogResult ans = MessageBox.Show("Do you really want to update this Employee?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (ans == DialogResult.Yes)
                {
                    EmployeeDA.Update(Emp);
                    MessageBox.Show("Employee record has been updated successfully", "Confirmation");
                }
                textBoxEmployeeID.Enabled = true;
                ClearAllEmployee();
            }
        }

        private void buttonBackEmployee_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login log = new Login();
            log.Show();
        }

        private void buttonDeleteEmployee_Click(object sender, EventArgs e)
        {
            EmployeeDA.Delete(Convert.ToInt32(textBoxEmployeeID.Text));
            MessageBox.Show("Employee record has been deleted successfully", "Confirmation");
        }

        private void buttonExitEmployee_Click(object sender, EventArgs e)
        {
            DialogResult answer = MessageBox.Show("Are you sure to exit the application?", "Confirmation",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (answer == DialogResult.Yes)
            {
                Application.Exit();
            }
            else if (answer == DialogResult.No)
            {

            }
        }

        private void buttonListEmployee_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();


            EmployeeDA.ListEmployee(listView1);
        }

        private void buttonSearchEmployee_Click(object sender, EventArgs e)
        {
            int choice = comboBox1.SelectedIndex;
            switch (choice)
            {
                case -1:
                    MessageBox.Show("Please select the search option");
                    break;
                case 0:
                    Employee Empl = EmployeeDA.Search(Convert.ToInt32(textBoxSearcher.Text));
                    if (Empl != null)
                    {
                        textBoxEmployeeID.Text = (Empl.EmployeeID).ToString();
                        textBoxFirstNameEm.Text = Empl.FirstName;
                        textBoxLastNameEM.Text = Empl.LastName;
                        maskedTextBoxEmployee.Text = Empl.PhoneNumber;
                        textBoxEmailEM.Text = Empl.Email;
                        comboBoxJobTitleEmployee.Text = Empl.JobTitle;
                        textBoxEmployeeID.Enabled = false;

                    }

                    else
                    {
                        MessageBox.Show("Employee not Found!");
                        textBoxSearcher.Clear();
                        textBoxSearcher.Focus();
                    }
                    break;

                default:
                    break;
            }
        }
    }
}
