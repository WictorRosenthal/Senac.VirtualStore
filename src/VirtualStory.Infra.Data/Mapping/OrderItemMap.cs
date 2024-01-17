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
    public class OrderItemMap : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.ToTable("OrderItem");
            builder.Property(oi => oi.OrderId).IsRequired();
            builder.Property(oi => oi.ProductId).IsRequired();
            builder.Property(oi => oi.ProductName).IsRequired().HasMaxLength(30);
            builder.Property(oi => oi.Amount).IsRequired();
            builder.Property(oi => oi.UnitValue).HasPrecision(10 ,2).IsRequired();

            builder.HasOne(oi => oi.Order)
                .WithMany(o => o.Items)
                .HasForeignKey(oi => oi.OrderId)
                .HasConstraintName("fk_OrderItems_order")
                .IsRequired();
        }
    }
}
