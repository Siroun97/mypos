using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SimplePOS
{
    public partial class addProductForm : Form
    {
        private readonly databaseManager dbManager;
        string connectionString = "Server=WIN-CEARVOQ7M2N\\SQLEXPRESS;Database=pos;Integrated Security=True;";
        
        public string Name { get; private set; }
        public int Barcode { get; private set; }
        public decimal Price { get; private set; }
        public int Quantity { get; private set; }

        // Declare your UI components
        private TextBox txtName;
        private TextBox txtPrice;
        private TextBox txtQuantity;
        private TextBox txtBarcode;
        private Label label1;
        private Label barcode;
        private Label price;
        private Label quantity;
        private Button btnAdd;

        public addProductForm()
        {
            dbManager = new databaseManager(connectionString);
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Check if any of the fields are empty
            if (string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtPrice.Text) ||
                string.IsNullOrWhiteSpace(txtQuantity.Text) ||
                string.IsNullOrWhiteSpace(txtBarcode.Text))
            {
                MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Get product details from the UI
            Name = txtName.Text;

            if (!decimal.TryParse(txtPrice.Text, out decimal price))
            {
                MessageBox.Show("Please enter a valid price.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Price = price;

            if (!int.TryParse(txtQuantity.Text, out int quantity))
            {
                MessageBox.Show("Please enter a valid quantity.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Quantity = quantity;

            if (!int.TryParse(txtBarcode.Text, out int barcode))
            {
                MessageBox.Show("Please enter a valid barcode.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Barcode = barcode;

            // Insert the new product into the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Products (Name, Barcode, Price, Quantity) VALUES (@Name, @Barcode, @Price, @Quantity)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", Name);
                command.Parameters.AddWithValue("@Barcode", Barcode);
                command.Parameters.AddWithValue("@Price", Price);
                command.Parameters.AddWithValue("@Quantity", Quantity);

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
        private void InitializeComponent()
        {
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.barcode = new System.Windows.Forms.Label();
            this.price = new System.Windows.Forms.Label();
            this.quantity = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(30, 87);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(200, 20);
            this.txtName.TabIndex = 0;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(30, 197);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(200, 20);
            this.txtPrice.TabIndex = 1;
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(30, 245);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(200, 20);
            this.txtQuantity.TabIndex = 2;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(30, 287);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Add Product";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtBarcode
            // 
            this.txtBarcode.Location = new System.Drawing.Point(30, 141);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(200, 20);
            this.txtBarcode.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "product name";
            // 
            // barcode
            // 
            this.barcode.AutoSize = true;
            this.barcode.Location = new System.Drawing.Point(42, 125);
            this.barcode.Name = "barcode";
            this.barcode.Size = new System.Drawing.Size(46, 13);
            this.barcode.TabIndex = 6;
            this.barcode.Text = "barcode";
            // 
            // price
            // 
            this.price.AutoSize = true;
            this.price.Location = new System.Drawing.Point(42, 181);
            this.price.Name = "price";
            this.price.Size = new System.Drawing.Size(30, 13);
            this.price.TabIndex = 7;
            this.price.Text = "price";
            // 
            // quantity
            // 
            this.quantity.AutoSize = true;
            this.quantity.Location = new System.Drawing.Point(42, 229);
            this.quantity.Name = "quantity";
            this.quantity.Size = new System.Drawing.Size(44, 13);
            this.quantity.TabIndex = 8;
            this.quantity.Text = "quantity";
            // 
            // addProductForm
            // 
            this.ClientSize = new System.Drawing.Size(280, 322);
            this.Controls.Add(this.quantity);
            this.Controls.Add(this.price);
            this.Controls.Add(this.barcode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBarcode);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.txtName);
            this.Name = "addProductForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
