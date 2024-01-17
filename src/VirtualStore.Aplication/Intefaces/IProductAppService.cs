using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VirtualStore.Aplication.ViewMode1;
using VirtualStore.Domain.Entities;

namespace VirtualStore.Aplication.Intefaces
{
    public interface IProductAppService
    {
        ProductViewModel GetById(Guid Id);
        IEnumerable<ProductViewModel> Search(Expression<Func<Product, bool>> Predicate);
        IEnumerable<ProductViewModel> Search(Expression<Func<Product, bool>> predicate,
            int PageNumber,
            int PageSize);
        ProductViewModel Add (ProductViewModel entity);
        ProductViewModel Update (ProductViewModel entity);
        void Remove (Guid Id);
        void Remove (Expression<Func<Product, bool>> Predicate);
    }
}
