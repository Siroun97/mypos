using System;
using System.Windows.Forms;

namespace SimplePOS
{
    partial class cashierForm : Form
    {
        private System.ComponentModel.IContainer components = null;

       

        private DataGridView dataGridViewSearchResults;
        private TextBox textBoxSearch;
        private Button buttonSearch;

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataGridViewSearchResults = new System.Windows.Forms.DataGridView();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.labelTotalPrice = new System.Windows.Forms.Label();
            this.buttonSell = new System.Windows.Forms.Button();
            this.textBoxQuantity = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labeldate = new System.Windows.Forms.Label();
            this.labeld = new System.Windows.Forms.Label();
            this.labelusername = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.labelCount = new System.Windows.Forms.Label();
            this.labelUserID = new System.Windows.Forms.Label();
            this.labelSaleDate = new System.Windows.Forms.Label();
            this.labelTotalAmount = new System.Windows.Forms.Label();
            this.dataGridViewSaleItems = new System.Windows.Forms.DataGridView();
            this.buttonPrevious = new System.Windows.Forms.Button();
            this.buttonNext = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonPrint = new System.Windows.Forms.Button();
            this.buttonOut = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSearchResults)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSaleItems)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewSearchResults
            // 
            this.dataGridViewSearchResults.AccessibleName = "dataGridViewSearchResults";
            this.dataGridViewSearchResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSearchResults.Dock = System.Windows.Forms.DockStyle.Left;
            this.dataGridViewSearchResults.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewSearchResults.Name = "dataGridViewSearchResults";
            this.dataGridViewSearchResults.Size = new System.Drawing.Size(602, 749);
            this.dataGridViewSearchResults.TabIndex = 0;
            this.dataGridViewSearchResults.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridViewSearchResults_CellBeginEdit);
            this.dataGridViewSearchResults.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewSearchResults_CellValueChanged);
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Location = new System.Drawing.Point(1050, 59);
            this.textBoxSearch.Multiline = true;
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(308, 44);
            this.textBoxSearch.TabIndex = 1;
            this.textBoxSearch.TextChanged += new System.EventHandler(this.textBoxSearch_TextChanged);
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(859, 59);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(75, 44);
            this.buttonSearch.TabIndex = 2;
            this.buttonSearch.Text = "Search";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.BackColor = System.Drawing.Color.Brown;
            this.buttonDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDelete.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonDelete.Location = new System.Drawing.Point(1040, 350);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(117, 60);
            this.buttonDelete.TabIndex = 3;
            this.buttonDelete.Text = "delete";
            this.buttonDelete.UseVisualStyleBackColor = false;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click_1);
            // 
            // labelTotalPrice
            // 
            this.labelTotalPrice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.labelTotalPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotalPrice.Location = new System.Drawing.Point(1042, 425);
            this.labelTotalPrice.Name = "labelTotalPrice";
            this.labelTotalPrice.Size = new System.Drawing.Size(328, 103);
            this.labelTotalPrice.TabIndex = 4;
            this.labelTotalPrice.Text = "0";
            this.labelTotalPrice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonSell
            // 
            this.buttonSell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.buttonSell.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSell.Location = new System.Drawing.Point(1040, 531);
            this.buttonSell.Name = "buttonSell";
            this.buttonSell.Size = new System.Drawing.Size(330, 218);
            this.buttonSell.TabIndex = 5;
            this.buttonSell.Text = "Sell";
            this.buttonSell.UseVisualStyleBackColor = false;
            this.buttonSell.Click += new System.EventHandler(this.buttonSell_Click_1);
            // 
            // textBoxQuantity
            // 
            this.textBoxQuantity.Location = new System.Drawing.Point(959, 59);
            this.textBoxQuantity.Multiline = true;
            this.textBoxQuantity.Name = "textBoxQuantity";
            this.textBoxQuantity.Size = new System.Drawing.Size(71, 44);
            this.textBoxQuantity.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Leelawadee UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(33, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "username: ";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkGray;
            this.panel1.Controls.Add(this.buttonOut);
            this.panel1.Controls.Add(this.labeldate);
            this.panel1.Controls.Add(this.labeld);
            this.panel1.Controls.Add(this.labelusername);
            this.panel1.Controls.Add(this.label1);
            this.panel1.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel1.Location = new System.Drawing.Point(600, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(770, 38);
            this.panel1.TabIndex = 8;
            // 
            // labeldate
            // 
            this.labeldate.AutoSize = true;
            this.labeldate.Font = new System.Drawing.Font("Leelawadee UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labeldate.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labeldate.Location = new System.Drawing.Point(217, 9);
            this.labeldate.Name = "labeldate";
            this.labeldate.Size = new System.Drawing.Size(63, 13);
            this.labeldate.TabIndex = 10;
            this.labeldate.Text = "username: ";
            // 
            // labeld
            // 
            this.labeld.AutoSize = true;
            this.labeld.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labeld.Location = new System.Drawing.Point(180, 9);
            this.labeld.Name = "labeld";
            this.labeld.Size = new System.Drawing.Size(31, 13);
            this.labeld.TabIndex = 9;
            this.labeld.Text = "date:";
            // 
            // labelusername
            // 
            this.labelusername.AutoSize = true;
            this.labelusername.Font = new System.Drawing.Font("Leelawadee UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelusername.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelusername.Location = new System.Drawing.Point(87, 9);
            this.labelusername.Name = "labelusername";
            this.labelusername.Size = new System.Drawing.Size(63, 13);
            this.labelusername.TabIndex = 8;
            this.labelusername.Text = "username: ";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // labelCount
            // 
            this.labelCount.AutoSize = true;
            this.labelCount.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.labelCount.Location = new System.Drawing.Point(657, 640);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(35, 13);
            this.labelCount.TabIndex = 9;
            this.labelCount.Text = "label2";
            // 
            // labelUserID
            // 
            this.labelUserID.AutoSize = true;
            this.labelUserID.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.labelUserID.Location = new System.Drawing.Point(751, 640);
            this.labelUserID.Name = "labelUserID";
            this.labelUserID.Size = new System.Drawing.Size(35, 13);
            this.labelUserID.TabIndex = 10;
            this.labelUserID.Text = "label3";
            // 
            // labelSaleDate
            // 
            this.labelSaleDate.AutoSize = true;
            this.labelSaleDate.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.labelSaleDate.Location = new System.Drawing.Point(845, 640);
            this.labelSaleDate.Name = "labelSaleDate";
            this.labelSaleDate.Size = new System.Drawing.Size(35, 13);
            this.labelSaleDate.TabIndex = 11;
            this.labelSaleDate.Text = "label4";
            // 
            // labelTotalAmount
            // 
            this.labelTotalAmount.AutoSize = true;
            this.labelTotalAmount.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.labelTotalAmount.Location = new System.Drawing.Point(988, 640);
            this.labelTotalAmount.Name = "labelTotalAmount";
            this.labelTotalAmount.Size = new System.Drawing.Size(35, 13);
            this.labelTotalAmount.TabIndex = 12;
            this.labelTotalAmount.Text = "label5";
            // 
            // dataGridViewSaleItems
            // 
            this.dataGridViewSaleItems.AccessibleName = "dataGridViewSaleItems";
            this.dataGridViewSaleItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSaleItems.Location = new System.Drawing.Point(617, 425);
            this.dataGridViewSaleItems.Name = "dataGridViewSaleItems";
            this.dataGridViewSaleItems.Size = new System.Drawing.Size(413, 200);
            this.dataGridViewSaleItems.TabIndex = 13;
            // 
            // buttonPrevious
            // 
            this.buttonPrevious.Location = new System.Drawing.Point(955, 670);
            this.buttonPrevious.Name = "buttonPrevious";
            this.buttonPrevious.Size = new System.Drawing.Size(75, 34);
            this.buttonPrevious.TabIndex = 14;
            this.buttonPrevious.Text = "next";
            this.buttonPrevious.UseVisualStyleBackColor = true;
            this.buttonPrevious.Click += new System.EventHandler(this.buttonPrevious_Click);
            // 
            // buttonNext
            // 
            this.buttonNext.Location = new System.Drawing.Point(617, 670);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(75, 34);
            this.buttonNext.TabIndex = 15;
            this.buttonNext.Text = "previous";
            this.buttonNext.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.label2.Location = new System.Drawing.Point(622, 640);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "count:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.label3.Location = new System.Drawing.Point(710, 640);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "cashier:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.label4.Location = new System.Drawing.Point(817, 640);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "date:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.label5.Location = new System.Drawing.Point(952, 640);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "total:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel2.Location = new System.Drawing.Point(617, 632);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(413, 32);
            this.panel2.TabIndex = 20;
            // 
            // buttonPrint
            // 
            this.buttonPrint.BackColor = System.Drawing.Color.LimeGreen;
            this.buttonPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPrint.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonPrint.Location = new System.Drawing.Point(1241, 350);
            this.buttonPrint.Name = "buttonPrint";
            this.buttonPrint.Size = new System.Drawing.Size(117, 60);
            this.buttonPrint.TabIndex = 21;
            this.buttonPrint.Text = "print\r\n   off";
            this.buttonPrint.UseVisualStyleBackColor = false;
            this.buttonPrint.Click += new System.EventHandler(this.buttonPrint_Click);
            // 
            // buttonOut
            // 
            this.buttonOut.BackColor = System.Drawing.Color.Firebrick;
            this.buttonOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonOut.Location = new System.Drawing.Point(733, 3);
            this.buttonOut.Name = "buttonOut";
            this.buttonOut.Size = new System.Drawing.Size(34, 33);
            this.buttonOut.TabIndex = 22;
            this.buttonOut.TabStop = false;
            this.buttonOut.Text = "X";
            this.buttonOut.UseVisualStyleBackColor = false;
            this.buttonOut.Click += new System.EventHandler(this.buttonOut_Click);
            // 
            // cashierForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1370, 749);
            this.Controls.Add(this.buttonPrint);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonNext);
            this.Controls.Add(this.buttonPrevious);
            this.Controls.Add(this.dataGridViewSaleItems);
            this.Controls.Add(this.labelTotalAmount);
            this.Controls.Add(this.labelSaleDate);
            this.Controls.Add(this.labelUserID);
            this.Controls.Add(this.labelCount);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.textBoxQuantity);
            this.Controls.Add(this.buttonSell);
            this.Controls.Add(this.labelTotalPrice);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.textBoxSearch);
            this.Controls.Add(this.dataGridViewSearchResults);
            this.Controls.Add(this.panel2);
            this.KeyPreview = true;
            this.Name = "cashierForm";
            this.Text = "Cashier Form";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cashierForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSearchResults)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSaleItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
           // throw new NotImplementedException();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private Button buttonDelete;
        private Label labelTotalPrice;
        private Button buttonSell;
        private TextBox textBoxQuantity;
        private Label label1;
        private Panel panel1;
        private Label labelusername;
        private Label labeldate;
        private Label labeld;
        private Timer timer1;
        private Label labelCount;
        private Label labelUserID;
        private Label labelSaleDate;
        private Label labelTotalAmount;
        private DataGridView dataGridViewSaleItems;
        private Button buttonPrevious;
        private Button buttonNext;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Panel panel2;
        private Button buttonPrint;
        private Button buttonOut;
    }
}
