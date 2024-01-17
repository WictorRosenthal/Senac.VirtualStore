using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualStore.Infra.Data.Mapping;

namespace VirtualStore.Infra.Data.Context
{
    public class VirtualStoreDbContext : DbContext
    {
        public VirtualStoreDbContext(DbContextOptions<VirtualStoreDbContext> options) :
            base(options) 
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AddressMap());
            modelBuilder.ApplyConfiguration(new BasketItemMap());
            modelBuilder.ApplyConfiguration(new BasketMap());
            modelBuilder.ApplyConfiguration(new BuyerMap());
            modelBuilder.ApplyConfiguration(new OrderItemMap());
            modelBuilder.ApplyConfiguration(new OrderMap());
            modelBuilder.ApplyConfiguration(new PaymentMethodMap());
            modelBuilder.ApplyConfiguration(new ProductMap());
            modelBuilder.ApplyConfiguration(new ProductBrandMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
