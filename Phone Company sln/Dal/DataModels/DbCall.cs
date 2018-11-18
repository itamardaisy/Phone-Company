using System;
using System.Collections.Generic;
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
        //   [MaxLength(30, ErrorMessage = "Cannot be more the 30 chars")]
        public double Duration { get; set; }

        [Required]
        public string DestinationNumber { get; set; }
    }
}