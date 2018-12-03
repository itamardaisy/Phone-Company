using Common.Interfaces;
using Common.Models;
using PdfSharp;
using System;
using System.Collections.Generic;
using TheArtOfDev.HtmlRenderer.PdfSharp;

namespace BillingService.Services
{
    public class PdfCreator : IPdfCreator
    {
        private byte[] pdfFile;

        public byte[] PdfFile
        {
            get => pdfFile;
            set => pdfFile = value;
        }

        public void WriteToFile(Dictionary<string, Receipt> payments, DateTime time)
        {
            string header = "<h1>Recipt Summery</h1>";
            string tableRows = "";
            foreach (var payment in payments)
            {
                header += $"<h1>Line Number: {payment.Key}</h1>";
                tableRows += $"<tr><td>{time}</td>" +
                             $"<td>{payment.Value.BasePrice}</td>" +
                             $"<td>{payment.Value.DisscountPercentage}</td>" +
                             $"<td>{payment.Value.CallsExtraPrice}</td>" +
                             $"<td>{payment.Value.SMSsExtraPrice}</td>" +
                             $"<td>{payment.Value.TotalPriceBeforeDisscount}</td>" +
                             $"<td>{payment.Value.TotalPriceAfterDisscount}</td>" +
                             $"</tr>";
            }
            string Table =
             "<table>" +
                "<tr>" +
                    "<th>Date</th>" +
                    "<th>Base Price</th>" +
                    "<th>Discount Percentage</th>" +
                    "<th>Calls Extra Price</th>" +
                    "<th>SMSs Extra Price</th>" +
                    "<th>Total Price</th>" +
                    "<th>Price After Discount</th>" +
             "</tr>" +
                $"{tableRows}" +
             "</table>";
            string style = "<style> table, th, td { border: 1px solid black; border - collapse: collapse;margin-left: 4px;margin-right: 4px; }</style>";
            string html = $"<!DOCTYPE html><html><head>{style}<title></title></head><body>{header}{Table}</body></html>";
            PdfSharp.Pdf.PdfDocument pdf = PdfGenerator.GeneratePdf(html, PageSize.A4);
            pdf.Save(@"c:\Receipt.pdf");
        }

        public void WriteToExcel(Dictionary<string, Receipt> payments, DateTime time)
        {
            Microsoft.Office.Interop.Excel.Application oXL;
            Microsoft.Office.Interop.Excel._Workbook oWB;
            Microsoft.Office.Interop.Excel._Worksheet oSheet;
            Microsoft.Office.Interop.Excel.Range oRng;
            object misvalue = System.Reflection.Missing.Value;
            try
            {
                //Start Excel and get Application object.
                oXL = new Microsoft.Office.Interop.Excel.Application();
                oXL.Visible = false;

                //Get a new workbook.
                oWB = (Microsoft.Office.Interop.Excel._Workbook)(oXL.Workbooks.Add(""));
                oSheet = (Microsoft.Office.Interop.Excel._Worksheet)oWB.ActiveSheet;

                //Add table headers going cell by cell.
                oSheet.Cells[1, 1] = "Date";
                oSheet.Cells[1, 2] = "Base Price";
                oSheet.Cells[1, 3] = "Discount Percentage";
                oSheet.Cells[1, 4] = "Calls Extra Price";
                oSheet.Cells[1, 5] = "SMSs Extra Price";
                oSheet.Cells[1, 6] = "Total Price";
                oSheet.Cells[1, 7] = "Price After Discount";

                foreach (var payment in payments)
                {
                    oSheet.Cells[2, 1] = $"{time}";
                    oSheet.Cells[2, 2] = $"{payment.Value.BasePrice}";
                    oSheet.Cells[2, 3] = $"{payment.Value.DisscountPercentage}";
                    oSheet.Cells[2, 4] = $"{payment.Value.CallsExtraPrice}";
                    oSheet.Cells[2, 5] = $"{payment.Value.SMSsExtraPrice}";
                    oSheet.Cells[2, 6] = $"{payment.Value.TotalPriceBeforeDisscount}";
                    oSheet.Cells[2, 7] = $"{payment.Value.TotalPriceAfterDisscount}";
                }

                oXL.Visible = false;
                oXL.UserControl = false;
                oWB.SaveAs(@"c:\Receipt.xlsx", Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookDefault, Type.Missing, Type.Missing,
                    false, false, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

                oWB.Close();
            }
            catch
            {
            }
        }
    }
}