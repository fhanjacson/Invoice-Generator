using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INVOICE
{
    public class Excel
    {
        public string ExcelFilePath { get; set; }
        public string ExcelFileLocation { get; set; }
        public string ExcelFileName { get; set; }

        public string ExcelInvoiceNumber { get; set; }
        public string ExcelInvoiceDate { get; set; }
        public string ExcelAddress1{ get; set; }
        public string ExcelAddress2 { get; set; }
        public string ExcelAddress3 { get; set; }
        public string ExcelConctactNumber { get; set; }
        public string ExcelInvoiceNote { get; set; }
                
        public int ExcelInvoiceSubTotal { get; set; }
        public int ExcelInvoiceDiscount { get; set; }
        public int ExcelInvoicePPN { get; set; }
        public int ExcelInvoiceGrandTotal { get; set; }




        public Excel()
        {
            ExcelFilePath = "";
            ExcelFileLocation = "";
            ExcelFileName = "";

            ExcelInvoiceNumber = "";
            ExcelInvoiceDate = "";
            ExcelAddress1 = "";
            ExcelAddress2 = "";
            ExcelAddress3 = "";
            ExcelConctactNumber = "";
            ExcelInvoiceNote = "";

            ExcelInvoiceSubTotal = 0;
            ExcelInvoiceDiscount = 0;
            ExcelInvoicePPN = 0;
            ExcelInvoiceGrandTotal = 0;
        }

        Excel(string FileLocation, string FileName)
        {
            ExcelFileLocation = FileLocation;
            ExcelFileName = FileName;
        }




    }
}
