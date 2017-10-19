using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace FiltersStudyApp.Models
{
    public class Visitor
    {
        public int Id { get; set; }
        public string Ip { get; set; }
        public string Url { get; set; }
        public DateTime Date { get; set; }
    }

    public class LogContext : DbContext
    {
        public DbSet<Visitor> Visitors { get; set; }
    }
}