using Capgemini.TestDev.Domain.Configuration;
using Capgemini.TestDev.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capgemini.TestDev.Data.Context
{
    public class TestDevContext : DbContext 
    {
        public TestDevContext()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=MyDatabase.db");
        }
        public TestDevContext(DbContextOptions<TestDevContext> options) : base(options)
        {

        }

        #region DbSet
        public DbSet<CustomerCard> CustomerCard { get; set; }

        #endregion
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerCardConfiguration());
            base.OnModelCreating(modelBuilder);
        }

    }
}
