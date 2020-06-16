using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagement.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required (ErrorMessage = "Please provide full name!")]
        [StringLength (30, ErrorMessage = "Full name is too long.")]
        [Display(Name = "Full name")]
        public string FullName { get; set; }

        [Display(Name = "Nick name")]
        public string NickName { get; set; }

        [Display(Name = "Role")]
        public string Role { get; set; }

        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        [Display(Name = "Email address")]
        public string EmailAddress { get; set; }

        [Range(15,55, ErrorMessage = "Age should be between 15 and 55")]
        public int Age { get; set; }

        public DateTime Birthday { get; set; }

        //Relations
        public virtual Branch Branch { get; set; }
        [Display(Name = "Branch Name")]
        public int BranchId { get; set; }

    }
}
