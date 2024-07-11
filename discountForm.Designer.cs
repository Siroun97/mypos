namespace mypos
{
    partial class discountForm
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
            this.remise = new System.Windows.Forms.Button();
            this.dtprice = new System.Windows.Forms.Button();
            this.ten = new System.Windows.Forms.Button();
            this.fifty = new System.Windows.Forms.Button();
            this.ninty = new System.Windows.Forms.Button();
            this.twenty = new System.Windows.Forms.Button();
            this.thirty = new System.Windows.Forms.Button();
            this.fourty = new System.Windows.Forms.Button();
            this.sixty = new System.Windows.Forms.Button();
            this.seventy = new System.Windows.Forms.Button();
            this.eighty = new System.Windows.Forms.Button();
            this.textBoxDiscount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // remise
            // 
            this.remise.Location = new System.Drawing.Point(75, 102);
            this.remise.Name = "remise";
            this.remise.Size = new System.Drawing.Size(135, 60);
            this.remise.TabIndex = 0;
            this.remise.Text = "remise";
            this.remise.UseVisualStyleBackColor = true;
            this.remise.Click += new System.EventHandler(this.remise_Click);
            // 
            // dtprice
            // 
            this.dtprice.Location = new System.Drawing.Point(75, 233);
            this.dtprice.Name = "dtprice";
            this.dtprice.Size = new System.Drawing.Size(135, 60);
            this.dtprice.TabIndex = 1;
            this.dtprice.Text = "determine the price";
            this.dtprice.UseVisualStyleBackColor = true;
            this.dtprice.Click += new System.EventHandler(this.dtprice_Click);
            // 
            // ten
            // 
            this.ten.Location = new System.Drawing.Point(42, 63);
            this.ten.Name = "ten";
            this.ten.Size = new System.Drawing.Size(75, 23);
            this.ten.TabIndex = 2;
            this.ten.Text = "10 %";
            this.ten.UseVisualStyleBackColor = true;
            this.ten.Click += new System.EventHandler(this.ten_Click);
            // 
            // fifty
            // 
            this.fifty.Location = new System.Drawing.Point(42, 181);
            this.fifty.Name = "fifty";
            this.fifty.Size = new System.Drawing.Size(75, 23);
            this.fifty.TabIndex = 3;
            this.fifty.Text = "50 %";
            this.fifty.UseVisualStyleBackColor = true;
            this.fifty.Click += new System.EventHandler(this.fifty_Click);
            // 
            // ninty
            // 
            this.ninty.Location = new System.Drawing.Point(103, 299);
            this.ninty.Name = "ninty";
            this.ninty.Size = new System.Drawing.Size(75, 23);
            this.ninty.TabIndex = 4;
            this.ninty.Text = "90 %";
            this.ninty.UseVisualStyleBackColor = true;
            this.ninty.Click += new System.EventHandler(this.ninty_Click);
            // 
            // twenty
            // 
            this.twenty.Location = new System.Drawing.Point(171, 63);
            this.twenty.Name = "twenty";
            this.twenty.Size = new System.Drawing.Size(75, 23);
            this.twenty.TabIndex = 5;
            this.twenty.Text = "20 %";
            this.twenty.UseVisualStyleBackColor = true;
            this.twenty.Click += new System.EventHandler(this.twenty_Click);
            // 
            // thirty
            // 
            this.thirty.Location = new System.Drawing.Point(42, 121);
            this.thirty.Name = "thirty";
            this.thirty.Size = new System.Drawing.Size(75, 23);
            this.thirty.TabIndex = 6;
            this.thirty.Text = "30 %";
            this.thirty.UseVisualStyleBackColor = true;
            this.thirty.Click += new System.EventHandler(this.thirty_Click);
            // 
            // fourty
            // 
            this.fourty.Location = new System.Drawing.Point(171, 121);
            this.fourty.Name = "fourty";
            this.fourty.Size = new System.Drawing.Size(75, 23);
            this.fourty.TabIndex = 7;
            this.fourty.Text = "40 %";
            this.fourty.UseVisualStyleBackColor = true;
            this.fourty.Click += new System.EventHandler(this.fourty_Click);
            // 
            // sixty
            // 
            this.sixty.Location = new System.Drawing.Point(171, 181);
            this.sixty.Name = "sixty";
            this.sixty.Size = new System.Drawing.Size(75, 23);
            this.sixty.TabIndex = 8;
            this.sixty.Text = "60 %";
            this.sixty.UseVisualStyleBackColor = true;
            this.sixty.Click += new System.EventHandler(this.sixty_Click);
            // 
            // seventy
            // 
            this.seventy.Location = new System.Drawing.Point(42, 242);
            this.seventy.Name = "seventy";
            this.seventy.Size = new System.Drawing.Size(75, 23);
            this.seventy.TabIndex = 9;
            this.seventy.Text = "70 %";
            this.seventy.UseVisualStyleBackColor = true;
            this.seventy.Click += new System.EventHandler(this.seventy_Click);
            // 
            // eighty
            // 
            this.eighty.Location = new System.Drawing.Point(171, 242);
            this.eighty.Name = "eighty";
            this.eighty.Size = new System.Drawing.Size(75, 23);
            this.eighty.TabIndex = 10;
            this.eighty.Text = "80 %";
            this.eighty.UseVisualStyleBackColor = true;
            this.eighty.Click += new System.EventHandler(this.eighty_Click);
            // 
            // textBoxDiscount
            // 
            this.textBoxDiscount.Location = new System.Drawing.Point(75, 102);
            this.textBoxDiscount.Multiline = true;
            this.textBoxDiscount.Name = "textBoxDiscount";
            this.textBoxDiscount.Size = new System.Drawing.Size(135, 27);
            this.textBoxDiscount.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(72, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "enter the discounted price:";
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(103, 181);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 13;
            this.buttonOk.Text = "ok";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // discountForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(291, 450);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxDiscount);
            this.Controls.Add(this.eighty);
            this.Controls.Add(this.seventy);
            this.Controls.Add(this.sixty);
            this.Controls.Add(this.fourty);
            this.Controls.Add(this.thirty);
            this.Controls.Add(this.twenty);
            this.Controls.Add(this.ninty);
            this.Controls.Add(this.fifty);
            this.Controls.Add(this.ten);
            this.Controls.Add(this.dtprice);
            this.Controls.Add(this.remise);
            this.Name = "discountForm";
            this.Text = "discountForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button remise;
        private System.Windows.Forms.Button dtprice;
        private System.Windows.Forms.Button ten;
        private System.Windows.Forms.Button fifty;
        private System.Windows.Forms.Button ninty;
        private System.Windows.Forms.Button twenty;
        private System.Windows.Forms.Button thirty;
        private System.Windows.Forms.Button fourty;
        private System.Windows.Forms.Button sixty;
        private System.Windows.Forms.Button seventy;
        private System.Windows.Forms.Button eighty;
        private System.Windows.Forms.TextBox textBoxDiscount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonOk;
    }
}