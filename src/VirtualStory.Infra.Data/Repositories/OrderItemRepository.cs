using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VirtualStore.Domain.Entities;
using VirtualStore.Domain.Interfaces;
using VirtualStory.Infra.Data.Context;

namespace VirtualStory.Infra.Data.Repositories
{
    public class OrderItemRepository : Repository<OrderItem>, IOrderItemRepository
    {
        public OrderItemRepository(VirtualStoreDbContext context) : base(context)
        {
        }

        public OrderItem Add(OrderItem entity)
        {
            DbSet.Add(entity);
            return entity;
        }

        public OrderItem GetById(Guid Id)
        {
            var DbTable = DbSet.AsQueryable();
            var orderItem = DbTable.FirstOrDefault(x => x.Id == Id);
            return orderItem;
        }

        public void Remove(Guid Id)
        {
            var obj = GetById(Id);
            if (obj != null)
            {
                DbSet.Remove(obj);
            }
        }

        public void Remove(Expression<Func<OrderItem, bool>> predicate)
        {
            var dbTable = DbSet.AsQueryable();
            var orderItems = dbTable.Where(predicate);
            DbSet.RemoveRange(orderItems);
        }

        public IEnumerable<OrderItem> Search(Expression<Func<OrderItem, bool>> predicate)
        {
            var context = DbSet.AsQueryable();
            return context.Where(predicate).ToList();
        }

        public IEnumerable<OrderItem> Search(Expression<Func<OrderItem, bool>> predicate, int pageNumber, int pageSize)
        {
            var context = DbSet.AsQueryable();
            var result = context.Where(predicate).Skip((pageNumber - 1) * pageSize).Take(pageSize);
            return result;
        }

        public OrderItem Update(OrderItem entity)
        {
            DbSet.Update(entity);
            return entity;
        }
    }
}
