using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UI.Employee.Models;

namespace UI.Employee.Helper
{
    internal class HelperClass: EventArgs
    {
        public Client ClientEvent { get; set; }

        public HelperClass(Client client)
        {
            ClientEvent = client;
        }

        public Client GetClient()
        {
            return ClientEvent;
        }
    }
}
