using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualStore.Domain.Entities;

namespace VirtualStory.Infra.Data.Mapping
{
    public class BuyerMap : IEntityTypeConfiguration<Buyer>
    {
        public void Configure(EntityTypeBuilder<Buyer> builder)
        {
            builder.ToTable("Buyer");

            builder.Property(bu => bu.Name).HasMaxLength(30).IsRequired();
            builder.Property(bu => bu.Surname).HasMaxLength(40).IsRequired();
            builder.Property(bu => bu.Email).HasMaxLength(50);
            builder.Property(bu => bu.AddressId).IsRequired();
            builder.Property(bu => bu.Phone).HasMaxLength(14);
            builder.Property(bu => bu.Document).HasMaxLength(30).IsRequired();
            builder.Property(bu => bu.Gender).HasMaxLength(1);
     
        }
    }
}
