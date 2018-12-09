using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.ClientWebPage.Models
{
    public class DetailsModel
    {
        public List<Package> RecommendedPackages { get; set; }
        public Client CurrentClient { get; set; }
        public List<string> ClientLines { get; set; }
        public List<SelectListItem> lineList { get; set; }
        public List<SelectListItem> LineList(List<string> ClientLines)
        {
            lineList = new List<SelectListItem>();
            foreach (var item in ClientLines)
                lineList.Add(new SelectListItem { Text = item, Value = item, Selected = false });
            return lineList;
        }
        public string ChosenLine { get; set; }
        public double TotalMinuts { get; set; }
        public int TotalSMS { get; set; }
        public double TotalMinutesTopNumber { get; set; }
        public double TotalMinutesThreeTopNumber { get; set; }
        public double TotalMinutesFamily { get; set; }
    }
}