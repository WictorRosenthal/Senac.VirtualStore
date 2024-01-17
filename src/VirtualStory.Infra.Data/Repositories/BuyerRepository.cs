using Microsoft.EntityFrameworkCore;
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
    public class BuyerRepository : Repository<Buyer>, IBuyerRepository
    {
        public BuyerRepository(VirtualStoreDbContext context) : base(context)
        {
        }

        public Buyer Add(Buyer entity)
        {
            DbSet.Add(entity);
            return entity;
        }

        public Buyer GetById(Guid Id)
        {
            var DbTable = DbSet.AsQueryable();
            var product = DbTable.FirstOrDefault(x => x.Id == Id);
            return product;
        }

        public void Remove(Guid Id)
        {
            var obj = GetById(Id);
            if (obj != null)
            {
                DbSet.Remove(obj);
            }
        }

        public void Remove(Expression<Func<Buyer, bool>> predicate)
        {
            var dbTable = DbSet.AsQueryable();
            var buyers = dbTable.Where(predicate);
            DbSet.RemoveRange(buyers);
        }

        public IEnumerable<Buyer> Search(Expression<Func<Buyer, bool>> predicate)
        {
            var context = DbSet.AsQueryable();
            return context.Where(predicate).ToList();
        }

        public IEnumerable<Buyer> Search(Expression<Func<Buyer, bool>> predicate, int pageNumber, int pageSize)
        {
            var context = DbSet.AsQueryable();
            var result = context.Where(predicate).Skip((pageNumber - 1) * pageSize).Take(pageSize);
            return result;
        }

        public Buyer Update(Buyer entity)
        {
            DbSet.Update(entity);
            return entity;
        }
    }
}
