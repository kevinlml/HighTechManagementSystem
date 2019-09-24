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
    public partial class ClientsGUI : Form
    {
        public ClientsGUI()
        {
            InitializeComponent();
        }
        private void ClearAll() 
        {
            textBoxclientID.Clear();
            textBoxinstitutionname.Clear();
            textBoxstreet.Clear();
            textBoxcity.Clear();
            maskedTextBoxPostalCode.Clear();
            maskedTextBoxphonenumber.Clear();
            maskedTextBoxfaxnumber.Clear();
            textBoxcreditlimit.Clear();
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

        private void buttonReturn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login log = new Login();
            log.Show();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if ((maskedTextBoxfaxnumber.Text == "") || (textBoxcreditlimit.Text == "") || (textBoxclientID.Text == "") || (textBoxinstitutionname.Text == "") || (textBoxstreet.Text == "") || (textBoxcity.Text == "") || (maskedTextBoxPostalCode.Text == "") || (maskedTextBoxphonenumber.Text == ""))
            {
                MessageBox.Show("You have to fill out all the boxes, try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
            else
            {
                Client clien = new Client();

                clien.ClientID = Convert.ToInt32(textBoxclientID.Text);
                clien.Name = textBoxinstitutionname.Text;
                clien.Street = textBoxstreet.Text;
                clien.City = textBoxcity.Text;
                clien.PostalCode = maskedTextBoxPostalCode.Text;
                clien.PhoneNumber = maskedTextBoxphonenumber.Text;
                clien.FaxNumber = maskedTextBoxfaxnumber.Text;
                clien.CreditLimit = Convert.ToInt32(textBoxcreditlimit.Text);
                ClientsDA.Save(clien);
                
            }
            ClearAll();
        }

        private void buttonList_Click(object sender, EventArgs e)
        {
            listViewClient.Items.Clear();


            ClientsDA.ListClient(listViewClient);
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if ((maskedTextBoxfaxnumber.Text == "") || (textBoxcreditlimit.Text == "") || (textBoxinstitutionname.Text == "") || (textBoxstreet.Text == "") || (textBoxcity.Text == "") || (maskedTextBoxPostalCode.Text == "") || (maskedTextBoxphonenumber.Text == ""))
            {
                MessageBox.Show("Please enter a valid Client", "Missing Data");
                textBoxclientID.Clear();
                textBoxclientID.Focus();
                return;
            }
            else
            {
                Client clien = new Client();
                clien.ClientID = Convert.ToInt32(textBoxclientID.Text);
                clien.Name = textBoxinstitutionname.Text;
                clien.Street = textBoxstreet.Text;
                clien.PostalCode = maskedTextBoxPostalCode.Text;
                clien.PhoneNumber = maskedTextBoxphonenumber.Text;
                clien.FaxNumber = maskedTextBoxfaxnumber.Text;
                clien.CreditLimit = Convert.ToInt32(textBoxcreditlimit);
                DialogResult ans = MessageBox.Show("Do you really want to update this Client information?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (ans == DialogResult.Yes)
                {
                    ClientsDA.Update(clien);
                    MessageBox.Show("Client record has been updated successfully", "Confirmation");
                }
                textBoxclientID.Visible = true;
                ClearAll();
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            ClientsDA.Delete(Convert.ToInt32(textBoxclientID.Text));
            MessageBox.Show(" Client record has been deleted successfully", "Confirmation");
            textBoxclientID.Enabled = true;
            ClearAll();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            Client clien = ClientsDA.SearchID(Convert.ToInt32(textBoxSearcher.Text));
            if (clien != null)
            {
                textBoxclientID.Text = (clien.ClientID).ToString();
                textBoxinstitutionname.Text = clien.Name;
                textBoxstreet.Text = clien.Street;
                textBoxcity.Text = clien.City;
                maskedTextBoxPostalCode.Text = clien.PostalCode;
                maskedTextBoxphonenumber.Text = clien.PhoneNumber;
                maskedTextBoxfaxnumber.Text = clien.FaxNumber;
                textBoxcreditlimit.Text = (clien.CreditLimit).ToString();
                textBoxclientID.Enabled = false;
                textBoxSearcher.Clear();


            }

            else
            {
                MessageBox.Show("User not Found!");
                textBoxSearcher.Clear();
                textBoxSearcher.Focus();
            }
        }
    }
}
