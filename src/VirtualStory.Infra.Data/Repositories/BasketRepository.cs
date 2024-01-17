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
    public class BasketRepository : Repository<Basket>, IBasketRepository
    {
        public BasketRepository(VirtualStoreDbContext context) : base(context)
        {
        }


        public Basket Add(Basket entity)
        {
            DbSet.Add(entity);
            return entity;
        }


        public Basket GetById(Guid Id)
        {
            var DbTable = DbSet.AsQueryable();
            var basket = DbTable.FirstOrDefault(x => x.Id == Id);
            return basket;
        }


        public void Remove(Guid Id)
        {
            var obj = GetById(Id);
            if (obj != null)
            {
                DbSet.Remove(obj);
            }
        }


        public void Remove(Expression<Func<Basket, bool>> predicate)
        {
            var dbTable = DbSet.AsQueryable();
            var baskets = dbTable.Where(predicate);
            DbSet.RemoveRange(baskets);
        }


        public IEnumerable<Basket> Search(Expression<Func<Basket, bool>> predicate)
        {
            var context = DbSet.AsQueryable();
            return context.Where(predicate).ToList();
        }


        public IEnumerable<Basket> Search(Expression<Func<Basket, bool>> predicate, int pageNumber, int pageSize)
        {
            var context = DbSet.AsQueryable();
            var result = context.Where(predicate).Skip((pageNumber - 1) * pageSize).Take(pageSize);
            return result;
        }


        public Basket Update(Basket entity)
        {
            DbSet.Update(entity);
            return entity;
        }
    }
}
