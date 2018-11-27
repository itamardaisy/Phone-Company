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
    class Program
    {
        static void Main(string[] args)
        {
            List<person> persons = new List<person>();
            persons.Add(new person { Id = 1, num = 8 });
            persons.Add(new person { Id = 1, num = 8 });
            persons.Add(new person { Id = 1, num = 8 });
            persons.Add(new person { Id = 1, num = 8 });
            persons.Add(new person { Id = 1, num = 8 });
            persons.Add(new person { Id = 1, num = 8 });
            persons.Add(new person { Id = 1, num = 8 });
            persons.Add(new person { Id = 1, num = 8 });
            persons.Add(new person { Id = 1, num = 8 });

            string header = "<h1>Recipt Samerry</h1>";
            string tableRows = ""; 
            foreach (var item in persons)
            {
                tableRows += $"<tr><td>{item.Id}</td><td>{item.num}</td></tr>";
            }
            string Table =
             "<table>" +
                "<tr>" +
                    "<th>Date</th>" +
                    "<th>Total Payment</th>" +
                "</tr>" +
                $"{tableRows}"+
             "</table>";
            string style = "<style> table, th, td { border: 1px solid black; border - collapse: collapse; }</style>";
            string html = $"<!DOCTYPE html><html><head>{style}<title></title></head><body>{header}{Table}</body></html>";
            PdfDocument pdf = PdfGenerator.GeneratePdf(html, PageSize.Letter);
            pdf.Save(@"D:\Programming\Programming Works\Phone Company Github\Phone Company sln\ConsoleTest\Test.pdf");
        }
    }

    class person
    {
        public int Id { get; set; }
        public int num { get; set; }
    }
}
