using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public virtual DbClientType ClientType { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [RegularExpression("([a-z A-Z]{5,20})~([a-z A-Z]{5,20})~([0-9/]{1,3})~([0-9A-Z]{1,3})")] //cityName Street 6/3A
        public string Adress { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public string ContactNumber { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime SignDate { get; set; }

        [Required(AllowEmptyStrings = true)]
        public int CallToCenter { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }

        public virtual DbUser User { get; set; }
    }
}
