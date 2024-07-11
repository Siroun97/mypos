using mypos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing.Printing;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static salesmaager;
using static salesmaager1;

namespace SimplePOS
{
    public partial class cashierForm : Form
    {
        private readonly productManager productManager = new productManager();
        private readonly databaseManager dbManager;
        bool discounted = false;
        invoice invoice;
        
        private readonly string connectionString = "Server=WIN-CEARVOQ7M2N\\SQLEXPRESS;Database=pos;Integrated Security=True;";
        private Dictionary<int, int> rowQuantities = new Dictionary<int, int>();
        private DataTable salesHistoryTable;
        private int currentRowIndex = 0;
        private int totalSalesCount;
        private DataTable heldInvoiceData;
        private int selectedinvoice;
        bool print = false;


        int load = 0;
        public cashierForm()
        {
          
            productManager = new productManager();
            dbManager = new databaseManager(connectionString);
            
            InitializeComponent();
            InitializeDataGridView();
            labelusername.Text=loginForm.Username;
            timer1.Start();

            // Set the initial time in the label
            UpdateTime();
            buttonPrevious.Click += buttonPrevious_Click;
            buttonNext.Click += buttonNext_Click;
            salesHistoryTable = productManager.GetSalesHistory();
             totalSalesCount = salesHistoryTable.Rows.Count; // Initialize total sales count
    labelCount.Text = totalSalesCount.ToString();
            DisplaySalesHistory();
           
        }

        private void InitializeDataGridView()
        {
            DataGridViewTextBoxColumn qtyColumn = new DataGridViewTextBoxColumn();
            qtyColumn.Name = "qty"; // Set a unique name for the column
            qtyColumn.HeaderText = "Quantity";
            dataGridViewSearchResults.Columns.Add(qtyColumn);
            textBoxQuantity.Text = "1"; // Set default quantity to 1
                  //labeldate.Text = DateTime.Now.ToString();

            // labelusername.Text = loginName.Username;

            // Make sure the quantity column is visible and editable
            // dataGridViewSearchResults.Columns["qty"].Visible = true;


            dataGridViewSearchResults.Columns["qty"].ReadOnly = false;
           
           
            // Disable auto generation of rows
            dataGridViewSearchResults.AllowUserToAddRows = false;

            // Subscribe to RowsAdded event to set the quantity for each newly added row
            dataGridViewSearchResults.RowsAdded += dataGridViewSearchResults_RowsAdded;
        }
        private List<string> addedProductNames = new List<string>();

        private void cashierForm_KeyDown(object sender, KeyEventArgs e) // Change to KeyDown event
        {
            if (e.KeyCode == Keys.H && Control.ModifierKeys == Keys.Control)
            {
                
                HoldInvoice();
            }
            else if (e.KeyCode == Keys.L && Control.ModifierKeys == Keys.Control)
            {
               LoadHeldInvoice();
            }
            else if (e.KeyCode == Keys.D && Control.ModifierKeys == Keys.Control)
            {
                if (!invoice.discounted)
                {
                    discountForm discountform = new discountForm(totalamount());
                    discountform.ShowDialog();
                    decimal discountedPrice = discountform.DiscountedPrice;
                    if (discountedPrice != 0)
                    {
                        
                        labelTotalPrice.Text = discountedPrice.ToString();
                    }
                    
                    if (discountedPrice.ToString() != totalamount().ToString() & (discountedPrice!=0))
                    {
                        invoice.discounted = true;
                    }
                }
                else
                {
                    DialogResult dialogResult = MessageBox.Show("discount will be cancelled","", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes) {
                        DisplayTotalPrice();

                       invoice.discounted = false;

                    }
                   
                    
                }
            }
            // Add cases for other key combinations with e.KeyCode
        }
        List<List<int>> capturedQuantitiesList = new List<List<int>>();
        List<DataTable> heldInvoiceDataList = new List<DataTable>();

