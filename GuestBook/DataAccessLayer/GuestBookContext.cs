using GuestBook.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GuestBook.DataAccessLayer
{
    public class GuestBookContext : DbContext
    {
        public GuestBookContext() : base("GB") { }

        public DbSet<Record> Records { get; set; }
    }
}