using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    public class Package
    {
        private int id;
        private string packageName;
        private double totalPrice;
        private int maxMinute;
        private double fixedPrice;
        private int disscountPrecentage;
        private bool mostCallNumber;
        private bool insideFamilyCall;
        private bool selectedNumber;
        private int maxSMSs;

        public int MaxSMSs
        {
            get { return maxSMSs; }
            set { maxSMSs = value; }
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string PackageName
        {
            get { return packageName; }
            set { packageName = value; }
        }

        public double TotalPrice
        {
            get { return totalPrice; }
            set { totalPrice = value; }
        }

        public int MaxMinute
        {
            get { return maxMinute; }
            set { maxMinute = value; }
        }

        public double FixedPrice
        {
            get { return fixedPrice; }
            set { fixedPrice = value; }
        }

        public int DisscountPrecentage
        {
            get { return disscountPrecentage; }
            set { disscountPrecentage = value; }
        }

        public bool MostCallNumber
        {
            get { return mostCallNumber; }
            set { mostCallNumber = value; }
        }

        public bool InsideFamilyCall
        {
            get { return insideFamilyCall; }
            set { insideFamilyCall = value; }
        }
              
        public bool SelectedNumber
        {
            get { return selectedNumber; }
            set { selectedNumber = value; }
        }
    }
}