using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VirtualStore.Domain.Entities;

namespace VirtualStore.Domain.Interfaces
{
    public interface IPaymentMethodRepository
    {
        
        PaymentMethod GetById(Guid Id);
       
        IEnumerable<PaymentMethod> Search(Expression<Func<PaymentMethod, bool>> predicate);
        
        IEnumerable<PaymentMethod> Search(Expression<Func<PaymentMethod, bool>> predicate,
            int pageNumber,
            int pageSize);
        
        PaymentMethod Add(PaymentMethod entity);
        
        PaymentMethod Update(PaymentMethod entity);
        
        void Remove(Guid Id);
        
        void Remove(Expression<Func<PaymentMethod, bool>> predicate);
    }
}
