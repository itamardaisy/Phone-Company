﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.DataModels
{
    public class DbCall
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey(nameof(Line))]
        public int LineId { get; set; }

        public DbLine Line { get; set; }

        [Required]
        public double Duration { get; set; }

        public DateTime CallDate { get; set; }

        [Required]
        public string DestinationNumber { get; set; }

        [Required]
        [DefaultValue(false)]
        public bool FamilyCall { get; set; }

        [Required]
        [DefaultValue(false)]
        public bool SelectedNumberCall { get; set; }
    }
}