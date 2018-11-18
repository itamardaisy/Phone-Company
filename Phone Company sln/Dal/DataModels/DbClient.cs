using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.DataModels
{
    public class DbClient
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string LastName { get; set; }

        [Required]
        [ForeignKey(nameof(ClientType))]
        public int ClientTypeId { get; set; }

        public DbClientType ClientType { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Adress { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public string ContactNumber { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime SignDate { get; set; }

        [Required(AllowEmptyStrings = true)]
        public int CallToCenter { get; set; }
    }
}
