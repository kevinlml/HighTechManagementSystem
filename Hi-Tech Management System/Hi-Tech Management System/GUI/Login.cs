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
using Hi_Tech_Management_System.GUI;

namespace Hi_Tech_Management_System.GUI
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void buttonEnter_Click(object sender, EventArgs e)
        {
            
            if ((textBoxUserName.Text == "") || (textBoxPassword.Text == ""))
            {
                MessageBox.Show("You must fill out all of the boxes, try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxUserName.Clear();
                textBoxPassword.Clear();
                textBoxUserName.Focus();
                return;
            }
            else
            {                
                                
                User user = UserDA.Search(textBoxUserName.Text);
                string textUser = textBoxUserName.Text;
                string textPass = textBoxPassword.Text;


                if (user == null)
                {
                    MessageBox.Show("Wrong Information, try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxUserName.Clear();
                    textBoxPassword.Clear();
                    textBoxUserName.Focus();
                }
                else
                {
                    if ((user.Password == textBoxPassword.Text) &&(user.JobTitle == "MIS Manager"))
                    {
                        user.UserID = textBoxUserName.Text;
                        this.Hide();
                        MIS_manager form = new MIS_manager();
                        form.Show();
                    }
                    else if ((user.Password == textBoxPassword.Text) && (user.JobTitle == "Inventory Controller"))
                    {
                        this.Hide();
                        Inventory In = new Inventory();
                        In.Show();
                    }
                    else if ((user.Password == textBoxPassword.Text) && (user.JobTitle == "Sales Manager"))
                    {
                        this.Hide();
                        ClientsGUI ms = new ClientsGUI();
                        ms.Show();
                    }
                    else if ((user.Password == textBoxPassword.Text) && (user.JobTitle == "Order Clerks"))
                    {
                        this.Hide();
                        Order_interface cl = new Order_interface();
                        cl.Show();
                    }
                    else if (user.Password != textBoxPassword.Text)
                    {
                        MessageBox.Show("Wrong Information, try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBoxUserName.Clear();
                        textBoxPassword.Clear();
                        textBoxUserName.Focus();
                        return;
                    }
                    else if (user.UserID != textBoxUserName.Text)
                    {
                        MessageBox.Show("Wrong Information, try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBoxUserName.Clear();
                        textBoxPassword.Clear();
                        textBoxUserName.Focus();
                        return;
                    }
                }
            }

        }

        private void buttonExit_Click(object sender, EventArgs e)
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

        private void buttonchangepassword_Click(object sender, EventArgs e)
        {
            this.Hide();
            ChangePassword ch = new ChangePassword();
            ch.Show();
        }

        private void buttonAbout_Click(object sender, EventArgs e)
        {
            this.Hide();
            Hi_TechCopyRight lm = new Hi_TechCopyRight();
            lm.Show();
        }
    }
}
