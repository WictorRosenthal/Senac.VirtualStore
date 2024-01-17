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
    public interface IProductAppService
    {
        ProductViewModel GetById(Guid Id);

        IEnumerable<ProductViewModel> Search(Expression<Func<Product, bool>> predicate);
        IEnumerable<ProductViewModel> Search(Expression<Func<Product, bool>> predicate,
            int pageNumber,
            int pageSize);

        ProductViewModel Add(ProductViewModel entity);
        ProductViewModel Update(ProductViewModel entity);
        void Remove (Guid Id);
        void Remove (Expression<Func<Product, bool>> predicate);
 
    }
}
