using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PostCodeLookUpAPI.Models
{
    public class UserData
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Postcode { get; set; }
        [Required]
        public string User { get; set; }
        [Required]
        public DateTime EnteredDateTime { get; set; }
    }
}
