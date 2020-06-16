using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagement.Models
{
    public class Store
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Hey, please provide a name!")]
        [StringLength(20, ErrorMessage = "The name is too long.")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Hey, please provide an address!")]
        public string Address { get; set; }
        [Display(Name = "Founding year")]
        public DateTime FoundingYear { get; set; }
        [Display(Name = "Number of Branch")]
        public int NumberOfEmployees { get; set; }

        //Relations
        public List<Branch> Branches { get; set; }

    }
}
