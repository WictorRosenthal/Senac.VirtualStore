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
    public interface IProductBrandAppService
    {
        ProductBrandViewModel GetById(Guid Id);

        IEnumerable<ProductBrandViewModel> Search(Expression<Func<ProductBrand, bool>> predicate);
        IEnumerable<ProductBrandViewModel> Search(Expression<Func<ProductBrand, bool>> predicate,
            int pageNumber,
            int pageSize);

        ProductBrandViewModel Add(ProductBrandViewModel entity);
        ProductBrandViewModel Update(ProductBrandViewModel entity);
        void Remove(Guid Id);
        void Remove(Expression<Func<ProductBrand, bool>> predicate);
    }
}