        private void HoldInvoice()
        {
            if (dataGridViewSearchResults.Rows.Count > 0)
            {
                labelTotalPrice.Text = 0.ToString();
                load = 0;
                heldInvoiceData = (DataTable)dataGridViewSearchResults.DataSource;

                if (heldInvoiceData.Columns.Count <= 6)
                {
                    // Option 1: Individual invoice storage (modify as needed)
                    List<int> Quantities = new List<int>(); // Temporary list to hold quantities

                    foreach (DataGridViewRow row in dataGridViewSearchResults.Rows)
                    {
                        int quantity = Convert.ToInt32(row.Cells[0].Value); // Assuming quantity is in the first column
                        Quantities.Add(quantity);
                    }

                    // Add a new invoice to the lists
                    heldInvoiceDataList.Add(heldInvoiceData.Copy()); // Add a copy of heldInvoiceData
                    capturedQuantitiesList.Add(new List<int>(Quantities));

                    // Clear data for the next invoice
                    dataGridViewSearchResults.DataSource = null;
                    dataGridViewSearchResults.Rows.Clear();
                    Quantities.Clear();
                }
                else
                {
                    // Option 2: Single DataTable for multiple invoices (consider adding columns for invoice details)
                    foreach (DataGridViewRow row in dataGridViewSearchResults.Rows)
                    {
                        int quantity = Convert.ToInt32(row.Cells[0].Value); // Assuming quantity is in the first column
                                                                            // Add quantity to a data structure or column for storing invoice quantities
                    }

                    // Add the entire heldInvoiceData to the list (assuming it holds data for the current invoice)
                    heldInvoiceDataList.Add(heldInvoiceData.Copy());

                    // Clear data for the next invoice
                    dataGridViewSearchResults.DataSource = null;
                    dataGridViewSearchResults.Rows.Clear();
                }
            }
            else
            {
                MessageBox.Show("No invoice to hold.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void LoadHeldInvoice()
        {
            if (heldInvoiceDataList.Count == 1)
            {

                load = 1;
                Console.WriteLine("invoiceid " + invoice.InvoiceID.ToString());
                // Only one invoice, load it directly
                LoadInvoiceOntoGrid(0);
                load = 0;// Load the first (and only) invoice
            }
            else if (heldInvoiceDataList.Count > 1)
            {
                load = 1;

                // Multiple invoices, prompt user to select one
                using (var selectInvoiceForm = new SelectInvoiceForm(heldInvoiceDataList, capturedQuantitiesList))
                {
                    var result = selectInvoiceForm.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        int selectedInvoiceIndex = selectInvoiceForm.SelectedInvoiceIndex;
                        selectedinvoice = selectedInvoiceIndex;
                        LoadInvoiceOntoGrid(selectedInvoiceIndex);

                    }
                    // Handle DialogResult.Cancel if needed
                    Console.WriteLine("invoiceid " + invoice.InvoiceID.ToString());
                }
                load = 0;
            }
            else
            {
                load = 0;
                MessageBox.Show("No invoices to load.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void LoadInvoiceOntoGrid(int invoiceIndex)
        {
            DataTable invoiceData = heldInvoiceDataList[invoiceIndex];

            // Assuming dataGridViewSearchResults is your DataGridView control
            dataGridViewSearchResults.DataSource = invoiceData;

            // Populate the "Qty" column in dataGridViewSearchResults with values from capturedQuantitiesList
            for (int i = 0; i < dataGridViewSearchResults.Rows.Count; i++)
            {
                if (i < capturedQuantitiesList[invoiceIndex].Count)
                {
                    dataGridViewSearchResults.Rows[i].Cells["Qty"].Value = capturedQuantitiesList[invoiceIndex][i];
                }
                else
                {
                    dataGridViewSearchResults.Rows[i].Cells["Qty"].Value = DBNull.Value; // Or handle missing quantities as needed
                }
            }

            // Optionally, adjust DataGridView settings or perform additional operations
        }



        private void timer1_Tick(object sender, EventArgs e)
        {
            // Update the time in the label every second
            UpdateTime();
        }

        private void UpdateTime()
        {
            // Display the current time without seconds
            labeldate.Text = DateTime.Now.ToString("dddd, MMMM dd, yyyy  hh:mm tt"); // "tt" for AM/PM format
        }
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            string searchText = textBoxSearch.Text.Trim();
            if (!string.IsNullOrEmpty(searchText))
            {
                // Get the quantity from the text box
                int quantity = int.Parse(textBoxQuantity.Text.Trim());

                // Call your search logic to retrieve products (replace with your implementation)
                DataTable searchResults = productManager.SearchProducts(searchText, quantity); // Replace with your search logic

                if (searchResults != null && searchResults.Rows.Count > 0)
                {
                    // Show the result form if there are multiple search results
                    if (searchResults.Rows.Count > 1)
                    {
                        SshowResultForm(searchResults);
                    }
                    else
                    {
                        // Handle single match or partial match with existing item

                        // Check if any existing row matches the search text partially
                        bool partialMatchFound = false;
                        foreach (DataGridViewRow existingRow in dataGridViewSearchResults.Rows)
                        {
                            if (!existingRow.IsNewRow && existingRow.Cells["Name"].Value.ToString().Contains(searchText))
                            {
                                int existingQty = int.Parse(existingRow.Cells["qty"].Value.ToString());
                                existingRow.Cells["qty"].Value = existingQty + quantity;
                                partialMatchFound = true;
                                break;
                            }

                        }

                        if (!partialMatchFound)
                        {
                            // Set the DataSource directly if it's null, otherwise merge with existing data
                            if (dataGridViewSearchResults.DataSource == null)
                            {
                                dataGridViewSearchResults.DataSource = searchResults;
                                invoice = new invoice();
                            }
                            else
                            {
                                ((DataTable)dataGridViewSearchResults.DataSource).Merge(searchResults);
                            }

                            // Handle existing rows and new rows
                            foreach (DataGridViewRow row in dataGridViewSearchResults.Rows)
                            {
                                if (!row.IsNewRow)
                                {
                                    int rowIndex = row.Index;
                                    if (rowQuantities.ContainsKey(rowIndex))
                                    {
                                        row.Cells["qty"].Value = rowQuantities[rowIndex];
                                    }
                                }
                                else
                                {
                                    int rowIndex = row.Index;
                                    rowQuantities[rowIndex] = quantity;
                                    row.Cells["qty"].Value = quantity;
                                }
                            }

                            // Remove entries from rowQuantities for rows that are no longer present
                            List<int> keysToRemove = new List<int>();
                            foreach (int key in rowQuantities.Keys.ToList())
                            {
                                if (!dataGridViewSearchResults.Rows.Cast<DataGridViewRow>().Any(r => r.Index == key))
                                {
                                    keysToRemove.Add(key);
                                }
                            }
                            foreach (int key in keysToRemove)
                            {
                                rowQuantities.Remove(key);
                            }

                            dataGridViewSearchResults.Refresh();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No records found.", "Search", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Please enter a search query.", "Search", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            DisplayTotalPrice();
        }



        private void dataGridViewSearchResults_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the changed cell is in the quantity column
            if (e.ColumnIndex == dataGridViewSearchResults.Columns["qty"].Index && e.RowIndex >= 0)
            {
                // Get the new quantity value
                int newQuantity;
                if (int.TryParse(dataGridViewSearchResults.Rows[e.RowIndex].Cells["qty"].Value.ToString(), out newQuantity))
                {
                    int rowIndex = e.RowIndex;
                    string productName = dataGridViewSearchResults.Rows[rowIndex].Cells["Name"].Value.ToString();
                    int availableStock = productManager.GetAvailableStockForProduct(productName); // Call the method from your productManager instance

                    if (newQuantity > availableStock)
                    {
                        // Warn the user
                        MessageBox.Show("Quantity exceeds available stock for this product.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        // Revert the quantity back to its previous value
                        dataGridViewSearchResults.Rows[e.RowIndex].Cells["qty"].Value = rowQuantities[rowIndex];
                    }
                    else
                    {
                        // Update the quantity in the dictionary
                        rowQuantities[rowIndex] = newQuantity;
                        // Recalculate total price
                        DisplayTotalPrice();
                    }
                }
                else
                {
                    // Handle invalid input
                    MessageBox.Show("Invalid quantity value.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    // Reset the quantity cell to its previous value
                    dataGridViewSearchResults.Rows[e.RowIndex].Cells["qty"].Value = rowQuantities[e.RowIndex];
                }
            }
        }


        private void dataGridViewSearchResults_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (load == 0)
            {
                // Loop through each newly added row
                foreach (DataGridViewRow row in dataGridViewSearchResults.Rows)
                {
                    int rowIndex = row.Index;
                    if (!rowQuantities.ContainsKey(rowIndex))
                    {
                        int quantity = int.Parse(textBoxQuantity.Text.Trim());
                        rowQuantities[rowIndex] = quantity;
                        row.Cells["qty"].Value = quantity;
                    }
                }
            }
        }









        private void SshowResultForm(DataTable searchResults)
        {
            int quantity;
            if (!int.TryParse(textBoxQuantity.Text.Trim(), out quantity))
            {
                MessageBox.Show("Invalid quantity value.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Ensure "qty" column exists in searchResults DataTable
            if (!searchResults.Columns.Contains("qty"))
            {
                searchResults.Columns.Add("qty", typeof(int));
            }

            ResultForm resultForm = new ResultForm(searchResults, quantity);
            if (resultForm.ShowDialog() == DialogResult.OK)
            {
                DataRow selectedRow = resultForm.SelectedRow;
                if (selectedRow != null)
                {
                    // Check if the "qty" column exists in the selectedRow DataTable
                    if (!selectedRow.Table.Columns.Contains("qty"))
                    {
                        selectedRow.Table.Columns.Add("qty", typeof(int));
                    }

                    // Set the quantity to the value obtained from textBoxQuantity
                    selectedRow["qty"] = quantity;

                    // Check if the product already exists in dataGridViewSearchResults
                    bool productExists = dataGridViewSearchResults.Rows.Cast<DataGridViewRow>()
                                            .Any(row => !row.IsNewRow &&
                                                        row.Cells["ProductId"].Value.ToString() == selectedRow["ProductId"].ToString());

                    if (productExists)
                    {
                        // Update existing row's quantity
                        DataGridViewRow existingRow = dataGridViewSearchResults.Rows.Cast<DataGridViewRow>()
                                                        .FirstOrDefault(row => !row.IsNewRow &&
                                                                            row.Cells["ProductId"].Value.ToString() == selectedRow["ProductId"].ToString());
                        if (existingRow != null)
                        {
                            int existingQty = (int)existingRow.Cells["qty"].Value;
                            existingRow.Cells["qty"].Value = existingQty + quantity;
                        }
                    }
                    else
                    {
                        // Add new row to dataGridViewSearchResults
                        DataTable existingResults = dataGridViewSearchResults.DataSource as DataTable;
                        if (existingResults != null)
                        {
                            DataRow newRow = existingResults.NewRow();
                            newRow.ItemArray = selectedRow.ItemArray;
                            selectedRow["qty"] = quantity;
                            existingResults.Rows.Add(newRow);
                        }
                        else
                        {
                            DataTable newTable = selectedRow.Table.Clone();
                            selectedRow["qty"] = quantity;
                            newTable.Rows.Add(selectedRow.ItemArray);
                            dataGridViewSearchResults.DataSource = newTable;
                        }
                    }
                }
            }
        }



        private void buttonDelete_Click_1(object sender, EventArgs e)
        {
            // Check if a row is selected
            if (dataGridViewSearchResults.SelectedRows.Count > 0)
            {
                // Get the selected product's index
                int rowIndex = dataGridViewSearchResults.SelectedRows[0].Index;

                // Remove the selected row from the DataGridView
                dataGridViewSearchResults.Rows.RemoveAt(rowIndex);

                // Remove the corresponding entry from the rowQuantities dictionary
                rowQuantities.Remove(rowIndex);
                if (dataGridViewSearchResults==null & invoice.InvoiceID != 0)
                {
                    invoice.InvoiceID--;
                }
            }
            else
            {
                MessageBox.Show("Please select a product to delete.", "Delete Product", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            DisplayTotalPrice();
        }

        private void DisplayTotalPrice()
        {
            decimal totalPrice = 0;

            // Loop through each row in the DataGridView
            foreach (DataGridViewRow row in dataGridViewSearchResults.Rows)
            {
                // Check if the row is not a new row and the price and quantity columns are not null
                if (!row.IsNewRow && row.Cells["Price"].Value != null && row.Cells["qty"].Value != null)
                {
                    // Parse the price and quantity values and add them to the total price
                    decimal price = Convert.ToDecimal(row.Cells["Price"].Value);
                    int quantity = Convert.ToInt32(row.Cells["qty"].Value);
                    totalPrice += price * quantity;
                }
            }

            // Display the total price in a label
            labelTotalPrice.Text = totalPrice.ToString("C");
        }
        private decimal totalamount()
        {


            decimal totalPrice = 0;
            if (invoice.discounted)
            {
                totalPrice= Convert.ToDecimal(labelTotalPrice.Text);
            }
            else { 
            // Loop through each row in the DataGridView
            foreach (DataGridViewRow row in dataGridViewSearchResults.Rows)
            {
                // Check if the row is not a new row and the price and quantity columns are not null
                if (!row.IsNewRow && row.Cells["Price"].Value != null && row.Cells["qty"].Value != null)
                {
                    // Parse the price and quantity values and add them to the total price
                    decimal price = Convert.ToDecimal(row.Cells["Price"].Value);
                    int quantity = Convert.ToInt32(row.Cells["qty"].Value);
                    totalPrice += price * quantity;
                }
            }
        }
            // Display the total price in a label
            return totalPrice;
        }

        private List<SaleItem> GetSaleItemsFromGrid()
        {
            List<SaleItem> items = new List<SaleItem>();

            foreach (DataGridViewRow row in dataGridViewSearchResults.Rows)
            {
                if (!row.IsNewRow)
                {
                    int productId = (int)row.Cells["ProductID"].Value;
                    int quantity = Convert.ToInt32(row.Cells["qty"].Value);
                    decimal subtotal = Convert.ToDecimal((row.Cells["Price"].Value));
                    subtotal=subtotal * quantity;

                    items.Add(new SaleItem { ProductID = productId, Quantity = quantity, Subtotal = subtotal });
                }
            }

            return items;
        }
        private List<SaleItem1> GetSaleItemsFromGrid1()
        {
            List<SaleItem1> items = new List<SaleItem1>();

            foreach (DataGridViewRow row in dataGridViewSearchResults.Rows)
            {
                if (!row.IsNewRow)
                {
                    int productId = (int)row.Cells["ProductID"].Value;
                    int quantity = Convert.ToInt32(row.Cells["qty"].Value);
                    decimal subtotal = Convert.ToDecimal((row.Cells["Price"].Value));
                    subtotal=subtotal * quantity;

                    items.Add(new SaleItem1 { ProductID = productId, Quantity = quantity, Subtotal = subtotal });
                }
            }

            return items;
        }
        private void buttonSell_Click_1(object sender, EventArgs e)
        {

            if (dataGridViewSearchResults.Rows.Count > 0)
            {
                // Confirmation dialog for user verification
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to sell all items listed?", "Sell Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dialogResult == DialogResult.Yes)
                {


                        DateTime saleDate = DateTime.Now;
                    
                    salesmaager salemanager = new salesmaager(labelusername.Text, saleDate,totalamount(),GetSaleItemsFromGrid());
                    salesmaager1 salemanager1 = new salesmaager1(labelusername.Text, saleDate, totalamount(), GetSaleItemsFromGrid1());
                    invoice.InvoiceID++;
                    Console.WriteLine(invoice.InvoiceID);
                    // Loop through each row

                    foreach (DataGridViewRow row in dataGridViewSearchResults.Rows)
                    {
                        // Check if the row is not a new row
                        if (!row.IsNewRow)
                        {
                            int productId = (int)row.Cells["ProductID"].Value;
                            int quantitySold = Convert.ToInt32(row.Cells["qty"].Value);

                            // Decrease product quantity in the database
                            if (!productManager.DecrementProductQuantity(productId, quantitySold))
                            {
                                // Handle decrement failure (e.g., insufficient stock)
                                MessageBox.Show($"Failed to update quantity for product with ID: {productId}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return; // Exit the method if any product fails to sell
                            }
                        }
                    }

                    if (dataGridViewSearchResults.Columns.Count > 7)
                    {
                        capturedQuantitiesList.RemoveAt(selectedinvoice);
                        heldInvoiceDataList.RemoveAt(selectedinvoice);
                    }
                    if (invoice.discounted)
                    {
                        invoice.discounted = false;
                    }

                    if (print)
                    {
                        GenerateReceipt();
                    }

                    // All products sold successfully
                    ((DataTable)dataGridViewSearchResults.DataSource).Rows.Clear(); // Clear all rows from the DataGridView
                    DisplayTotalPrice();
                    rowQuantities.Clear();
                    DisplaySalesHistory();
                    totalSalesCount = salesHistoryTable.Rows.Count;
                    labelCount.Text = totalSalesCount.ToString();
                    // Update total price after changes
                    // Reset to default quantity after each sale

                }

            }
            else
            {
                MessageBox.Show("No items to sell.", "Sell", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        private List<string> receiptLines; // List to store all lines to print

        private void GenerateReceipt()
        {
            // Prepare receipt content
            receiptLines = new List<string>();

            receiptLines.Add("       Nassour");
            receiptLines.Add("----------------------");
            receiptLines.Add($"Date: {DateTime.Now}");
            receiptLines.Add($"{"Product",-20} {"Quantity",10} {"Total",12}");

            // Iterate through items in the DataGridView
            foreach (DataGridViewRow row in dataGridViewSearchResults.Rows)
            {
                if (!row.IsNewRow)
                {
                   
                    string productName = row.Cells["Name"].Value.ToString();
                    int quantity = Convert.ToInt32(row.Cells["qty"].Value);
                    decimal price = Convert.ToDecimal(row.Cells["Price"].Value);
                    decimal totalitem = quantity * price;
                   
                    receiptLines.Add($"{productName}     {quantity}    {totalitem:C}");
                   
                }
            }

            // Add total amount
          
            receiptLines.Add("----------------------");
            receiptLines.Add($"Total Amount: {totalamount():C}");
            receiptLines.Add($"Cashier {labelusername.Text}");

            // Create PrintDocument and PrintDialog objects
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(pd_PrintPage);

            // Display print dialog (optional)
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = pd;

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                pd.Print(); // Print the document
            }
        }

        private void pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            int linesPerPage = 0;
            int yPos = 0;
            int count = 0;
            float leftMargin = e.MarginBounds.Left;
            float topMargin = e.MarginBounds.Top;
            string line = null;
            Font printFont = new Font("Arial", 10);

            // Calculate the number of lines per page.
            linesPerPage = (int)(e.MarginBounds.Height / printFont.GetHeight(e.Graphics));

            // Iterate over the receiptLines list and print each line
            while (count < linesPerPage && receiptLines.Count > 0)
            {
                line = receiptLines[0];
                yPos = (int)((int)topMargin + (count * printFont.GetHeight(e.Graphics)));
                e.Graphics.DrawString(line, printFont, Brushes.Black, leftMargin, yPos, new StringFormat());
                Console.WriteLine(line);
                count++;
                receiptLines.RemoveAt(0);
            }

            // If more lines exist, print another page
            if (receiptLines.Count > 0)
            {
                e.HasMorePages = true;
            }
            else
            {
                e.HasMorePages = false;
            }
        }

        private void dataGridViewSearchResults_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (dataGridViewSearchResults.Columns[e.ColumnIndex].Name != "qty")
            {
                e.Cancel = true; // Cancel the edit operation
            }
        }
        private void DisplaySalesHistory()
        {
            salesHistoryTable = productManager.GetSalesHistory();

            if (salesHistoryTable != null && salesHistoryTable.Rows.Count > 0)
            {
                // Display the first sale initially
                DisplaySaleDetails(currentRowIndex);
            }
            else
            {
                // Handle case where no sales data is available
                MessageBox.Show("No sales data available.", "Sales History", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void DisplaySaleDetails(int rowIndex)
        {
            if (rowIndex >= 0 && rowIndex < salesHistoryTable.Rows.Count)
            {
                DataRow saleRow = salesHistoryTable.Rows[rowIndex];

                // Retrieve UserID (handle potential non-integer format)
                int userID;
                if (int.TryParse(saleRow["UserID"].ToString(), out userID))
                {
                    labelUserID.Text = saleRow["UserID"].ToString();

                    // Display user name using a parameterized query
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        string query = "SELECT Username FROM Users WHERE UserID = @UserID";
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@UserID", userID);

                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    labelUserID.Text = reader["Username"].ToString(); // Assuming "UserName" is the correct column name
                                }
                                else
                                {
                                    labelUserID.Text = "User not found"; // Handle case where user ID doesn't exist
                                }
                            }
                        }
                    }
                }
                else
                {
                    labelUserID.Text = saleRow["UserID"].ToString(); // Display raw UserID if parsing fails
                                                                     // Consider adding a message about invalid UserID format
                }

                labelSaleDate.Text = saleRow["SaleDate"].ToString();
                labelTotalAmount.Text = saleRow["TotalAmount"].ToString();
                labelCount.Text = totalSalesCount.ToString();

                // Display sale items
                DisplaySaleItems(Convert.ToInt32(saleRow["SaleID"]));
            }
        }

        private void DisplaySaleItems(int saleID)
        {
            // Query to fetch sale items for the specified saleID
            string query = "SELECT ProductID, Quantity, Subtotal " +
                           "FROM todaySaleItems " +
                           "WHERE SaleID = @SaleID;";

            DataTable saleItemsTable = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@SaleID", saleID);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(saleItemsTable);
                        }
                    }
                }
                // Display sale items in dataGridViewSaleItems
                dataGridViewSaleItems.DataSource = saleItemsTable;
            }
            catch (Exception ex)
            {
                // Handle exceptions here
                Console.WriteLine("Error retrieving sale items: " + ex.Message);
            }
        }

        private void buttonPrevious_Click(object sender, EventArgs e)
        {
            if (currentRowIndex > 0)
            {
                currentRowIndex--;

                totalSalesCount++;
                DisplaySaleDetails(currentRowIndex);
            }
        }
        private void buttonNext_Click(object sender, EventArgs e)
        {
            if (currentRowIndex < salesHistoryTable.Rows.Count - 1)
            {
                totalSalesCount--;
                currentRowIndex++;
                DisplaySaleDetails(currentRowIndex);
            }
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            if (print)
            {
                print = false;
                buttonPrint.Text= "print \n off";
            }
            else
            {
                print = true;
                buttonPrint.Text = "print \n on";
            }
        }

        private void buttonOut_Click(object sender, EventArgs e)
        {
            loginForm loginForm = new loginForm();
            loginForm.Show();
            this.Hide();
        }
    }
}
