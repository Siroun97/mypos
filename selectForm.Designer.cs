using System;

namespace mypos
{
    partial class SelectInvoiceForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.comboBoxInvoices = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBoxInvoices
            // 
            this.comboBoxInvoices.FormattingEnabled = true;
            this.comboBoxInvoices.Location = new System.Drawing.Point(190, 73);
            this.comboBoxInvoices.Name = "comboBoxInvoices";
            this.comboBoxInvoices.Size = new System.Drawing.Size(400, 21);
            this.comboBoxInvoices.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(493, 249);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // SelectInvoiceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBoxInvoices);
            this.Name = "SelectInvoiceForm";
            this.Text = "selectForm";
            this.Load += new System.EventHandler(this.selectForm_Load);
            this.ResumeLayout(false);

        }

        private void selectForm_Load(object sender, EventArgs e)
        {
            
        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxInvoices;
        private System.Windows.Forms.Button button1;
    }
}