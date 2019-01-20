using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace INVOICE
{
    public partial class EnterDetail : Form
    {

        public static Excel ExcelDetail = new Excel();

        public EnterDetail()
        {
            InitializeComponent();
        }

        private bool Check()
        {
            if (!string.IsNullOrWhiteSpace(TextBox_InvoiceNo.Text)){
                if (!string.IsNullOrWhiteSpace(DateTimePicker.Value.ToString())){
                    if (!string.IsNullOrWhiteSpace(TextBox_Address1.Text)){
                        if (!string.IsNullOrWhiteSpace(TextBox_ContactNo.Text)){
                            return true;
                        } else { MessageBox.Show("Nomor Telepon tidak boleh kosong"); }
                    }else { MessageBox.Show("Alamat 1 tidak boleh kosong"); }
                }else { MessageBox.Show("Tanggal Invoice tidak boleh kosong"); }
            }else { MessageBox.Show("Nomor Invoice tidak boleh kosong"); }

            return false;
        }

        private void Button_Next_Click(object sender, EventArgs e)
        {
            if (Check())
            {


                ExcelDetail.ExcelInvoiceNumber = TextBox_InvoiceNo.Text;
                ExcelDetail.ExcelInvoiceDate = DateTimePicker.Value.ToString("dd/MM/yyyy");
                ExcelDetail.ExcelAddress1 = TextBox_Address1.Text;
                ExcelDetail.ExcelAddress2 = TextBox_Address2.Text;
                ExcelDetail.ExcelAddress3 = TextBox_Address3.Text;
                ExcelDetail.ExcelConctactNumber = TextBox_ContactNo.Text;
                ExcelDetail.ExcelInvoiceNote = TextBox_Note.Text;

                Form FormEditor = new Editor();
                this.Hide();
                FormEditor.ShowDialog();                
                this.Close();
            }
            else { }
        }
        

        private void EnterDetail_Load(object sender, EventArgs e)
        {
            // DELETE THIS BEFORE DEPLOY
            TextBox_InvoiceNo.Text = "a";
            TextBox_Address1.Text = "a";
            TextBox_ContactNo.Text = "a";
        }
    }
}
