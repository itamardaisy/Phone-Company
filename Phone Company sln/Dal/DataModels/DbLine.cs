using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Models;

namespace Dal.DataModels
{
    public class DbLine
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey(nameof(Client))]
        public int ClientId { get; set; }

        public DbClient Client { get; set; }

        [Required]
        [ForeignKey(nameof(Package))]
        public int PackageId { get; set; }

        public DbPackage Package { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public string Number { get; set; }

        [Required]
        public bool Status { get; set; }
    }
}
