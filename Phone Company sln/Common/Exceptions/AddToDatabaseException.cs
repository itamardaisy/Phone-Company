﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Exceptions
{
    public class AddToDatabaseException : Exception
    {


        public AddToDatabaseException(string message = "") : base(message) { }
    }
}
