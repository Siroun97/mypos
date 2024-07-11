using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace mypos
{
    public partial class SelectInvoiceForm : Form
    {
        public int SelectedInvoiceIndex { get; private set; }
        private List<DataTable> invoiceDataList;
        private List<List<int>> capturedQuantitiesList; // New field for captured quantities

        public SelectInvoiceForm(List<DataTable> invoiceDataList, List<List<int>> capturedQuantitiesList)
        {
            InitializeComponent();

            this.invoiceDataList = invoiceDataList;
            this.capturedQuantitiesList = capturedQuantitiesList; // Assign captured quantities list

            // Populate the combobox with invoice information
            for (int i = 0; i < invoiceDataList.Count; i++)
            {
                // Example: Display invoice number or other identifying information
                comboBoxInvoices.Items.Add($"Invoice {i + 1}");
            }
        }

       

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Validate selection
            if (comboBoxInvoices.SelectedIndex >= 0 && comboBoxInvoices.SelectedIndex < invoiceDataList.Count)
            {
                SelectedInvoiceIndex = comboBoxInvoices.SelectedIndex;

                // Example: Retrieve captured quantities for the selected invoice
                List<int> quantities = capturedQuantitiesList[SelectedInvoiceIndex];
                // Use quantities as needed

                DialogResult = DialogResult.OK;

                Close();
            }
            else
            {
                MessageBox.Show("Please select an invoice.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
