using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    public class Line
    {
        private int id;
        private string number;
        private bool status;
        private int packageId;
        private int clientId;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Number
        {
            get { return number; }
            set { number = value; }
        }

        public bool Status
        {
            get { return status; }
            set { status = value; }
        }

        public int PackageId
        {
            get { return packageId; }
            set { packageId = value; }
        }

        public int ClientId
        {
            get { return clientId; }
            set { clientId = value; }
        }
    }
}
