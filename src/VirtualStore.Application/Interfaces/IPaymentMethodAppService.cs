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
    public interface IPaymentMethodAppService
    {
        PaymentMethodViewModel GetById(Guid Id);

        IEnumerable<PaymentMethodViewModel> Search(Expression<Func<PaymentMethod, bool>> predicate);
        IEnumerable<PaymentMethodViewModel> Search(Expression<Func<PaymentMethod, bool>> predicate,
            int pageNumber,
            int pageSize);

        PaymentMethodViewModel Add(PaymentMethodViewModel entity);
        PaymentMethodViewModel Update(PaymentMethodViewModel entity);
        void Remove(Guid Id);
        void Remove(Expression<Func<PaymentMethod, bool>> predicate);
    }
}
