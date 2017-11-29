using System;
using System.ComponentModel.DataAnnotations;
namespace ContactList.Models
{
    public class Person
    {
        [Required]
        [Key]
        public int id { get; set; }
        [Display(Name = "Vorname")]
        [StringLength(50)]
        public String firstName { get; set; }

        [Display(Name = "Vorname")]
        [StringLength(50)]
        public String lastName { get; set; }

        [Display(Name ="Email")]
        [Required]
        [StringLength(50)]
        public String email { get; set; }


    }
}
