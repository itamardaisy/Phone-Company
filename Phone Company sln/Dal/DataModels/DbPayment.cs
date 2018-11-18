using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.DataModels
{
    public class DbPayment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey(nameof(Client))]
        public int ClientId { get; set; }

        public DbClient Client { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Month { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public double TotalPayment { get; set; }
    }
}
