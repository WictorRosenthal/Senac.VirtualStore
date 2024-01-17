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
    public interface IBasketAppService
    {
        BasketViewModel GetById(Guid Id);

        IEnumerable<BasketViewModel> Search(Expression<Func<Basket, bool>> predicate);
        IEnumerable<BasketViewModel> Search(Expression<Func<Basket, bool>> predicate,
            int pageNumber,
            int pageSize);

        BasketViewModel Add(BasketViewModel entity);
        BasketViewModel Update(BasketViewModel entity);
        void Remove(Guid Id);
        void Remove(Expression<Func<Basket, bool>> predicate);
    }
}
