using Capgemini.TestDev.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capgemini.TestDev.Domain.Configuration
{
    public class CustomerCardConfiguration : IEntityTypeConfiguration<CustomerCard>
    {
        public void Configure(EntityTypeBuilder<CustomerCard> modelBuilder)
        {
            modelBuilder
                .HasKey(a => a.CardId);

            modelBuilder.Property(a => a.CardNumber);
            modelBuilder.Property(a => a.CustomerId);
            modelBuilder.Property(a => a.Token);
            modelBuilder.Property(a => a.DateCreation);

            modelBuilder
                .HasIndex(a => a.CardId)
                .IsUnique();

            modelBuilder
                .HasIndex(a => a.Token);
        }
    }
}
