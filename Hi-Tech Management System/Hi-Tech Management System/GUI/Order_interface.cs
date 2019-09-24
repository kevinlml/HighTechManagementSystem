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
    public partial class Order_interface : Form
    {
        public Order_interface()
        {
            InitializeComponent();
        }
        private void ClearAll() 
        {
            Convert.ToInt32(textBoxOrderNumber.Text);
            textBoxclientname.Clear();
            textBoxbooktitle.Clear();
            textBoxOrderQuantity.Clear();
            textBoxUnitPrice.Clear();
            textBoxSubtotal.Clear();
            textBoxGST.Clear();
            textBoxPST.Clear();
            textBoxtotal.Clear();
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

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login  log = new Login();
            log.Show();
        }

        private void buttonSaveEmployee_Click(object sender, EventArgs e)
        {
            if ((textBoxclientname.Text == "") || (textBoxbooktitle.Text == "") || (textBoxOrderQuantity.Text == "") || (textBoxUnitPrice.Text == "") || (textBoxSubtotal.Text == "") || (textBoxGST.Text == "") || (textBoxPST.Text == "") || (textBoxtotal.Text == ""))
            {

                MessageBox.Show("Please full fill all the fields", "Missing Data");
                ClearAll();
                return;
            }
            else
            {
                Client client = ClientsDA.SearchNM(textBoxclientname.Text);
                Books book = BooksDA.SearchTitle(textBoxbooktitle.Text);
                string qtfh = textBoxclientname.Text;
                string asda = textBoxbooktitle.Text;
                int lalala = Convert.ToInt32(textBoxOrderQuantity.Text);
                if (book == null)
                {
                    MessageBox.Show("Wrong Information book, try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else if (client == null)
                {
                    MessageBox.Show("Wrong Information client, try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else if (book.BookQOH < Convert.ToInt32(textBoxOrderQuantity.Text))
                {
                    MessageBox.Show("The inventory does not have that quantity of products", "Missing Product");
                    ClearAll();
                    return;
                }
                else
                {
                    Order Or = new Order();

                    if ((client.Name == textBoxclientname.Text) && (book.Title.ToString() == textBoxbooktitle.Text) && (book.BookQOH < Convert.ToInt32(textBoxOrderQuantity.Text)))
                    {
                        Or.OrdernUmber = Convert.ToInt32(textBoxOrderNumber.Text);
                        Or.OrderDate = dateTimePickerOrder.Text;
                        Or.ShippingDate = dateTimePickerShipping.Text;
                        Or.ClientNumber = textBoxclientname.Text;
                        Or.BookName = textBoxbooktitle.Text;
                        Or.Quantity = Convert.ToInt32(textBoxOrderQuantity.Text);
                        Or.unit = Convert.ToInt32(textBoxUnitPrice.Text);
                        Or.Subtotal = Convert.ToInt32(textBoxSubtotal.Text);
                        Or.Gst = Convert.ToInt32(textBoxGST.Text);
                        Or.Pst = Convert.ToInt32(textBoxPST.Text);
                        Or.total = Convert.ToInt32(textBoxtotal.Text);
                        OrdersDA.Save(Or);
                        ClearAll();
                    }
                }
                

            }                
            
        }

        private void buttonUpdateEmployee_Click(object sender, EventArgs e)
        {
            if ((textBoxclientname.Text == "") || (textBoxbooktitle.Text == "") || (textBoxOrderQuantity.Text == "") || (textBoxUnitPrice.Text == "") || (textBoxSubtotal.Text == "") || (textBoxGST.Text == "") || (textBoxPST.Text == "") || (textBoxtotal.Text == ""))
            {
                MessageBox.Show("Please full fill all the fields", "Missing Data");

                return;
            }
            else
            {

            }
            {
                Order Us = new Order();
                Us.OrdernUmber = Convert.ToInt32(textBoxOrderNumber.Text);
                Us.OrderDate = dateTimePickerOrder.Text;
                Us.ShippingDate = dateTimePickerShipping.Text;
                Us.ClientNumber = textBoxclientname.Text;
                Us.BookName = textBoxbooktitle.Text;
                Us.Quantity = Convert.ToSByte(textBoxOrderQuantity.Text);
                Us.unit = Convert.ToSByte(textBoxUnitPrice.Text);
                Us.Subtotal = Convert.ToSByte(textBoxSubtotal.Text);
                Us.Gst = Convert.ToSByte(textBoxGST.Text);
                Us.Pst = Convert.ToSByte(textBoxPST.Text);
                Us.unit = Convert.ToSByte(textBoxtotal.Text);
                DialogResult ans = MessageBox.Show("Do you really want to update this User?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (ans == DialogResult.Yes)
                {
                    OrdersDA.Update(Us);
                    MessageBox.Show("User record has been updated successfully", "Confirmation");
                }
                textBoxOrderNumber.Enabled = true;
                ClearAll();
            }
        }

        private void buttonDeleteEmployee_Click(object sender, EventArgs e)
        {
            OrdersDA.Delete(textBoxOrderNumber.Text);
            MessageBox.Show(" Order record has been deleted successfully", "Confirmation");
        }

        private void buttonListEmployee_Click(object sender, EventArgs e)
        {
            listViewOrder.Items.Clear();


            OrdersDA.ListOrder(listViewOrder);
        }

        private void buttonSearchOrder_Click(object sender, EventArgs e)
        {
            Order Or = OrdersDA.SearchN(Convert.ToInt32(textBoxOrderSearcher.Text));
            if (Or != null)
            {

                textBoxOrderNumber.Text = Or.OrdernUmber.ToString();
                dateTimePickerOrder.Text = Or.OrderDate;
                dateTimePickerShipping.Text = Or.ShippingDate;
                textBoxclientname.Text = Or.ClientNumber;
                textBoxbooktitle.Text = Or.BookName;
                textBoxOrderQuantity.Text = Or.Quantity.ToString();
                textBoxUnitPrice.Text = Or.unit.ToString();
                textBoxSubtotal.Text = Or.Subtotal.ToString();
                textBoxGST.Text = Or.Gst.ToString();
                textBoxPST.Text = Or.Pst.ToString();
                textBoxtotal.Text = Or.total.ToString();


                textBoxOrderSearcher.Clear();


            }

            else
            {
                MessageBox.Show("User not Found!");
                textBoxOrderSearcher.Clear();
                textBoxOrderSearcher.Focus();
            }
        }

        private void buttonSearchBook_Click(object sender, EventArgs e)
        {
            Books book = BooksDA.Search(Convert.ToInt32(textBoxBookSearcher.Text));
            if (book != null)
            {


                textBoxBookSearcher.Text = book.Title;

                textBoxBookSearcher.Clear();




            }

            else
            {
                MessageBox.Show("ISBN not Found!");
                textBoxBookSearcher.Clear();
                textBoxBookSearcher.Focus();
            }
        }

        private void buttonSearchClient_Click(object sender, EventArgs e)
        {
            Client clien = ClientsDA.SearchID(Convert.ToInt32(textBoxClientSearcher.Text));
            if (clien != null)
            {

                textBoxclientname.Text = clien.Name;


                textBoxClientSearcher.Clear();


            }

            else
            {
                MessageBox.Show("User not Found!");
                textBoxClientSearcher.Clear();
                textBoxClientSearcher.Focus();
            }
        }
    }
}
