using Common.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces
{
    public interface IPdfCreator
    {
        byte[] PdfFile { get; set; }

        void WriteToFile(Dictionary<string, Receipt> payments, DateTime time);
    }
}