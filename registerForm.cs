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
    public partial class registerForm : Form
    {

        private readonly databaseManager dbManager;
        string connectionString = "Server=WIN-CEARVOQ7M2N\\SQLEXPRESS;Database=pos;Integrated Security=True;";

        public string Username { get; private set; }
        public string Password { get; private set; }
        public int UserType { get; private set; }

        // Declare your UI components
        private TextBox textBoxusername;
        private TextBox textBoxpassword;
       
        private Button buttonRegister;

        public registerForm()
        {
            dbManager = new databaseManager(connectionString);
            InitializeComponent();
        }

       
        public DialogResult ShowDialog()
        {
            return base.ShowDialog(); // Call base class's ShowDialog() method
        }

        private void buttonRegister_Click_1(object sender, EventArgs e)
        {
            // Get product details from the UI
            Username = textBoxusername.Text;
            Password = textBoxpassword.Text;


            // Insert the new product into the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Users (Username, Password, UserType) VALUES (@Username, @Password, 'Cashier')";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", Username);
                command.Parameters.AddWithValue("@Password", Password);
                // command.Parameters.AddWithValue("@UserType", UserType);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Product added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Failed to add product.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
