using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Job_Portal.Models
{
    [Table("ContactForAnyQuery")]
    public class ContactForAnyQuery
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public int? Mobile { get; set; }
    }
}