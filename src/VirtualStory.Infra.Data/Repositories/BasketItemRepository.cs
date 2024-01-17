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
    public class BasketItemRepository : Repository<BasketItem>, IBasketItemRepository
    {
        public BasketItemRepository(VirtualStoreDbContext context) : base(context)
        {
        }

        public BasketItem Add(BasketItem entity)
        {
            DbSet.Add(entity);
            return entity;
        }

        public BasketItem GetById(Guid Id)
        {
            var DbTable = DbSet.AsQueryable();
            var basketitem = DbTable.FirstOrDefault(x => x.Id == Id);
            return basketitem;
        }

        public void Remove(Guid Id)
        {
            var obj = GetById(Id);
            if (obj != null)
            {
                DbSet.Remove(obj);
            }
        }

        public void Remove(Expression<Func<BasketItem, bool>> predicate)
        {
            var dbTable = DbSet.AsQueryable();
            var BasketItems = dbTable.Where(predicate);
            DbSet.RemoveRange(BasketItems);
        }

        public IEnumerable<BasketItem> Search(Expression<Func<BasketItem, bool>> predicate)
        {
            var context = DbSet.AsQueryable();
            return context.Where(predicate).ToList();
        }

        public IEnumerable<BasketItem> Search(Expression<Func<BasketItem, bool>> predicate, int pageNumber, int pageSize)
        {
            var context = DbSet.AsQueryable();
            var result = context.Where(predicate).Skip((pageNumber - 1) * pageSize).Take(pageSize);
            return result;
        }

        public BasketItem Update(BasketItem entity)
        {
            DbSet.Update(entity);
            return entity;
        }
    }
}
