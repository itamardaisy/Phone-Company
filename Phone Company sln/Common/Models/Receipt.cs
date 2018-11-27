using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    public class Receipt
    {
        private byte[] pdfReceiptFile;
        private ICollection<Payment> clientPayments;

        public ICollection<Payment> ClientPayments
        {
            get { return clientPayments; }
            set { clientPayments = value; }
        }

        public byte[] PdfReceiptFile
        {
            get { return pdfReceiptFile; }
            set { pdfReceiptFile = value; }
        }
    }
}
