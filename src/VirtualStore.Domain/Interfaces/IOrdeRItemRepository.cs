using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VirtualStore.Domain.Entities;

namespace VirtualStore.Domain.Interfaces
{
    public interface IOrderItemRepository
    {
        
        OrderItem GetById(Guid Id);
        
        IEnumerable<OrderItem> Search(Expression<Func<OrderItem, bool>> predicate);
        
        IEnumerable<OrderItem> Search(Expression<Func<OrderItem, bool>> predicate,
            int pageNumber,
            int pageSize);
        
        OrderItem Add(OrderItem entity);
        
        OrderItem Update(OrderItem entity);
        
        void Remove(Guid Id);
        
        void Remove(Expression<Func<OrderItem, bool>> predicate);
    }
}
