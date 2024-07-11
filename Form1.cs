using mypos;
using System;
using System.Data;
using System.Windows.Forms;

namespace SimplePOS
{
    public partial class Form1 : Form
    {
     
        private readonly productManager productManager = new productManager();
        private DataTable productsTable;

        public Form1()
        {
            this.Load += new EventHandler(Form1_Load);
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            // Load products into DataGridView
            LoadProducts();
        }

        private void LoadProducts()
        {
           // MessageBox.Show($"Number of products fetched:");
            // Fetch all products from the database
            DataTable productsTable = productManager.GetAllProducts();
            // MessageBox.Show($"Number of products fetched: {productsTable.Rows.Count}");
            productsTable.DefaultView.AllowEdit = false;
            productsTable.DefaultView.AllowNew = false;
            productsTable.DefaultView.AllowDelete = false;

            // Set the DataSource property of the DataGridView to the DataTable
            dataGridViewProducts.DataSource = productsTable;
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            // Filter products based on search text
            string searchText = textBoxSearch.Text.Trim();
            if (!string.IsNullOrEmpty(searchText))
            {
                DataView dv = new DataView(productsTable);
                dv.RowFilter = $"Name LIKE '%{searchText}%' OR Barcode LIKE '%{searchText}%'";
                dataGridViewProducts.DataSource = dv;
            }
            else
            {
                // If search text is empty, show all products
                dataGridViewProducts.DataSource = productsTable;
            }
        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            // Open addProductForm
            using (addProductForm addProductForm = new addProductForm())
            {
                if (addProductForm.ShowDialog() == DialogResult.OK)
                {
                    // If a new product was added, refresh the DataGridView
                    LoadProducts();
                }
            }
        }
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            // Check if a row is selected
            if (dataGridViewProducts.SelectedRows.Count > 0)
            {
                // Get the selected product's ID
                var productIdCell = dataGridViewProducts.SelectedRows[0].Cells["ProductId"];

                // Check if the product ID cell value is not null
                if (productIdCell.Value != null && productIdCell.Value != DBNull.Value)
                {
                    int productId = (int)productIdCell.Value;

                    // Delete the selected product from the database
                    // (You need to implement this method in your productManager)
                    productManager.DeleteProduct(productId);

                    // Refresh the DataGridView to reflect the changes
                    LoadProducts();
                }
                else
                {
                    MessageBox.Show("The selected product does not have a valid ID.", "Delete Product", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Please select a product to delete.", "Delete Product", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }



        private void InitializeComponent()
        {
            this.dataGridViewProducts = new System.Windows.Forms.DataGridView();
            this.buttonNew = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.buttonEndOfDay = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProducts)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewProducts
            // 
            this.dataGridViewProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProducts.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridViewProducts.Location = new System.Drawing.Point(0, 353);
            this.dataGridViewProducts.Name = "dataGridViewProducts";
            this.dataGridViewProducts.Size = new System.Drawing.Size(1370, 353);
            this.dataGridViewProducts.TabIndex = 0;
            // 
            // buttonNew
            // 
            this.buttonNew.Location = new System.Drawing.Point(526, 35);
            this.buttonNew.Name = "buttonNew";
            this.buttonNew.Size = new System.Drawing.Size(75, 23);
            this.buttonNew.TabIndex = 1;
            this.buttonNew.Text = "New";
            this.buttonNew.UseVisualStyleBackColor = true;
            this.buttonNew.Click += new System.EventHandler(this.buttonNew_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(419, 35);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(75, 23);
            this.buttonDelete.TabIndex = 2;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Location = new System.Drawing.Point(33, 35);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(100, 20);
            this.textBoxSearch.TabIndex = 3;
            this.textBoxSearch.TextChanged += new System.EventHandler(this.textBoxSearch_TextChanged_1);
            // 
            // buttonEndOfDay
            // 
            this.buttonEndOfDay.Location = new System.Drawing.Point(1255, 286);
            this.buttonEndOfDay.Name = "buttonEndOfDay";
            this.buttonEndOfDay.Size = new System.Drawing.Size(103, 52);
            this.buttonEndOfDay.TabIndex = 4;
            this.buttonEndOfDay.Text = "End of Day";
            this.buttonEndOfDay.UseVisualStyleBackColor = true;
            this.buttonEndOfDay.Click += new System.EventHandler(this.buttonEndOfDay_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Firebrick;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(1324, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(34, 33);
            this.button1.TabIndex = 5;
            this.button1.TabStop = false;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(1370, 706);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonEndOfDay);
            this.Controls.Add(this.textBoxSearch);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonNew);
            this.Controls.Add(this.dataGridViewProducts);
            this.Name = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProducts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        private DataGridView dataGridViewProducts;
        private Button buttonNew;
        private Button buttonDelete;
        private TextBox textBoxSearch;

        private void textBoxSearch_TextChanged_1(object sender, EventArgs e)
        {

        }

        private Button buttonEndOfDay;

        private void buttonEndOfDay_Click(object sender, EventArgs e)
        {
            if (productManager.endOfDayAmount() > 0)
            {


                DialogResult dialogResult = MessageBox.Show(" The Total of today is:  " + productManager.endOfDayAmount() + " \n  Are you sure you want to end the day?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {

                    productManager.endOfDay();
                    MessageBox.Show(" Successful ", "Search", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }

            }
            else
            {
                MessageBox.Show("No sales found.", "Search", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private Button button1;

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            loginForm loginForm = new loginForm();
            loginForm.ShowDialog();
        }
    }

}
