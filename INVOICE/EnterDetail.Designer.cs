namespace INVOICE
{
    partial class EnterDetail
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TextBox_InvoiceNo = new System.Windows.Forms.TextBox();
            this.TextBox_Address1 = new System.Windows.Forms.TextBox();
            this.TextBox_Address2 = new System.Windows.Forms.TextBox();
            this.DateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.TextBox_Address3 = new System.Windows.Forms.TextBox();
            this.TextBox_ContactNo = new System.Windows.Forms.TextBox();
            this.Button_Next = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.TextBox_Note = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Invoice No :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tanggal :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(286, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Kepada :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(284, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Telepon :";
            // 
            // TextBox_InvoiceNo
            // 
            this.TextBox_InvoiceNo.Location = new System.Drawing.Point(83, 12);
            this.TextBox_InvoiceNo.Name = "TextBox_InvoiceNo";
            this.TextBox_InvoiceNo.Size = new System.Drawing.Size(150, 20);
            this.TextBox_InvoiceNo.TabIndex = 0;
            // 
            // TextBox_Address1
            // 
            this.TextBox_Address1.Location = new System.Drawing.Point(342, 12);
            this.TextBox_Address1.Name = "TextBox_Address1";
            this.TextBox_Address1.Size = new System.Drawing.Size(150, 20);
            this.TextBox_Address1.TabIndex = 2;
            // 
            // TextBox_Address2
            // 
            this.TextBox_Address2.Location = new System.Drawing.Point(342, 38);
            this.TextBox_Address2.Name = "TextBox_Address2";
            this.TextBox_Address2.Size = new System.Drawing.Size(150, 20);
            this.TextBox_Address2.TabIndex = 3;
            // 
            // DateTimePicker
            // 
            this.DateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DateTimePicker.Location = new System.Drawing.Point(83, 38);
            this.DateTimePicker.MaxDate = new System.DateTime(3000, 12, 31, 0, 0, 0, 0);
            this.DateTimePicker.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.DateTimePicker.Name = "DateTimePicker";
            this.DateTimePicker.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.DateTimePicker.Size = new System.Drawing.Size(150, 20);
            this.DateTimePicker.TabIndex = 6;
            // 
            // TextBox_Address3
            // 
            this.TextBox_Address3.Location = new System.Drawing.Point(342, 65);
            this.TextBox_Address3.Name = "TextBox_Address3";
            this.TextBox_Address3.Size = new System.Drawing.Size(150, 20);
            this.TextBox_Address3.TabIndex = 4;
            // 
            // TextBox_ContactNo
            // 
            this.TextBox_ContactNo.Location = new System.Drawing.Point(342, 91);
            this.TextBox_ContactNo.Name = "TextBox_ContactNo";
            this.TextBox_ContactNo.Size = new System.Drawing.Size(150, 20);
            this.TextBox_ContactNo.TabIndex = 5;
            // 
            // Button_Next
            // 
            this.Button_Next.Location = new System.Drawing.Point(392, 117);
            this.Button_Next.Name = "Button_Next";
            this.Button_Next.Size = new System.Drawing.Size(100, 35);
            this.Button_Next.TabIndex = 8;
            this.Button_Next.Text = "Next >";
            this.Button_Next.UseVisualStyleBackColor = true;
            this.Button_Next.Click += new System.EventHandler(this.Button_Next_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Catatan :";
            // 
            // TextBox_Note
            // 
            this.TextBox_Note.Location = new System.Drawing.Point(83, 64);
            this.TextBox_Note.Multiline = true;
            this.TextBox_Note.Name = "TextBox_Note";
            this.TextBox_Note.Size = new System.Drawing.Size(150, 88);
            this.TextBox_Note.TabIndex = 7;
            // 
            // EnterDetail
            // 
            this.AcceptButton = this.Button_Next;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 161);
            this.Controls.Add(this.TextBox_Note);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Button_Next);
            this.Controls.Add(this.TextBox_ContactNo);
            this.Controls.Add(this.TextBox_Address3);
            this.Controls.Add(this.DateTimePicker);
            this.Controls.Add(this.TextBox_Address2);
            this.Controls.Add(this.TextBox_Address1);
            this.Controls.Add(this.TextBox_InvoiceNo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EnterDetail";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Enter Detail";
            this.Load += new System.EventHandler(this.EnterDetail_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TextBox_InvoiceNo;
        private System.Windows.Forms.TextBox TextBox_Address1;
        private System.Windows.Forms.TextBox TextBox_Address2;
        private System.Windows.Forms.DateTimePicker DateTimePicker;
        private System.Windows.Forms.TextBox TextBox_Address3;
        private System.Windows.Forms.TextBox TextBox_ContactNo;
        private System.Windows.Forms.Button Button_Next;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TextBox_Note;
    }
}