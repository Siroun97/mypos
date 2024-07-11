using System;
using System.Data;
using System.Windows.Forms;

namespace SimplePOS
{
    public partial class ResultForm : Form
    {
        private DataTable searchResults; // Store searchResults as a class-level variable
        private DataRow selectedRow;
        private int quantity;

        public ResultForm(DataTable searchResults,int quantity)
        {

            InitializeComponent();
            this.quantity = quantity;
            this.searchResults = searchResults; // Store the searchResults DataTable
            ConfigureDataGridViewColumns();
            PopulateDataGridView();
        }

        private void ConfigureDataGridViewColumns()
        {
            dataGridViewSearchResults.AutoGenerateColumns = false; // Disable auto generation of columns
            dataGridViewSearchResults.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Allow full row selection
           
            // Add columns manually based on DataTable columns
            searchResults.Columns.Remove("Quantity");

            foreach (DataColumn column in searchResults.Columns)
            {
                dataGridViewSearchResults.Columns.Add(column.ColumnName, column.ColumnName);
            }

        }

        private void PopulateDataGridView()
        {
            // Add rows to DataGridView
            foreach (DataRow row in searchResults.Rows)
            {
                dataGridViewSearchResults.Rows.Add(row.ItemArray);
                Console.WriteLine("Row added to DataGridView: " + string.Join(", ", row.ItemArray));

            }
        }

        private void dataGridViewSearchResults_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Ensure there is at least one selected row
                if (dataGridViewSearchResults.SelectedRows.Count > 0)
                {
                    // Get the selected row
                    DataGridViewRow selectedRow = dataGridViewSearchResults.SelectedRows[0];

                    // Create a new DataRow and populate it with the cell values from the selected row
                    DataRow row = searchResults.NewRow();
                    for (int i = 0; i < dataGridViewSearchResults.Columns.Count; i++)
                    {
                        row[i] = selectedRow.Cells[i].Value;
                    }

                    // Set the selected row
                    this.selectedRow = row;

                    // Set DialogResult to OK and close the form
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    // Handle the case where there are no selected rows
                    MessageBox.Show("No row selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Property to access the selected row
        public DataRow SelectedRow
        {
            get { return selectedRow; }
        }
    }
}
