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
    public partial class Inventory : Form
    {
        public Inventory()
        {
            InitializeComponent();
        }
        private void ClearAll() 
        {
            textBoxNamePublisher.Clear();
            textBoxEmailPublisher.Clear();
            maskedTextBoxPhoneNumber.Clear();

        }
        private void ClearAll2() 
        {
            textBoxISBN.Clear();
            textBoxTitle.Clear();
            textBoxAuthor.Clear();
            textBoxYearPublished.Clear();
            textBoxQOH.Clear();
            textBoxUnitPrice.Clear();
        }
        private void ClearAll3() 
        {
            textBoxAuthorID.Clear();
            textBoxFirstName.Clear();
            textBoxLastName.Clear();
            textBoxEmail.Clear();

        }
        private void ClearAll4()
        {
            textBoxISBNSoftware.Clear();
            textBoxTitleSoftware.Clear();
            textBoxAuthorSoftware.Clear();
            textBoxQOHSoftware.Clear();
            textBoxSoftwareUnitPrice.Clear();
        }
        private void ExitPubli_Click(object sender, EventArgs e)
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

        private void ReturnPubli_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login log = new Login();
            log.Show();
        }

        private void buttonReturnBook_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login log = new Login();
            log.Show();
        }

        private void buttonReturnAuthor_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login log = new Login();
            log.Show();
        }

        private void ButtonExitAuthor_Click(object sender, EventArgs e)
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

        private void buttonExitBook_Click(object sender, EventArgs e)
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

        private void buttonSavePublisher_Click(object sender, EventArgs e)
        {
            if ((textBoxNamePublisher.Text == "") || (textBoxEmailPublisher.Text == "") || (maskedTextBoxPhoneNumber.Text == ""))
            {
                MessageBox.Show("You have to fill out all the boxes, try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Publisher publishe = new Publisher();

                publishe.PUBname = textBoxNamePublisher.Text;
                publishe.PUbAddress = textBoxEmailPublisher.Text;
                publishe.PUBphone = maskedTextBoxPhoneNumber.Text;
                PublisherDA.Save(publishe);
                ClearAll();
            }
        }

        private void buttonDeletePublisher_Click(object sender, EventArgs e)
        {
            PublisherDA.Delete(textBoxNamePublisher.Text);
            MessageBox.Show(" Publisher record has been deleted successfully", "Confirmation");
            ClearAll();
        }

        private void buttonListPublisher_Click(object sender, EventArgs e)
        {
            listViewPublisher.Items.Clear();


            PublisherDA.ListPublisher(listViewPublisher);
        }

        private void buttonSearchPublisher_Click(object sender, EventArgs e)
        {
            Publisher publi = PublisherDA.Searchbyphonenumber(maskedTextBox1.Text);
            if (publi != null)
            {
                textBoxNamePublisher.Text = publi.PUBname;
                textBoxEmailPublisher.Text = publi.PUbAddress;
                maskedTextBoxPhoneNumber.Text = publi.PUBphone;

                textBoxNamePublisher.Enabled = false;

            }

            else
            {
                MessageBox.Show("User not Found!");
                maskedTextBox1.Clear();
                maskedTextBox1.Focus();
            }
        }

        private void buttonSaveEmployee_Click(object sender, EventArgs e)
        {
            if ((textBoxISBN.Text == "") || (textBoxTitle.Text == "") || (textBoxAuthor.Text == "") || (textBoxYearPublished.Text == "") || (textBoxQOH.Text == "") || (textBoxUnitPrice.Text == ""))
            {
                MessageBox.Show("You have to fill out all the boxes, try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else 
            {
                Books book = new Books();

                book.ISBN = Convert.ToInt32(textBoxISBN.Text);
                book.Title = textBoxTitle.Text;
                book.BookAuthor = textBoxAuthor.Text;
                book.BookYearPublished = textBoxYearPublished.Text;
                book.BookQOH = Convert.ToInt32(textBoxQOH.Text);
                book.BookUnitePrice = Convert.ToInt32(textBoxUnitPrice.Text);
                BooksDA.Save(book);
                ClearAll2();
            }
        }

        private void buttonDeleteBook_Click(object sender, EventArgs e)
        {
            BooksDA.Delete(Convert.ToInt32(textBoxISBN.Text));
            MessageBox.Show(" Book record has been deleted successfully", "Confirmation");
            ClearAll2();
        }

        private void buttonUpdateBook_Click(object sender, EventArgs e)
        {
            if ((textBoxTitle.Text == "") || (textBoxAuthor.Text == "") || (textBoxYearPublished.Text == "") || (textBoxQOH.Text == "") || (textBoxUnitPrice.Text == ""))
            {
                MessageBox.Show("Please fill all the fields ", "Missing Data");
                textBoxISBN.Clear();
                textBoxISBN.Focus();
                return;
            }
            else
            {
                Books book = new Books();
                book.ISBN = Convert.ToInt32(textBoxISBN.Text);
                book.Title = textBoxTitle.Text;
                book.BookAuthor = textBoxAuthor.Text;
                book.BookYearPublished = textBoxYearPublished.Text;
                book.BookQOH = Convert.ToInt32(textBoxQOH.Text);
                book.BookUnitePrice = Convert.ToInt32(textBoxUnitPrice.Text);
                DialogResult ans = MessageBox.Show("Do you really want to update this Book information?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (ans == DialogResult.Yes)
                {
                    BooksDA.Update(book);
                    MessageBox.Show("Book record has been updated successfully", "Confirmation");
                }
                textBoxNamePublisher.Enabled = true;
                ClearAll2();
            }
        }

        private void buttonUpdatePublisher_Click(object sender, EventArgs e)
        {
            if ((textBoxNamePublisher.Text == "") || (textBoxEmailPublisher.Text == "") || (maskedTextBoxPhoneNumber.Text == ""))
            {
                MessageBox.Show("Please fill all the fields ", "Missing Data");
                textBoxNamePublisher.Clear();
                textBoxNamePublisher.Focus();
                return;
            }
            else
            {
                Publisher publi = new Publisher();
                publi.PUBname = textBoxNamePublisher.Text;
                publi.PUbAddress = textBoxEmailPublisher.Text;
                publi.PUBphone = maskedTextBoxPhoneNumber.Text;
                DialogResult ans = MessageBox.Show("Do you really want to update this Publisher?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (ans == DialogResult.Yes)
                {
                    PublisherDA.Update(publi);
                    MessageBox.Show("Publisher record has been updated successfully", "Confirmation");
                }
                textBoxNamePublisher.Enabled = true;
                ClearAll();
            }
        }

        private void buttonListBook_Click(object sender, EventArgs e)
        {
            listViewBook.Items.Clear();


            BooksDA.ListBook(listViewBook);
        }

        private void buttonSearchBook_Click(object sender, EventArgs e)
        {
            int choice = comboBoxBook.SelectedIndex;
            switch (choice)
            {
                case -1:
                    MessageBox.Show("Please select the search option");
                    break;
                case 0:
                    Books book = BooksDA.Search(Convert.ToInt32(textBoxEnterInformation.Text));
                    if (book != null)
                    {

                        textBoxISBN.Text = book.ISBN.ToString();
                        textBoxTitle.Text = book.Title;
                        textBoxAuthor.Text = book.BookAuthor;
                        textBoxYearPublished.Text = (book.BookYearPublished).ToString();
                        textBoxQOH.Text = (book.BookQOH).ToString();
                        textBoxUnitPrice.Text = (book.BookUnitePrice).ToString();



                        textBoxISBN.Enabled = false;

                    }

                    else
                    {
                        MessageBox.Show("ISBN not Found!");
                        textBoxEnterInformation.Clear();
                        textBoxEnterInformation.Focus();
                    }
                    break;
                case 1:
                    Books boo = BooksDA.SearchTitle(textBoxEnterInformation.Text);
                    if (boo != null)
                    {

                        textBoxISBN.Text = (boo.ISBN).ToString();
                        textBoxTitle.Text = boo.Title;
                        textBoxAuthor.Text = boo.BookAuthor;
                        textBoxYearPublished.Text = (boo.BookYearPublished).ToString();
                        textBoxQOH.Text = (boo.BookQOH).ToString();
                        textBoxUnitPrice.Text = (boo.BookUnitePrice).ToString();

                        textBoxISBN.Enabled = false;

                    }

                    else
                    {
                        MessageBox.Show("Title not Found!");
                        textBoxEnterInformation.Clear();
                        textBoxEnterInformation.Focus();
                    }
                    break;

                default:
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int choice = comboBox1.SelectedIndex;
            switch (choice)
            {
                case -1:
                    MessageBox.Show("Please select the search option");
                    break;
                case 0:
                    Author autho = AuthorDA.Search(Convert.ToInt32(textBoxInformationauthor.Text));
                    if (autho != null)
                    {

                        textBoxAuthor.Text = autho.FName;


                        

                    }

                    else
                    {
                        MessageBox.Show("Author not Found!");
                        textBoxInformationauthor.Clear();
                        textBoxInformationauthor.Focus();
                    }
                    break;
                case 1:
                    Author auth = AuthorDA.Searchemail(textBoxInformationauthor.Text);
                    if (auth != null)
                    {

                        textBoxAuthor.Text = auth.FName;


                        

                    }

                    else
                    {
                        MessageBox.Show("Email not Found!");
                        textBoxInformationauthor.Clear();
                        textBoxInformationauthor.Focus();
                    }
                    break;

                default:
                    break;
            }
        }

        private void buttonSave2_Click(object sender, EventArgs e)
        {
            if ((textBoxAuthorID.Text == "") || (textBoxFirstName.Text == "") || (textBoxLastName.Text == "") || (textBoxEmail.Text == ""))
            {
                MessageBox.Show("You have to fill out all the boxes, try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Author auth = new Author();
                auth.AuthorID = Convert.ToInt32(textBoxAuthorID.Text);
                auth.FName = textBoxFirstName.Text;
                auth.LName = textBoxLastName.Text;
                auth.Email = textBoxEmail.Text;
                AuthorDA.Save(auth);
            }
            ClearAll3();
        }

        private void buttonUpdateauthor_Click(object sender, EventArgs e)
        {
            if ((textBoxFirstName.Text == "") || (textBoxLastName.Text == "") || (textBoxEmail.Text == ""))

            {
                MessageBox.Show("Please fill all the fields ", "Missing Data");
                textBoxNamePublisher.Clear();
                textBoxNamePublisher.Focus();
                return;
            }
            else
            {
                Author auth = new Author();
                auth.AuthorID = Convert.ToInt32(textBoxAuthorID.Text);
                auth.FName = textBoxFirstName.Text;
                auth.LName = textBoxLastName.Text;
                auth.Email = textBoxEmail.Text;
                DialogResult ans = MessageBox.Show("Do you really want to update this author?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (ans == DialogResult.Yes)
                {
                    AuthorDA.Update(auth);
                    MessageBox.Show("author record has been updated successfully", "Confirmation");
                }
                textBoxAuthorID.Enabled = true;
                ClearAll3();
            }
        }

        private void buttonListauthor_Click(object sender, EventArgs e)
        {
            listViewAuthor.Items.Clear();


            AuthorDA.ListAuthor(listViewAuthor);
        }

        private void buttonDeleteauthor_Click(object sender, EventArgs e)
        {
            AuthorDA.Delete(Convert.ToInt32(textBoxAuthorID.Text));
            MessageBox.Show(" Author record has been deleted successfully", "Confirmation");
            ClearAll3();
        }

        private void buttonSearcherAuthor_Click(object sender, EventArgs e)
        {
            int choice = comboBoxAuthor.SelectedIndex;
            switch (choice)
            {
                case -1:
                    MessageBox.Show("Please select the search option");
                    break;
                case 0:
                    Author autho = AuthorDA.Search(Convert.ToInt32(textBoxInformationauthor.Text));
                    if (autho != null)
                    {
                        textBoxAuthorID.Text = (autho.AuthorID).ToString();
                        textBoxFirstName.Text = autho.FName;
                        textBoxLastName.Text = autho.LName;
                        textBoxEmail.Text = autho.Email;

                        textBoxAuthorID.Enabled = false;

                    }

                    else
                    {
                        MessageBox.Show("Author not Found!");
                        textBoxInformationauthor.Clear();
                        textBoxInformationauthor.Focus();
                    }
                    break;
                case 1:
                    Author auth = AuthorDA.Searchemail(textBoxInformationauthor.Text);
                    if (auth != null)
                    {
                        textBoxAuthorID.Text = (auth.AuthorID).ToString();
                        textBoxFirstName.Text = auth.FName;
                        textBoxLastName.Text = auth.LName;
                        textBoxEmail.Text = auth.Email;

                        textBoxAuthorID.Enabled = false;

                    }

                    else
                    {
                        MessageBox.Show("Email not Found!");
                        textBoxInformationauthor.Clear();
                        textBoxInformationauthor.Focus();
                    }
                    break;

                default:
                    break;
            }
        }

        private void buttonSaveSoftware_Click(object sender, EventArgs e)
        {
            if ((textBoxSoftwareUnitPrice.Text == "" ) || (textBoxISBNSoftware.Text == "") || (textBoxTitleSoftware.Text == "") || (textBoxAuthorSoftware.Text == "") || (textBoxQOHSoftware.Text == ""))
            {
                MessageBox.Show("You have to fill out all the boxes, try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Software soft = new Software();
                soft.ISBN = Convert.ToInt32(textBoxISBNSoftware.Text);
                soft.Title = textBoxTitleSoftware.Text;
                soft.SoftwareAuthor = textBoxAuthorSoftware.Text;
                soft.SoftwareQOH = Convert.ToInt32(textBoxQOHSoftware.Text);
                soft.SoftwareUnitePrice = Convert.ToInt32(textBoxSoftwareUnitPrice.Text);
                SoftwareDA.Save(soft);
            }
            ClearAll4();
        }

        private void buttonListSoftware_Click(object sender, EventArgs e)
        {
            listViewAuthor.Items.Clear();


            SoftwareDA.ListSoftware(listViewSoftware);
        }

        private void buttonUpdateSoftware_Click(object sender, EventArgs e)
        {
            if ((textBoxSoftwareUnitPrice.Text == "") || (textBoxISBNSoftware.Text == "") || (textBoxTitleSoftware.Text == "") || (textBoxAuthorSoftware.Text == "") || (textBoxQOHSoftware.Text == ""))
            {
                MessageBox.Show("You have to fill out all the boxes, try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Software soft = new Software();
                soft.ISBN = Convert.ToInt32(textBoxISBNSoftware.Text);
                soft.Title = textBoxTitleSoftware.Text;
                soft.SoftwareAuthor = textBoxAuthorSoftware.Text;
                soft.SoftwareQOH = Convert.ToInt32(textBoxQOHSoftware.Text);
                soft.SoftwareUnitePrice = Convert.ToInt32(textBoxSoftwareUnitPrice.Text);
                DialogResult ans = MessageBox.Show("Do you really want to update this author?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (ans == DialogResult.Yes)
                {
                    SoftwareDA.Update(soft);
                    MessageBox.Show("author record has been updated successfully", "Confirmation");
                }
                ClearAll4();
            }
        }

        private void buttonDeleteSoftware_Click(object sender, EventArgs e)
        {
            SoftwareDA.Delete(Convert.ToInt32(textBoxISBNSoftware.Text));
            MessageBox.Show(" Software record has been deleted successfully", "Confirmation");
            ClearAll4();
        }

        private void buttonExitSoftware_Click(object sender, EventArgs e)
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

        private void buttonReturnSoftware_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login log = new Login();
            log.Show();
        }

        private void comboBoxBook_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buttonSearchSoftware_Click(object sender, EventArgs e)
        {
            int choice = comboBoxsearchsoftware.SelectedIndex;
            switch (choice)
            {
                case -1:
                    MessageBox.Show("Please select the search option");
                    break;
                case 0:
                    Software soft = SoftwareDA.Search(Convert.ToInt32(textBox3.Text));
                    if (soft != null)
                    {
                        textBoxISBNSoftware.Text = soft.ISBN.ToString();
                        textBoxTitleSoftware.Text = soft.Title;
                        textBoxAuthorSoftware.Text = soft.SoftwareAuthor;
                        textBoxQOHSoftware.Text = soft.SoftwareQOH.ToString();
                        textBoxSoftwareUnitPrice.Text = soft.SoftwareUnitePrice.ToString();


                        textBoxISBNSoftware.Enabled = false;

                    }

                    else
                    {
                        MessageBox.Show("ISBN not Found!");
                        textBoxEnterInformation.Clear();
                        textBoxEnterInformation.Focus();
                    }
                    break;
                case 1:
                    Software sof = SoftwareDA.SearchTitle(Convert.ToString(textBox3.Text));
                    if (sof != null)
                    {

                        textBoxISBNSoftware.Text = sof.ISBN.ToString();
                        textBoxTitleSoftware.Text = sof.Title;
                        textBoxAuthorSoftware.Text = sof.SoftwareAuthor;
                        textBoxQOHSoftware.Text = sof.SoftwareQOH.ToString();
                        textBoxSoftwareUnitPrice.Text = sof.SoftwareUnitePrice.ToString();


                        textBoxISBNSoftware.Enabled = false;

                        textBoxISBN.Enabled = false;

                    }

                    else
                    {
                        MessageBox.Show("Title not Found!");
                        textBox3.Clear();
                        textBox3.Focus();
                    }
                    break;

                default:
                    break;
            }
        }

        private void buttonSearchAuthorsoftware_Click(object sender, EventArgs e)
        {
            
                int choice = comboBoxsearchauthor.SelectedIndex;
            switch (choice)
            {
                case -1:
                    MessageBox.Show("Please select the search option");
                    break;
                case 0:
                    Author autho = AuthorDA.Search(Convert.ToInt32(textBoxInformationauthor.Text));
                    if (autho != null)
                    {

                        textBoxAuthor.Text = autho.FName;


                       

                    }

                    else
                    {
                        MessageBox.Show("Author not Found!");
                        textBox1.Clear();
                        textBox1.Focus();
                    }
                    break;
                case 1:
                    Author auth = AuthorDA.Searchemail(textBoxInformationauthor.Text);
                    if (auth != null)
                    {

                        textBoxAuthor.Text = auth.FName;


                        

                    }

                    else
                    {
                        MessageBox.Show("Email not Found!");
                        textBox1.Clear();
                        textBox1.Focus();
                    }
                    break;

                default:
                    break;
            }
        }
    }
    }

