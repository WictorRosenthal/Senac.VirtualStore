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
    public class BasketItemMap : IEntityTypeConfiguration<BasketItem>
    {
        public void Configure(EntityTypeBuilder<BasketItem> builder)
        {
            builder.ToTable("BasketItem");
            builder.Property(bi => bi.UnitPrice).IsRequired().HasPrecision(10, 2);
            builder.Property(bi => bi.Quantity).IsRequired().HasDefaultValue(1);
            builder.Property(bi => bi.ProductId).IsRequired();

            builder.HasOne(bi => bi.Basket) //Para um carrinho
                .WithMany(b => b.Items) //Havera varios items (Items da tabela Basket)
                .HasForeignKey(bi => bi.BasketId)  //A chave estrangeira na tabela Items no campo BasketId
                .HasConstraintName("fk_basketItems_basket")  // O nome da chave estrangeira
                .IsRequired();  // E um campo obrigatorio

        }

       
    }
}
