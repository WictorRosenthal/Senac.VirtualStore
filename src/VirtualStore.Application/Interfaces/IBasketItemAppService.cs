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
    public interface IBasketItemAppService
    {
        BasketItemViewModel GetById(Guid Id);

        IEnumerable<BasketItemViewModel> Search(Expression<Func<BasketItem, bool>> predicate);
        IEnumerable<BasketItemViewModel> Search(Expression<Func<BasketItem, bool>> predicate,
            int pageNumber,
            int pageSize);

        BasketItemViewModel Add(BasketItemViewModel entity);
        BasketItemViewModel Update(BasketItemViewModel entity);
        void Remove(Guid Id);
        void Remove(Expression<Func<BasketItem, bool>> predicate);
    }
}
