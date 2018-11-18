using Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.DataModels
{
    public class DbUser
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DefaultValue(0)]
        public int CallAnswer { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime SignDate { get; set; }

        [Required]
        [DefaultValue(2)]
        public UserType Type { get; set; }
    }
}
