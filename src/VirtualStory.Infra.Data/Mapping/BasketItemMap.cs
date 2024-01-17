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
    public class BasketItemMap : IEntityTypeConfiguration<BasketItem>
    {
        public void Configure(EntityTypeBuilder<BasketItem> builder)
        {
            builder.ToTable("BasketItem");

            builder.Property(b => b.UnitPrice).IsRequired().HasPrecision(10, 2);
            builder.Property(b => b.Quantity).IsRequired().HasDefaultValue(1);
            builder.Property(b => b.ProductId).IsRequired();

            builder.HasOne(bi => bi.Basket) //Para um carrinho
                .WithMany(b => b.Items)     //Haverá vários itens (Itens da tabela Basket)
                .HasForeignKey(bi => bi.BasketId) //A Chave estrangeira na tabela de itens o campo BasketId
                .HasConstraintName("fk_basketItems_basket") //O nome da chave estrangeira será essa
                .IsRequired();
        }
    }
}
