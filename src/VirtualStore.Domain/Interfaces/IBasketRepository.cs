using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VirtualStore.Domain.Entities;

namespace VirtualStore.Domain.Interfaces
{
    public interface IBasketRepository
    {
        
        Basket GetById(Guid Id);
        
        IEnumerable<Basket> Search(Expression<Func<Basket, bool>> predicate);
       
        IEnumerable<Basket> Search(Expression<Func<Basket, bool>> predicate,
            int pageNumber,
            int pageSize);
        
        Basket Add(Basket entity);
        
        Basket Update(Basket entity);
        
        void Remove(Guid Id);
        
        void Remove(Expression<Func<Basket, bool>> predicate);
    }
}
