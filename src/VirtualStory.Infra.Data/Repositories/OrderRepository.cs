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
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(VirtualStoreDbContext context) : base(context)
        {
        }

        public Order Add(Order entity)
        {
            DbSet.Add(entity);
            return entity;
        }

        public Order GetById(Guid Id)
        {
            var DbTable = DbSet.AsQueryable();
            var order = DbTable.FirstOrDefault(x => x.Id == Id);
            return order;
        }

        public void Remove(Guid Id)
        {
            var obj = GetById(Id);
            if (obj != null)
            {
                DbSet.Remove(obj);
            }
        }

        public void Remove(Expression<Func<Order, bool>> predicate)
        {
            var dbTable = DbSet.AsQueryable();
            var orders = dbTable.Where(predicate);
            DbSet.RemoveRange(orders);
        }

        public IEnumerable<Order> Search(Expression<Func<Order, bool>> predicate)
        {
            var context = DbSet.AsQueryable();
            return context.Where(predicate).ToList();
        }

        public IEnumerable<Order> Search(Expression<Func<Order, bool>> predicate, int pageNumber, int pageSize)
        {
            var context = DbSet.AsQueryable();
            var result = context.Where(predicate).Skip((pageNumber - 1) * pageSize).Take(pageSize);
            return result;
        }

        public Order Update(Order entity)
        {
            DbSet.Update(entity);
            return entity;
        }
    }
}
