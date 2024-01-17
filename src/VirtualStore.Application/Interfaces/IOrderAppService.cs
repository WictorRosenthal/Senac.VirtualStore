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
    public interface IOrderAppService
    {
        OrderViewModel GetById(Guid Id);

        IEnumerable<OrderViewModel> Search(Expression<Func<Order, bool>> predicate);
        IEnumerable<OrderViewModel> Search(Expression<Func<Order, bool>> predicate,
            int pageNumber,
            int pageSize);

        OrderViewModel Add(OrderViewModel entity);
        OrderViewModel Update(OrderViewModel entity);
        void Remove(Guid Id);
        void Remove(Expression<Func<Order, bool>> predicate);
    }
}
