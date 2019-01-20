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

            for (int i = 0; i < RowCount; i++)
            {
                DGV.Rows[i].Cells[4].Value = String2Int(DGV.Rows[i].Cells[1].Value.ToString()) * String2Int(DGV.Rows[i].Cells[3].Value.ToString());
                for (int j = 0; j < ColumnCount; j++)
                {
                    if (DGV.Rows[i].Cells[j].Value == null || DGV.Rows[i].Cells[j].Value == DBNull.Value)
                    {
                        DGV.Rows[i].Cells[j].Value = 0;
                    }
                }
                DGV.Rows[i].Cells[6].Value = String2Int(DGV.Rows[i].Cells[4].Value.ToString()) - String2Int(DGV.Rows[i].Cells[5].Value.ToString());
                Excelobj.ExcelInvoiceSubTotal = String2Int(Excelobj.ExcelInvoiceSubTotal + DGV.Rows[i].Cells[6].Value.ToString());
                
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
                        new string[] { "Tlp:  0778 - 702 6785    Fax :  0778 - 358 2804", "" , "" , "" , "" , "" , "" , Excelobj.ExcelAddress3, "" },
                        new string[] { "E-Mail : surya.simpang.barelang@gmail.com", "", "", "", "", "", "Telepon :", Excelobj.ExcelConctactNumber, "" },
                        new string[] { "Invoice No : " + Excelobj.ExcelInvoiceNumber , "", "" , "INVOICE" , "" , "" , "" , "" , "" },
                        new string[] { "Tanggal      : " + Excelobj.ExcelInvoiceDate , "" , "" , "" , "" , "" , "" , "" , ""}

                    };




                    //Console.WriteLine(Row01[1]);

                    //List<string[]> Row02 = new List<string[]>()
                    //{
                    //    new string[] { "TEMBESI CENTRE BLOK. A3  NO. 3, 3A  &  5  BATU AJI - BATAM", "", "", "", "", "", "", Excelobj.ExcelAddress2, "" }
                    //};

                    //List<string[]> Row03 = new List<string[]>()
                    //{
                    //    new string[] { "Tlp:  0778 - 702 6785    Fax :  0778 - 358 2804", "" , "" , "" , "" , "" , "" , Excelobj.ExcelAddress3, "" }
                    //};

                    //List<string[]> Row04 = new List<string[]>()
                    //{
                    //    new string[] { "E-Mail : surya.simpang.barelang@gmail.com", "", "", "", "", "", "Telepon :", Excelobj.ExcelConctactNumber, "" }
                    //};

                    //List<string[]> Row05 = new List<string[]>()
                    //{
                    //    new string[] { "Invoice No : " + Excelobj.ExcelInvoiceNumber , "", "" , "INVOICE" , "" , "" , "" , "" , "" }
                    //};

                    //List<string[]> Row06 = new List<string[]>()
                    //{
                    //    new string[] { "Tanggal      : " + Excelobj.ExcelInvoiceDate , "" , "" , "" , "" , "" , "" , "" , ""}
                    //};

                    //

                    List<string[]> TableHeader = new List<string[]>()
                    {
                        new string[] { "No" , "Nama Barang" , "" , "Jumlah" , "" , "Harga @" , "Harga" , "Discount" , "Total" }
                    };

                    List<string[]> InvoiceItems = new List<string[]>();

                    //for (int i = 0; i < RowCount; i++)
                    //{
                    //    string[] abc = new string[ColumnCount];
                    //    for (int j = 0; j < ColumnCount; j++)
                    //    {
                    //        abc[j] = DGV.Rows[i].Cells[j].Value.ToString();
                    //    }
                    //    InvoiceItems.Add(abc);
                    //}

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
                            DGV.Rows[i].Cells[3].Value.ToString(),
                            DGV.Rows[i].Cells[4].Value.ToString(),
                            DGV.Rows[i].Cells[5].Value.ToString(),
                            DGV.Rows[i].Cells[6].Value.ToString()
                        });
                        }
                    }





                    List<string[]> InvoiceFooter = new List<string[]>()
                    {
                        new string[] { "","","" , "" , "" , "" , "Sub Total" , ":" , "PLACEHOLDER" },
                        new string[] { "Catatan :" ,"", Excelobj.ExcelInvoiceNote , "" , "" , "" , "Discount" , ":" , "PLACEHOLDER" },
                        new string[] { "","","" , "" , "" , "" , "PPN" , ":" , "PLACEHOLDER" },
                        new string[] { "","","" , "" , "" , "" , "Grand Total" , ":" , "PLACEHOLDER" },
                        new string[] { "", "", "" , "" , "" , "" , "" , "" , "" },
                        new string[] { "", "Yang Menerima" , "" , "Kepala Gudang" , "" , "" , "Supir/Helper" , "" , "Hormat Kami" }
                    };

                    //List<string[]> TableFooter01 = new List<string[]>()
                    //{
                    //    new string[] { "","","" , "" , "" , "" , "Sub Total" , ":" , "PLACEHOLDER" }
                    //};

                    //List<string[]> TableFooter02 = new List<string[]>()
                    //{
                    //    new string[] { "Catatan :" ,"", Excelobj.ExcelInvoiceNote , "" , "" , "" , "Discount" , ":" , "PLACEHOLDER" }
                    //};

                    //List<string[]> TableFooter03 = new List<string[]>()
                    //{
                    //    new string[] { "","","" , "" , "" , "" , "PPN" , ":" , "PLACEHOLDER" }
                    //};

                    //List<string[]> TableFooter04 = new List<string[]>()
                    //{
                    //    new string[] { "","","" , "" , "" , "" , "Grand Total" , ":" , "PLACEHOLDER" }
                    //};

                    //List<string[]> TableFooter05 = new List<string[]>()
                    //{
                    //    new string[] { "","Yang Menerima" , "" , "Kepala Gudang" , "" , "" , "Supir/Helper" , "" , "Hormat Kami" }
                    //};


                    //Populate Cell
                    worksheet.Cells["A1:I6"].LoadFromArrays(InvoiceHeader);
                    worksheet.Cells["A8:I8"].LoadFromArrays(TableHeader);
                    worksheet.Cells["A9:I" + (9 + offset)].LoadFromArrays(InvoiceItems);
                    worksheet.Cells["A" + (9 + offset) + ":I" + (14 + offset)].LoadFromArrays(InvoiceFooter);

                    //worksheet.Cells["A1:I1"].LoadFromArrays(Row01);
                    //worksheet.Cells["A2:I2"].LoadFromArrays(Row02);
                    //worksheet.Cells["A3:I3"].LoadFromArrays(Row03);
                    //worksheet.Cells["A4:I4"].LoadFromArrays(Row04);
                    //worksheet.Cells["A5:I5"].LoadFromArrays(Row05);
                    //worksheet.Cells["A6:I6"].LoadFromArrays(Row06);

                    

                    //worksheet.Cells["A" + (9 + offset) + ":I" + (9 + offset)].LoadFromArrays(TableFooter01);
                    //worksheet.Cells["A" + (10 + offset) + ":I" + (10 + offset)].LoadFromArrays(TableFooter02);
                    //worksheet.Cells["A" + (11 + offset) + ":I" + (11 + offset)].LoadFromArrays(TableFooter03);
                    //worksheet.Cells["A" + (12 + offset) + ":I" + (12 + offset)].LoadFromArrays(TableFooter04);
                    //worksheet.Cells["A" + (14 + offset) + ":I" + (14 + offset)].LoadFromArrays(TableFooter05);




                    //////////////////////////
                    // Cell Merge Operation //
                    //////////////////////////

                    //ExcelRange mergecells = worksheet.Cells["A1:D1"];
                    worksheet.Cells["A1:F1"].Merge = true;
                    worksheet.Cells["A2:F2"].Merge = true;
                    worksheet.Cells["A3:F3"].Merge = true;
                    worksheet.Cells["A4:F4"].Merge = true;
                    worksheet.Cells["A5:C5"].Merge = true;
                    worksheet.Cells["A6:C6"].Merge = true;
                    
                    worksheet.Cells["D5:F5"].Merge = true;

                    worksheet.Cells["H1:I1"].Merge = true;
                    worksheet.Cells["H2:I2"].Merge = true;
                    worksheet.Cells["H3:I3"].Merge = true;
                    worksheet.Cells["H4:I4"].Merge = true;
                    
                    worksheet.Cells["B8:C8"].Merge = true;
                    worksheet.Cells["D8:E8"].Merge = true;

                    worksheet.Cells["A" + (10 + offset) + ":B" + (10 + offset)].Merge = true;
                    worksheet.Cells["C" + (10 + offset) + ":E" + (12 + offset)].Merge = true;
                    worksheet.Cells["D" + (14 + offset) + ":E" + (14 + offset)].Merge = true;

                    if (offset > 0)
                    {
                        for (int i = 0; i < offset; i++)
                        {
                            worksheet.Cells["B" + (9 + i) + ":C" + (9 + i)].Merge = true;
                        }
                    }

                    
                    ///////////////////////
                    // CELL Width Config //
                    ///////////////////////

                    worksheet.Column(1).Width = 5 + 0.71;
                    worksheet.Column(2).Width = 15 + 0.71;
                    worksheet.Column(3).Width = 30 + 0.71;
                    worksheet.Column(4).Width = 7.5 + 0.71;
                    worksheet.Column(5).Width = 7.5 + 0.71;
                    worksheet.Column(6).Width = 15 + 0.71;
                    worksheet.Column(7).Width = 15 + 0.71;
                    worksheet.Column(8).Width = 15 + 0.71;
                    worksheet.Column(9).Width = 15 + 0.71;

                    
                    ///////////////////////
                    // Styling Operation //
                    ///////////////////////
                    
                    worksheet.Cells["A1:I6"].Style.Font.SetFromFont(new Font("Calibri", 12));
                    worksheet.Cells["A1:I6"].Style.Font.Bold = true;
                    worksheet.Cells["D5"].Style.Font.UnderLine = true;
                    worksheet.Cells["C" + (10 + offset) + ":E" + (12 + offset)].Style.WrapText = true;
                    //Alignment 01
                    worksheet.Cells["D5"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                    worksheet.Cells["A8:I8"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;

                    //ITEMS
                    if (offset > 0)
                    {
                        worksheet.Cells["D9:D" + (9+ offset)].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Right;
                        worksheet.Cells["F9:I" + (9+ offset)].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Right;
                        
                    }

                    //Alignment 02
                    worksheet.Cells["G" + (9 + offset) + ":G" + (12 + offset)].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
                    worksheet.Cells["H" + (9 + offset) + ":H" + (12 + offset)].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                    worksheet.Cells["I" + (9 + offset) + ":I" + (12 + offset)].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Right;
                    worksheet.Cells["A" + (10 + offset) + ":B" + (10 + offset)].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Right;
                    worksheet.Cells["C" + (10 + offset) + ":E" + (12 + offset)].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Top;
                    worksheet.Cells["A" + (14 + offset) + ":I" + (14 + offset)].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                    

                    //worksheet.Cells["A14:G14"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                    
                    ////////////
                    // Border //
                    ////////////
                    
                    worksheet.Cells["A8:I8"].Style.Border.Top.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                    worksheet.Cells["A8:I8"].Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                    worksheet.Cells["A" + (9 + offset) + ":I" + (9 + offset)].Style.Border.Top.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                    worksheet.Cells["C" + (10 + offset) + ":E" + (12 + offset)].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    worksheet.Cells["G" + (12 + offset) + ":I" + (12 + offset)].Style.Border.Top.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thick;
                    worksheet.Cells["B" + (17 + offset)].Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thick;
                    worksheet.Cells["D" + (17 + offset) + ":E" + (17 + offset)].Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thick;
                    worksheet.Cells["G" + (17 + offset)].Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thick;
                    worksheet.Cells["I" + (17 + offset)].Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thick;





                    // SET PRINT AREA //
                    worksheet.PrinterSettings.PrintArea = worksheet.Cells["A1:I" + (17 + offset)];

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



                }
                else
                {
                    MessageBox.Show("Nama File Tidak Boleh Kosong");
                }
            }

            


        }

        private void Editor_Load(object sender, EventArgs e)
        {
            
        }

        private void DGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

            int RowCount = DGV.RowCount - 1;
            int ColumnCount = DGV.ColumnCount;

            for (int i = 0; i < RowCount; i++)
            {
                DGV.Rows[i].Cells[4].Value = String2Int(DGV.Rows[i].Cells[1].Value.ToString()) * String2Int(DGV.Rows[i].Cells[3].Value.ToString());
                for (int j = 0; j < ColumnCount; j++)
                {
                    if (DGV.Rows[i].Cells[j].Value == null || DGV.Rows[i].Cells[j].Value == DBNull.Value)
                    {
                        DGV.Rows[i].Cells[j].Value = 0;
                    }
                }
                DGV.Rows[i].Cells[6].Value = String2Int(DGV.Rows[i].Cells[4].Value.ToString()) - String2Int(DGV.Rows[i].Cells[5].Value.ToString());
            }
            
            


            //for (int i = 0; i < RowCount; i++)
            //{
            //    for (int j = 0; j < ColumnCount; j++)
            //    {
            //        if (DGV.Rows[i].Cells[j].Value == null || DGV.Rows[i].Cells[j].Value == DBNull.Value)
            //        {
            //            Console.WriteLine("dub");
            //            DGV.Rows[i].Cells[j].Value = 0;
            //        }
            //    }
            //}


            

            //DGV.Rows[0].Cells[4].Value = String2Int(DGV.Rows[0].Cells[1].Value.ToString()) * String2Int(DGV.Rows[0].Cells[3].Value.ToString());




        }
        
        private int String2Int(string str)
        {
            if (int.TryParse(str, out int parsed))
            {
                return parsed;
            }
            return 0;

        }
    }
}
