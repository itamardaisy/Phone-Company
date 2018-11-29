using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Exceptions
{
    public class DataProcedureException : Exception
    {
        public DataProcedureException(string message = "") : base(message) { }
    }
}
