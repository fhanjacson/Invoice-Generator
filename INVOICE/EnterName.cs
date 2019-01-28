using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace INVOICE
{
    public partial class EnterName : Form
    {
        public EnterName()
        {
            InitializeComponent();
        }

        private void Button_OK_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(TextBox_Name.Text))
            {

                Editor.Excelobj.ExcelFileName = TextBox_Name.Text;
                Editor.Excelobj.ExcelFilePath = Editor.Excelobj.ExcelFileLocation + "\\" + Editor.Excelobj.ExcelFileName + ".xlsx";
                if (File.Exists(Editor.Excelobj.ExcelFilePath))
                {
                    label2.Text = "Nama sudah ada";
                }
                else
                {
                    this.Close();
                }
            }
            else if (string.IsNullOrEmpty(TextBox_Name.Text) || string.IsNullOrWhiteSpace(TextBox_Name.Text)){
                MessageBox.Show("Nama tidak boleh kosong");
            }
            else
            {
                this.Close();
            }

        }

        private void EnterName_Load(object sender, EventArgs e)
        {
            label2.Text = "";
        }
    }
}
