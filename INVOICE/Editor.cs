using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OfficeOpenXml;

namespace INVOICE
{
    public partial class Editor : Form
    {
        public static Excel Excelobj = EnterDetail.ExcelDetail;

        public Editor()
        {
            InitializeComponent();
        }

        private void preExcel()
        {
            int RowCount = DGV.RowCount - 1;
            int ColumnCount = DGV.ColumnCount;


            if (string.IsNullOrWhiteSpace(TextBox_Discount.Text) || !isInt(TextBox_Discount.Text)) {
                TextBox_Discount.Text = "0";

            }
            if (string.IsNullOrWhiteSpace(TextBox_PPN.Text) || !isInt(TextBox_PPN.Text)) {
                TextBox_PPN.Text = "0";
            }


            if (RowCount > 0)
            {
                int subtotal;
                subtotal = 0;
                
                for (int i = 0; i < RowCount; i++)
                {
                    for (int j = 0; j < ColumnCount; j++)
                    {
                        if (DGV.Rows[i].Cells[j].Value != null)
                        {
                            Console.WriteLine("Not Null");
                            if (j != 2 && j != 0)
                            {
                                if (!int.TryParse(DGV.Rows[i].Cells[j].Value.ToString(), out int a))
                                {
                                    DGV.Rows[i].Cells[j].Value = 0;
                                }
                            }
                            else if (j == 0)
                            {
                                if (string.IsNullOrWhiteSpace(DGV.Rows[i].Cells[j].Value.ToString()))
                                {
                                    DGV.Rows[i].Cells[j].Value = "Item";
                                }
                            }
                            else if (j == 2)
                            {
                                if (string.IsNullOrWhiteSpace(DGV.Rows[i].Cells[j].Value.ToString()))
                                {
                                    DGV.Rows[i].Cells[j].Value = "Pcs";
                                }
                            }
                        }
                        else if (DGV.Rows[i].Cells[j].Value == null)
                        {
                            Console.WriteLine("Null");
                            if (j != 2)
                            {
                                DGV.Rows[i].Cells[j].Value = 0;
                            }
                            else if (j == 0)
                            {
                                DGV.Rows[i].Cells[j].Value = "Item";
                            }
                            else if (j == 2)
                            {
                                DGV.Rows[i].Cells[j].Value = "Pcs";
                            }
                            
                        }
                    }
                    //Calculate Total Before Discount
                    DGV.Rows[i].Cells[4].Value = String2Int(DGV.Rows[i].Cells[1].Value.ToString()) * String2Int(DGV.Rows[i].Cells[3].Value.ToString());
                    //Calculate Total After Discount
                    DGV.Rows[i].Cells[6].Value = String2Int(DGV.Rows[i].Cells[4].Value.ToString()) - String2Int(DGV.Rows[i].Cells[5].Value.ToString());
                    //Saving Subtotal to object
                    subtotal = subtotal + String2Int(DGV.Rows[i].Cells[6].Value.ToString());
                }
                //Console.WriteLine("subtotal: " + subtotal);
                Excelobj.ExcelInvoiceSubTotal = subtotal;
                //Console.WriteLine(Excelobj.ExcelInvoiceSubTotal.ToString());
                Label_SubTotal.Text = "Sub Total : " + convert2IDR(Excelobj.ExcelInvoiceSubTotal);
                
                Excelobj.ExcelInvoiceDiscount = String2Int(TextBox_Discount.Text);
                Excelobj.ExcelInvoicePPN = String2Int(TextBox_PPN.Text);

                Excelobj.ExcelInvoiceGrandTotal = (Excelobj.ExcelInvoiceSubTotal - Excelobj.ExcelInvoiceDiscount) - Excelobj.ExcelInvoicePPN;
                Label_GrandTotal.Text = "Grand Total : " + convert2IDR(Excelobj.ExcelInvoiceGrandTotal);
                
            }
        }


