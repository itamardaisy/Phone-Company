﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.DataModels
{
    public class DbSelectedNumber
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public string FirstNumber { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public string SecondNumber { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public string ThirdNumber { get; set; }
    }
}
