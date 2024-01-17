using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualStore.Domain.Entities;

namespace VirtualStore.Infra.Data.Mapping
{
    public class BuyerMap : IEntityTypeConfiguration<Buyer>
    {
        
        public void Configure(EntityTypeBuilder<Buyer> builder)
        {
            builder.ToTable("Buyer");
            builder.Property(b => b.Name).HasMaxLength(100).IsRequired();
            builder.Property(b => b.Surname).HasMaxLength(100).IsRequired();
            builder.Property(b => b.Email).HasMaxLength(100);
            builder.Property(b => b.AddressId).IsRequired();
            builder.Property(b => b.Phone).HasMaxLength(15);
            builder.Property(b => b.Document).HasMaxLength(20);
            builder.Property(b => b.Gender).HasMaxLength(1);
        }
    }
}