        private void Button_Done_Click(object sender, EventArgs e)
        {
            preExcel();
            Excelobj.ExcelFileLocation = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            Console.WriteLine(Excelobj.ExcelFileLocation.ToString());

            using (ExcelPackage Excel = new ExcelPackage())
            {            
                /////////////////////
                // File Name Setup //
                /////////////////////
                
                //Opening Dialog Form to Enter File Name
                Form formname = new EnterName();
                formname.ShowDialog();

                if (Excelobj.ExcelFileName != null)
                {
                    
                    //Initialize Excel File
                    Excel.Workbook.Worksheets.Add("INVOICE 01");
                    var worksheet = Excel.Workbook.Worksheets["INVOICE 01"];

                    int offset = 0;
                    int RowCount = DGV.RowCount - 1;
                    int ColumnCount = DGV.ColumnCount;
                    offset = RowCount;
                    
                    
                    
                    //Populate Data to Cells

                    List<string[]> InvoiceHeader = new List<string[]>()
                    {
                        new string[] { "SURYA SIMPANG BARELANG" , "" , "" , "", "" , "" , "Kepada :", Excelobj.ExcelAddress1, "" },
                        new string[] { "TEMBESI CENTRE BLOK. A3  NO. 3, 3A  &  5  BATU AJI - BATAM", "", "", "", "", "", "", Excelobj.ExcelAddress2, "" },
                        new string[] { "Tlp: 0778-702-6785 E-Mail: Surya.Simpang.Barelang@Gmail.com", "" , "" , "" , "" , "" , "Telepon: " , Excelobj.ExcelConctactNumber, "" },
                        new string[] { "Invoice No : " + Excelobj.ExcelInvoiceNumber , "", "", "INVOICE", "", "", "Tanggal :" , Excelobj.ExcelInvoiceDate, "" },
                        //new string[] { "Invoice No : " + Excelobj.ExcelInvoiceNumber , "", "" , "INVOICE" , "" , "" , "Tanggal :" , Excelobj.ExcelInvoiceDate, ""},
                       

                    };

                    List<string[]> TableHeader = new List<string[]>()
                    {
                        new string[] { "No" , "Nama Barang" , "" , "Jumlah" , "" , "Harga @" , "Harga" , "Discount" , "Total" }
                    };

                    List<string[]> InvoiceItems = new List<string[]>();

                    if (offset > 0)
                    {
                        for (int i = 0; i < RowCount; i++)
                        {
                            InvoiceItems.Add(new string[] {
                            (i+1).ToString(),
                            DGV.Rows[i].Cells[0].Value.ToString(),
                            "",
                            DGV.Rows[i].Cells[1].Value.ToString(),
                            DGV.Rows[i].Cells[2].Value.ToString(),
                            convert2IDR(String2Int(DGV.Rows[i].Cells[3].Value.ToString())),
                            convert2IDR(String2Int(DGV.Rows[i].Cells[4].Value.ToString())),
                            convert2IDR(String2Int(DGV.Rows[i].Cells[5].Value.ToString())),
                            convert2IDR(String2Int(DGV.Rows[i].Cells[6].Value.ToString()))
                        });
                        }
                    }


                    List<string[]> InvoiceFooter = new List<string[]>()
                    {
                        new string[] { "","","" , "" , "" , "" , "Sub Total" , ": " , convert2IDR(Excelobj.ExcelInvoiceSubTotal) },
                        new string[] { "Catatan :" ,"", Excelobj.ExcelInvoiceNote , "" , "" , "" , "Discount" , ": " , convert2IDR(Excelobj.ExcelInvoiceDiscount) },
                        new string[] { "","","" , "" , "" , "" , "PPN" , ": " , convert2IDR(Excelobj.ExcelInvoicePPN) },
                        new string[] { "","","" , "" , "" , "" , "Grand Total" , ": " , convert2IDR(Excelobj.ExcelInvoiceGrandTotal) },
                        new string[] { "", "", "" , "" , "" , "" , "" , "" , "" },
                        new string[] { "", "Yang Menerima" , "" , "Kepala Gudang" , "" , "" , "Supir/Helper" , "" , "Hormat Kami" }
                    };

                    //Populate Cell
                    worksheet.Cells["A1:I4"].LoadFromArrays(InvoiceHeader);
                    worksheet.Cells["A5:I5"].LoadFromArrays(TableHeader);
                    worksheet.Cells["A6:I" + (6 + offset)].LoadFromArrays(InvoiceItems);
                    worksheet.Cells["A" + (6 + offset) + ":I" + (11 + offset)].LoadFromArrays(InvoiceFooter);

                    //////////////////////////
                    // Cell Merge Operation //
                    //////////////////////////

                    //ExcelRange mergecells = worksheet.Cells["A1:D1"];
                    worksheet.Cells["A1:F1"].Merge = true; // SURYA SIMPANG BARELANG
                    worksheet.Cells["A2:F2"].Merge = true; // TEMBESI CENTRE
                    worksheet.Cells["A3:F3"].Merge = true; // TLP
                    worksheet.Cells["A4:c4"].Merge = true; // INVOICE NO
                    //worksheet.Cells["A5:C5"].Merge = true;
                    //worksheet.Cells["A6:C6"].Merge = true;
                    
                    worksheet.Cells["D4:F4"].Merge = true; // INVOICE

                    worksheet.Cells["H1:I1"].Merge = true; // ALAMAT 1 
                    worksheet.Cells["H2:I2"].Merge = true; // ALAMAT 2
                    worksheet.Cells["H3:I3"].Merge = true; // NOMOR TELEPON
                    worksheet.Cells["H4:I4"].Merge = true; // TANGGAL INVOICE
                    //worksheet.Cells["H5:I5"].Merge = true;
                    
                    worksheet.Cells["B5:C5"].Merge = true; // NAMA BARANG
                    worksheet.Cells["D5:E5"].Merge = true; // JUMLAH 

                    worksheet.Cells["A" + (7 + offset) + ":B" + (7 + offset)].Merge = true; //Catatan
                    worksheet.Cells["C" + (7 + offset) + ":E" + (9 + offset)].Merge = true; //Catatan
                    worksheet.Cells["D" + (11 + offset) + ":E" + (11 + offset)].Merge = true; //Kepala gudang

                    if (offset > 0)
                    {
                        for (int i = 0; i < offset; i++)
                        {
                            worksheet.Cells["B" + (6 + i) + ":C" + (6 + i)].Merge = true; // ITEMS
                        }
                    }

                    
                    ///////////////////////
                    // CELL Width Config //
                    ///////////////////////

                    worksheet.Column(1).Width = 3;
                    worksheet.Column(2).Width = 12;
                    worksheet.Column(3).Width = 12;
                    worksheet.Column(4).Width = 7.5;
                    worksheet.Column(5).Width = 7.5;
                    worksheet.Column(6).Width = 15;
                    worksheet.Column(7).Width = 15;
                    worksheet.Column(8).Width = 15;
                    worksheet.Column(9).Width = 15;
                    
                    for (int i = 1; i <= (14 + offset); i++)
                    {
                        worksheet.Row(i).Height = 13;
                    }
                    
                    ///////////////////////
                    // Styling Operation //
                    ///////////////////////
                    
                    //worksheet.Cells["A1:I5"].Style.Font.SetFromFont(new Font("Calibri", 11));
                    worksheet.Cells["A1:I4"].Style.Font.Bold = true; // HEADER BOLD
                    worksheet.Cells["D4"].Style.Font.UnderLine = true; // INVOICE UNDERLINE
                    worksheet.Cells["C" + (7 + offset) + ":E" + (9 + offset)].Style.WrapText = true; // CATATAN WRAP TEXT
                    worksheet.Cells["D4"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center; // INVOICE CENTER
                    worksheet.Cells["A5:I5"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center; // TABLE HEADER CENTER
                    worksheet.Cells["A1:I" + (11 + offset)].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center; // ALL VERTICAL CENTER
                    
                    // ITEMS
                    if (offset > 0)
                    {
                        worksheet.Cells["D6:D" + (6+ offset)].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Right; // JUMLAH RIGHT
                        worksheet.Cells["F6:I" + (6+ offset)].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Right; // HARGA-TOTAL RIGHT
                    }

                    worksheet.Cells["G" + (6 + offset) + ":G" + (9 + offset)].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left; //SUBTOTAL-GRAND TOTAL (WORDS) LEFT
                    worksheet.Cells["H" + (6 + offset) + ":H" + (9 + offset)].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center; // COLON CENTER
                    worksheet.Cells["I" + (6 + offset) + ":I" + (9 + offset)].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Right; // SUBTOTAL-GRAND TOTAL (NUMBER) RIGHT
                    worksheet.Cells["A" + (7 + offset) + ":B" + (7 + offset)].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Right; // CATATAN HORIZONTAL RIGHT
                    worksheet.Cells["C" + (7 + offset) + ":E" + (7 + offset)].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Top; // CATATAN VERTICAL TOP
                    worksheet.Cells["A" + (11 + offset) + ":I" + (11 + offset)].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center; // YANG MENERIMA-HORMAT KAMI CENTER
                                        
                    ////////////
                    // Border //
                    ////////////
                    
                    worksheet.Cells["A5:I5"].Style.Border.Top.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                    worksheet.Cells["A5:I5"].Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                    worksheet.Cells["A" + (6 + offset) + ":I" + (6 + offset)].Style.Border.Top.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                    worksheet.Cells["C" + (7 + offset) + ":E" + (9 + offset)].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    worksheet.Cells["G" + (9 + offset) + ":I" + (9 + offset)].Style.Border.Top.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thick;
                    worksheet.Cells["B" + (14 + offset)].Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thick;
                    worksheet.Cells["D" + (14 + offset) + ":E" + (14 + offset)].Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thick;
                    worksheet.Cells["G" + (14 + offset)].Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thick;
                    worksheet.Cells["I" + (14 + offset)].Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thick;

                    // SET PRINT AREA //
                    worksheet.PrinterSettings.PrintArea = worksheet.Cells["A1:I" + (14 + offset)];

                    // Printer Settings //
                    worksheet.PrinterSettings.HeaderMargin = 0;
                    worksheet.PrinterSettings.FooterMargin= 0;
                    worksheet.PrinterSettings.LeftMargin = 0;
                    worksheet.PrinterSettings.RightMargin = 0;
                    worksheet.PrinterSettings.TopMargin = 0;
                    worksheet.PrinterSettings.BottomMargin = 0;
                    worksheet.PrinterSettings.BlackAndWhite = true;
                    worksheet.PrinterSettings.RepeatRows = worksheet.Cells["1:5"];
                   

                    ///////////////////////
                    // FILE IO OPERATION //
                    ///////////////////////

                    //FileInfo ExcelFile = new FileInfo(Excelobj.ExcelFileLocation + "\\" + Excelobj.ExcelFileName + ".xlsx");
                    FileInfo ExcelFile = new FileInfo(Excelobj.ExcelFilePath);
                    Excel.SaveAs(ExcelFile);

                    bool isExcelInstalled = Type.GetTypeFromProgID("Excel.Application") != null ? true : false;

                    if (isExcelInstalled)
                    {
                        System.Diagnostics.Process.Start(ExcelFile.ToString());
                    }
                    //Done();
                }
                else
                {
                    MessageBox.Show("Nama File Tidak Boleh Kosong");
                }
            }
        }

        private void Reset()
        {
            Label_SubTotal.Text = "Sub Total :";
            TextBox_Discount.Text = "0";
            TextBox_PPN.Text = "0";
            Label_GrandTotal.Text = "Grand Total :";
            DGV.Rows.Clear();
        }

        private void Done()
        {
            this.Close();
        }
        
        private int String2Int(string str)
        {
            if (int.TryParse(str, out int parsed))
            {
                return parsed;
            }
            return 0;
        }

        private bool isInt(string str)
        {
            return int.TryParse(str, out int i);
        }

        private string convert2IDR(int i)
        {
            return i.ToString("C", CultureInfo.CreateSpecificCulture("id-ID"));
        } 

        private void Button_Reset_Click(object sender, EventArgs e)
        {
            Reset();
        }
        
        private void TextBox_Discount_MouseClick(object sender, MouseEventArgs e)
        {
            preExcel();
        }

        private void TextBox_PPN_MouseClick(object sender, MouseEventArgs e)
        {
            preExcel();
        }
        
        private void DGV_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            preExcel();
        }

        private void TextBox_Discount_Leave(object sender, EventArgs e)
        {
            preExcel();
        }

        private void TextBox_PPN_Leave(object sender, EventArgs e)
        {
            preExcel();
        }

        private void Editor_Load(object sender, EventArgs e)
        {
            DGV.CurrentCell = DGV.Rows[0].Cells[0];
            //button1.Visible = true;

        }

        private void DGV_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            preExcel();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 25; i++)
            {
                DGV.Rows.Add("ITEM 01", "12", "Pcs", "200000", "", "10000", "");
            }
        }
    }
}
