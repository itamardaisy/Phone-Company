using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.DataModels
{
    public class DbClientType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string TypeName { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public double MinutePrice { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public double SMSPrice { get; set; }
    }
}
