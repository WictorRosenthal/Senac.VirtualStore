using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VirtualStore.Domain.Entities;
using VirtualStore.Domain.Interfaces;
using VirtualStore.Infra.Data.Context;

namespace VirtualStore.Infra.Data.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(VirtualStoreDbContext context) : base(context)
        {
        }

        public Product Add(Product entity)
        {
            DbSet.Add(entity);
            return entity;
        }

        public Product GetById(Guid Id)
        {
            var dbTable = DbSet.AsQueryable();
            var product = dbTable.FirstOrDefault(x => x.Id == Id);
            return product;
        }

        public void Remove(Guid id)
        {
            var obj = GetById(id);
            if(obj != null)
            {
                DbSet.Remove(obj);
            }
        }

        public void Remove(Expression<Func<Product, bool>> predicate)
        {
            var dbTable = DbSet.AsQueryable();
            var products = dbTable.Where(predicate);
            DbSet.RemoveRange(products);
        }

        public IEnumerable<Product> Search(Expression<Func<Product, bool>> predicate)
        {
            var context = DbSet.AsQueryable();
            return context.Where(predicate).ToList();
        }

        public IEnumerable<Product> Search(Expression<Func<Product, bool>> predicate, int pageNumber, int pageSize)
        {
            var context = DbSet.AsQueryable();
            var result = context.Where(predicate).Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);
            return result;
        }

        public Product Update(Product entity)
        {
            DbSet.Update(entity);
            return entity;
        }
    }
}
