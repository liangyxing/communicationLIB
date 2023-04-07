using ConfigDB.Entity;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigDB.DBContext
{
    public class SqlLiteDBContext:DbContext
    {
        public DbSet<DANodeInfoModel>  dANodeInfoModels { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connString = string.Format("Data Source={0}", "./DBFiles/test.db");
            optionsBuilder.UseSqlite(connString);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DANodeInfoModel>().ToTable("DANodeInfo").HasKey(x=>x.Id);
            base.OnModelCreating(modelBuilder);


        }
    }
}
