using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Job_Portal.Models
{
    public class JobContext : DbContext
    {
        public virtual DbSet<ContactForAnyQuery> ContactForAnyQuery { get; set; }
    }
}