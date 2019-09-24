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

namespace Hi_Tech_Management_System.GUI
{
    public partial class ChangePassword : Form
    {
        public ChangePassword()
        {
            InitializeComponent();
        }

        private void buttonexit_Click(object sender, EventArgs e)
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

        private void buttonback_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login log = new Login();
            log.Show();
        }

        private void buttonverificate_Click(object sender, EventArgs e)
        {
            User Us = UserDA.Search(textBoxSearcher2.Text);
            if (Us.UserID != textBoxSearcher2.Text)
            {
                MessageBox.Show("Wrong Username!");
                textBoxSearcher2.Clear();
                textBoxSearcher2.Focus();
            }
            else if (Us != null)
            {

                textBoxSearcher3.Visible = true;
                youwereborn.Visible = true;
                buttonverificate.Visible = false;
                textBoxSearcher2.Enabled = false;
                buttonVerificate2.Visible = true;


            }


            else
            {
                MessageBox.Show("Wrong Data!");
                textBoxSearcher2.Clear();
                textBoxSearcher2.Focus();
            }
        }

        private void buttonVerificate2_Click(object sender, EventArgs e)
        {
            User Us = UserDA.Search(textBoxSearcher2.Text);
            if ((Us != null) && (Us.YearBorn == textBoxSearcher3.Text))
            {
                textBoxPassword.Focus();
                textBoxSearcher3.Enabled = false;
                buttonVerificate2.Enabled = false;
                buttonchangepassword.Visible = true;
                textBoxPassword.Visible = true;
                textBoxUserID.Text = Us.UserID;
                textBoxPassword.Text = Us.Password;
                comboBoxJobTitleUser.Text = Us.JobTitle;
                textBoxAccountStatus.Text = (Us.YearBorn).ToString();
                textBoxUserID.Enabled = false;
                comboBoxJobTitleUser.Enabled = false;
                textBoxAccountStatus.Enabled = false;
                MessageBox.Show("Your last password is showed, please enter your new password if not press back", "Confirmation");
            }
            else
            {
                MessageBox.Show("Wrong Year!");
            }
        }

        private void buttonchangepassword_Click(object sender, EventArgs e)
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
        }

        private void buttonchangepassword_Click_1(object sender, EventArgs e)
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
        }

        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
