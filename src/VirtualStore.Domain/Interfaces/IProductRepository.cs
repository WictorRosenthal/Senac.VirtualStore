using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VirtualStore.Domain.Entities;

namespace VirtualStore.Domain.Interfaces
{
    public interface IProductRepository
    {
        
        Product GetById(Guid Id);
        
        IEnumerable<Product> Search(Expression<Func<Product, bool>> predicate);
        
        IEnumerable<Product> Search(Expression<Func<Product, bool>> predicate,
            int pageNumber,
            int pageSize);
        
        Product Add(Product entity);
        
        Product Update(Product entity);
        
        void Remove(Guid Id);
        
        void Remove(Expression<Func<Product, bool>> predicate);
    }
}
