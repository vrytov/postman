using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Postman.Models
{
    public class MessageContext : DbContext
    {
        private static bool _created = false;

        public MessageContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionbuilder)
        {
            optionbuilder.UseSqlite(@"Data Source=data.db");
        }

        public DbSet<Entities.Message> Messages { get; set; }
    }
}
