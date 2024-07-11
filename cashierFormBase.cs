using System;
using System.Windows.Forms;

namespace mypos
{
    internal class cashierFormBase : Form
    {
        // Constructor
        public cashierFormBase()
        {
            InitializeComponent();
        }

        // Method to initialize components
        private void InitializeComponent()
        {
            // Initialize any controls or components here if needed
            // Example:
            // this.SuspendLayout();
            // this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            // this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            // this.ClientSize = new System.Drawing.Size(800, 450);
            // this.Name = "cashierFormBase";
            // this.Text = "Cashier Form";
            // this.ResumeLayout(false);
        }

        // Clean up any resources being used.
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                // Dispose of your own resources if any
                // Example:
                // Dispose of controls or other resources
                // this.myControl.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}
