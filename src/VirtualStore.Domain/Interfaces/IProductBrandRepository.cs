using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VirtualStore.Domain.Entities;

namespace VirtualStore.Domain.Interfaces
{
    public interface IProductBrandRepository
    {
        ProductBrand GetById(Guid Id);
        
        IEnumerable<ProductBrand> Search(Expression<Func<ProductBrand, bool>> predicate);
        
        IEnumerable<ProductBrand> Search(Expression<Func<ProductBrand, bool>> predicate,
            int pageNumber,
            int pageSize);
       
        ProductBrand Add(ProductBrand entity);
        
        ProductBrand Update(ProductBrand entity);
       
        void Remove(Guid Id);
        
        void Remove(Expression<Func<ProductBrand, bool>> predicate);
    }
}
