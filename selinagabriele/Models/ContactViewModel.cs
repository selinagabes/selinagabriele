using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace selinagabriele.Models
{
    public class ContactViewModel
    {
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string Subject { get; set; }
        [Required]
        public string Message { get; set; }
    }
}