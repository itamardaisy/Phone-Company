﻿using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.UI.Client.Models
{
    public class DetailsModel
    {
        public List<Package> RecommendedPackages { get; set; }
        public Common.Models.Client CurrentClient { get; set; }
        public string LineNumber { get; set; }
    }
}