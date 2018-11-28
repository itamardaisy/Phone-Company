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
            try
            {
                Console.WriteLine("hello world");
                try { throw new Exception("kuku"); }
                catch(Exception e) { Console.WriteLine(e.Message); throw new Exception("kaka"); }
                
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception();
            }
            Console.Read();
        }
    }
}
