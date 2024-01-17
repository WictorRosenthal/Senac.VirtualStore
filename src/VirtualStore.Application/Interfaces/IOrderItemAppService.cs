using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VirtualStore.Application.ViewModel;
using VirtualStore.Domain.Entities;

namespace VirtualStore.Application.Interfaces
{
    public interface IOrderItemAppService
    {
        OrderItemViewModel GetById(Guid Id);

        IEnumerable<OrderItemViewModel> Search(Expression<Func<OrderItem, bool>> predicate);
        IEnumerable<OrderItemViewModel> Search(Expression<Func<OrderItem, bool>> predicate,
            int pageNumber,
            int pageSize);

        OrderItemViewModel Add(OrderItemViewModel entity);
        OrderItemViewModel Update(OrderItemViewModel entity);
        void Remove(Guid Id);
        void Remove(Expression<Func<OrderItem, bool>> predicate);
    }
}
