﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Models;

namespace Common.Interfaces.Repository_interfaces
{
    public  interface IEmployeeRepository
    {
        User EmployeeLogin(string name, string password);
    }
}
