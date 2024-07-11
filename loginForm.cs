using SimplePOS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mypos
{
    public partial class loginForm : Form
    {
        private static string username;

        public static string Username
        {
            get { return username; }
            set { username = value; }
        }

        public loginForm()
        {
            InitializeComponent();
           
        }

        public void btnLogin_Click(object sender, EventArgs e)
        {
              Username = txtUsername.Text;
            string Password = txtPassword.Text;
            string UserType = cmbUserType.SelectedItem?.ToString(); // SelectedItem might be null, so use null conditional operator ?. to avoid null reference exception

            if (string.IsNullOrEmpty(UserType))
            {
                MessageBox.Show("Please select a user type.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Connect to your database
            string connectionString = "Server=WIN-CEARVOQ7M2N\\SQLEXPRESS;Database=pos;Integrated Security=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Query the users table to check credentials
                string query = "SELECT COUNT(*) FROM Users WHERE Username = @Username AND Password = @Password AND UserType = @UserType";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", Username);
                command.Parameters.AddWithValue("@Password", Password);
                command.Parameters.AddWithValue("@UserType", UserType);

                int count = (int)command.ExecuteScalar();

                if (count > 0)
                {
                    // Valid credentials, open the appropriate form
                    if (UserType == "Cashier")
                    {
                        cashierForm cashierForm = new cashierForm();
                        Username = txtUsername.Text;
                        cashierForm.Show();
                    }
                    else if (UserType == "Admin")
                    {
                        Form1 adminForm = new Form1();
                        adminForm.Show();
                    }

                    // Close the login form
                    this.Hide();
                }
                else
                {
                    // Invalid credentials, show error message
                    MessageBox.Show("Invalid Username or Password for the selected user type.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void register_Click(object sender, EventArgs e)
        {
            using (registerForm registerForm = new registerForm())
            {
                if (registerForm.ShowDialog() == DialogResult.OK)
                {
                    // If a new product was added, refresh the DataGridView
                   // LoadProducts();
                }
            }
        }
    }

}

