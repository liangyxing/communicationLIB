using Microsoft.EntityFrameworkCore;
using OPCDA.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigDB.DBContext
{
    public class SqlLiteDBContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DANodeInfo>().ToTable("DANodeInfo");
            base.OnModelCreating(modelBuilder);
        }
    }
}
