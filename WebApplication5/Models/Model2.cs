using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WebApplication5.Models
{
    public partial class Model2 : DbContext
    {
        public Model2()
            : base("name=Model2")
        {
        }

        public virtual DbSet<CUSTOMERS> CUSTOMERS { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CUSTOMERS>()
                .Property(e => e.CUSTOMERNAME)
                .IsUnicode(false);

            modelBuilder.Entity<CUSTOMERS>()
                .Property(e => e.GENDER)
                .IsUnicode(false);


        }
    }
}
