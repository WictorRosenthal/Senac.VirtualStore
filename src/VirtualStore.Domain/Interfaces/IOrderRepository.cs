using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VirtualStore.Domain.Entities;

namespace VirtualStore.Domain.Interfaces
{
    public interface IOrderRepository
    {
        
        Order GetById(Guid Id);
        
        IEnumerable<Order> Search(Expression<Func<Order, bool>> predicate);
        
        IEnumerable<Order> Search(Expression<Func<Order, bool>> predicate,
            int pageNumber,
            int pageSize);
        
        Order Add(Order entity);
        
        Order Update(Order entity);
        
        void Remove(Guid Id);
        
        void Remove(Expression<Func<Order, bool>> predicate);
    }
}
