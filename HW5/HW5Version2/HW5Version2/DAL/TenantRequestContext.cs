using HW5Version2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HW5Version2.DAL
{
    public class TenantRequestContext : DbContext
    {
        public TenantRequestContext() : base("name=RequestDB")
        {

        }

        public virtual DbSet<Request> Requests { get; set; }
    }
}