using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebService.Models
{
    public class DataContext : DbContext
    {
        public DataContext() : base("name=DataContext")
        {

        }

        public System.Data.Entity.DbSet<DataItem> Items { get; set; }
    }
}