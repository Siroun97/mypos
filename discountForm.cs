using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mypos
{
    public partial class discountForm : Form
    {
        decimal price;
        public decimal DiscountedPrice { get; private set; }

        public discountForm(decimal price)
        {
            
            InitializeComponent();
            label1.Hide();
            ten.Hide();
            twenty.Hide();
            thirty.Hide();
            fourty.Hide();
            fifty.Hide();
            sixty.Hide();
            seventy.Hide(); 
            eighty.Hide();
            ninty.Hide();
            textBoxDiscount.Hide();
            buttonOk.Hide();
            this.price = price;
        }

        private void remise_Click(object sender, EventArgs e)
        {
            ten.Show();
            twenty.Show();
            thirty.Show();
            fourty.Show(); 
            fifty.Show();
            sixty.Show(); 
            seventy.Show();
            eighty.Show();
            ninty.Show();
            buttonOk.Hide();
            remise.Hide();

            dtprice.Hide();

            

        }

        private void dtprice_Click(object sender, EventArgs e)
        {
            remise.Hide();  // Hides the control named 'remise'

            dtprice.Hide();  // Hides the control that triggered the click event (assuming it's named 'dtprice')
            label1.Show();   // Shows the label named 'label1'
            textBoxDiscount.Show();  // Shows the text box named 'textBoxDiscount'
            buttonOk.Show();

        }

        private void ten_Click(object sender, EventArgs e)
        {
             decimal x = price * 10 / 100;
             DiscountedPrice = price - x;
            

        }

        private void twenty_Click(object sender, EventArgs e)
        {
            decimal x = price * 20 / 100;
            DiscountedPrice = price - x;
            this.Close();

        }

        private void thirty_Click(object sender, EventArgs e)
        {
            decimal x = price * 30 / 100;
            DiscountedPrice = price - x;
            this.Close();
        }

        private void fourty_Click(object sender, EventArgs e)
        {
            decimal x = price * 40 / 100;
            DiscountedPrice = price - x;
            this.Close();

        }

        private void fifty_Click(object sender, EventArgs e)
        {
            decimal x = price * 50 / 100;
            DiscountedPrice = price - x;
            this.Close();
        }

        private void sixty_Click(object sender, EventArgs e)
        {
            decimal x = price * 60 / 100;
            DiscountedPrice = price - x;
            this.Close();

        }

        private void seventy_Click(object sender, EventArgs e)
        {
            decimal x = price * 70 / 100;
            DiscountedPrice = price - x;
            this.Close();

        }

        private void eighty_Click(object sender, EventArgs e)
        {
            decimal x = price * 80 / 100;
            DiscountedPrice = price - x;
            this.Close();

        }

        private void ninty_Click(object sender, EventArgs e)
        {
            decimal x = price * 90 / 100;
            DiscountedPrice = price - x;
            this.Close();

        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            // Attempt to parse the input from textBoxDiscount
            if (int.TryParse(textBoxDiscount.Text.Trim(), out int discountedPrice))
            {
                // Parsing successful, do something with 'discountedPrice'
                DiscountedPrice = discountedPrice;
                this.Close();  // Close the current form or dialog
            }
            else
            {
                // Parsing failed, handle the error (e.g., display a message to the user)
                MessageBox.Show("Please enter a valid integer for the discounted price.");
                // Optionally, clear or focus on the textBoxDiscount for correction
                textBoxDiscount.Focus();
            }
        }
    }
}
