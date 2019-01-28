namespace INVOICE
{
    partial class Editor
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.DGV = new System.Windows.Forms.DataGridView();
            this.Item_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price_Each = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalBeforeDiscount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Discount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Button_Done = new System.Windows.Forms.Button();
            this.Button_Reset = new System.Windows.Forms.Button();
            this.Label_SubTotal = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TextBox_Discount = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TextBox_PPN = new System.Windows.Forms.TextBox();
            this.Label_GrandTotal = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DGV
            // 
            this.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Item_Name,
            this.Quantity,
            this.Unit,
            this.Price_Each,
            this.TotalBeforeDiscount,
            this.Discount,
            this.Total});
            this.DGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGV.Location = new System.Drawing.Point(0, 0);
            this.DGV.Name = "DGV";
            this.DGV.Size = new System.Drawing.Size(960, 314);
            this.DGV.TabIndex = 1;
            this.DGV.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_RowEnter);
            this.DGV.RowLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_RowLeave);
            // 
            // Item_Name
            // 
            dataGridViewCellStyle1.NullValue = "Item";
            this.Item_Name.DefaultCellStyle = dataGridViewCellStyle1;
            this.Item_Name.HeaderText = "Nama Barang";
            this.Item_Name.MinimumWidth = 100;
            this.Item_Name.Name = "Item_Name";
            this.Item_Name.Width = 200;
            // 
            // Quantity
            // 
            this.Quantity.HeaderText = "Jumlah";
            this.Quantity.Name = "Quantity";
            // 
            // Unit
            // 
            dataGridViewCellStyle2.NullValue = "Pcs";
            this.Unit.DefaultCellStyle = dataGridViewCellStyle2;
            this.Unit.HeaderText = "Satuan";
            this.Unit.Name = "Unit";
            // 
            // Price_Each
            // 
            this.Price_Each.HeaderText = "Harga @";
            this.Price_Each.Name = "Price_Each";
            this.Price_Each.ToolTipText = "Harga Satuan";
            // 
            // TotalBeforeDiscount
            // 
            this.TotalBeforeDiscount.HeaderText = "Harga";
            this.TotalBeforeDiscount.Name = "TotalBeforeDiscount";
            this.TotalBeforeDiscount.ReadOnly = true;
            // 
            // Discount
            // 
            this.Discount.HeaderText = "Discount";
            this.Discount.Name = "Discount";
            // 
            // Total
            // 
            this.Total.HeaderText = "Total Harga";
            this.Total.Name = "Total";
            this.Total.ReadOnly = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.DGV);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(960, 314);
            this.panel1.TabIndex = 1;
            // 
            // Button_Done
            // 
            this.Button_Done.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_Done.Location = new System.Drawing.Point(529, 355);
            this.Button_Done.Name = "Button_Done";
            this.Button_Done.Size = new System.Drawing.Size(100, 35);
            this.Button_Done.TabIndex = 4;
            this.Button_Done.Text = "Done";
            this.Button_Done.UseVisualStyleBackColor = true;
            this.Button_Done.Click += new System.EventHandler(this.Button_Done_Click);
            // 
            // Button_Reset
            // 
            this.Button_Reset.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_Reset.Location = new System.Drawing.Point(529, 396);
            this.Button_Reset.Name = "Button_Reset";
            this.Button_Reset.Size = new System.Drawing.Size(100, 35);
            this.Button_Reset.TabIndex = 5;
            this.Button_Reset.Text = "Reset";
            this.Button_Reset.UseVisualStyleBackColor = true;
            this.Button_Reset.Click += new System.EventHandler(this.Button_Reset_Click);
            // 
            // Label_SubTotal
            // 
            this.Label_SubTotal.AutoSize = true;
            this.Label_SubTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_SubTotal.Location = new System.Drawing.Point(174, 335);
            this.Label_SubTotal.Name = "Label_SubTotal";
            this.Label_SubTotal.Size = new System.Drawing.Size(85, 20);
            this.Label_SubTotal.TabIndex = 2;
            this.Label_SubTotal.Text = "Sub Total :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(174, 367);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Discount :";
            // 
            // TextBox_Discount
            // 
            this.TextBox_Discount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBox_Discount.Location = new System.Drawing.Point(287, 364);
            this.TextBox_Discount.Name = "TextBox_Discount";
            this.TextBox_Discount.Size = new System.Drawing.Size(150, 26);
            this.TextBox_Discount.TabIndex = 2;
            this.TextBox_Discount.Text = "0";
            this.TextBox_Discount.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TextBox_Discount_MouseClick);
            this.TextBox_Discount.Leave += new System.EventHandler(this.TextBox_Discount_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(174, 402);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "PPN :";
            // 
            // TextBox_PPN
            // 
            this.TextBox_PPN.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBox_PPN.Location = new System.Drawing.Point(287, 396);
            this.TextBox_PPN.Name = "TextBox_PPN";
            this.TextBox_PPN.Size = new System.Drawing.Size(150, 26);
            this.TextBox_PPN.TabIndex = 3;
            this.TextBox_PPN.Text = "0";
            this.TextBox_PPN.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TextBox_PPN_MouseClick);
            this.TextBox_PPN.Leave += new System.EventHandler(this.TextBox_PPN_Leave);
            // 
            // Label_GrandTotal
            // 
            this.Label_GrandTotal.AutoSize = true;
            this.Label_GrandTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_GrandTotal.Location = new System.Drawing.Point(174, 431);
            this.Label_GrandTotal.Name = "Label_GrandTotal";
            this.Label_GrandTotal.Size = new System.Drawing.Size(101, 20);
            this.Label_GrandTotal.TabIndex = 8;
            this.Label_GrandTotal.Text = "Grand Total :";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(35, 367);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Editor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 461);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Label_GrandTotal);
            this.Controls.Add(this.TextBox_PPN);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TextBox_Discount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Label_SubTotal);
            this.Controls.Add(this.Button_Reset);
            this.Controls.Add(this.Button_Done);
            this.Controls.Add(this.panel1);
            this.Name = "Editor";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Invoice Editor";
            this.Load += new System.EventHandler(this.Editor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DGV;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Button_Done;
        private System.Windows.Forms.Button Button_Reset;
        private System.Windows.Forms.Label Label_SubTotal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TextBox_Discount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TextBox_PPN;
        private System.Windows.Forms.Label Label_GrandTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Item_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price_Each;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalBeforeDiscount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Discount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.Button button1;
    }
}

