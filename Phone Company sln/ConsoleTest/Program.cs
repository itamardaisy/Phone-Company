using BillingService.Services;
using Common.Models;
using PdfSharp;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheArtOfDev.HtmlRenderer.PdfSharp;

namespace ConsoleTest
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            PdfCreator pdgCreator = new PdfCreator();
            Receipt receipt = new Receipt
            {
                BasePrice = 100,
                CallsExtraPrice = 2,
                DisscountPercentage = 2,
                SMSsExtraPrice = 12              
            };
            Dictionary<string, Receipt> dictionary = new Dictionary<string, Receipt>();
            pdgCreator.WriteToFile(dictionary, DateTime.Now);
           pdgCreator.WriteToExcel(dictionary, DateTime.Now);
        }
    }
}