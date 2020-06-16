using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagement.Models
{
    public class Branch
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter Branch Location name.")]
        [DataType(DataType.Text)]
        [Display(Name = "Location")]
        public string Location { get; set; }

        [Range(25,70, ErrorMessage = "Please provide an age between 25 and 70.")]
        public int OwnerAge { get; set; }

        [Required]
        [Display(Name = "Years of Operation")]
        public double YearsOfOperation { get; set; }

        [DataType(DataType.PhoneNumber, ErrorMessage = "Please provide a valid phone number")]
        [Phone(ErrorMessage ="Not a valid phone number")]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }


        // Relations
        public virtual Store Store { get; set; }
        [Display(Name = "Store Name")]
        public int StoreId { get; set; }

        public List<Employee> Emp { get; set; }

    }
}


