﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI.ClientWebPage.Models
{
    public class LoginClient
    {
        public int ClientId { get; set; }
        public string PhoneNumber { get; set; }
        public string Name { get; internal set; }
    }
}