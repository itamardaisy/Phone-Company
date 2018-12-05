using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.DataModels
{
    public class DbPackage
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public bool SelectedNumberId { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string PackageName { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public double TotalPrice { get; set; }

        [Required]
        public int MaxMinute { get; set; }

        [Required]
        public int MaxSMSs { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public double FixedPrice { get; set; }

        [Required]
        public int DisscountPrecentage { get; set; }

        [Required]
        [DefaultValue(false)]
        public bool MostCallNumber { get; set; }

        [Required]
        [DefaultValue(false)]
        public bool InsideFamilyCall { get; set; }
    }
}
