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
    public interface IBuyerAppService
    {
        BuyerViewModel GetById(Guid Id);

        IEnumerable<BuyerViewModel> Search(Expression<Func<Buyer, bool>> predicate);
        IEnumerable<BuyerViewModel> Search(Expression<Func<Buyer, bool>> predicate,
            int pageNumber,
            int pageSize);

        BuyerViewModel Add(BuyerViewModel entity);
        BuyerViewModel Update(BuyerViewModel entity);
        void Remove(Guid Id);
        void Remove(Expression<Func<Buyer, bool>> predicate);
    }
}
