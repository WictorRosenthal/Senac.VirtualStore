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
    public class ProductBrandRepository : Repository<ProductBrand>, IProductBrandRepository
    {
        public ProductBrandRepository(VirtualStoreDbContext context) : base(context)
        {
        }

        public ProductBrand Add(ProductBrand entity)
        {
            DbSet.Add(entity);
            return entity;
        }

        public ProductBrand GetById(Guid Id)
        {
            var DbTable = DbSet.AsQueryable();
            var productBrand = DbTable.FirstOrDefault(x => x.Id == Id);
            return productBrand;
        }

        public void Remove(Guid Id)
        {
            var obj = GetById(Id);
            if (obj != null)
            {
                DbSet.Remove(obj);
            }
        }

        public void Remove(Expression<Func<ProductBrand, bool>> predicate)
        {
            var dbTable = DbSet.AsQueryable();
            var productBrands = dbTable.Where(predicate);
            DbSet.RemoveRange(productBrands);
        }

        public IEnumerable<ProductBrand> Search(Expression<Func<ProductBrand, bool>> predicate)
        {
            var context = DbSet.AsQueryable();
            return context.Where(predicate).ToList();
        }

        public IEnumerable<ProductBrand> Search(Expression<Func<ProductBrand, bool>> predicate, int pageNumber, int pageSize)
        {
            var context = DbSet.AsQueryable();
            var result = context.Where(predicate).Skip((pageNumber - 1) * pageSize).Take(pageSize);
            return result;
        }

        public ProductBrand Update(ProductBrand entity)
        {
            DbSet.Update(entity);
            return entity;
        }
    }
}
