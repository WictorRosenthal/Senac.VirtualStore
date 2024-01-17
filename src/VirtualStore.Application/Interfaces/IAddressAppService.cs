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
    public interface IAddressAppService
    {
        AddressViewModel GetById(Guid Id);

        IEnumerable<AddressViewModel> Search(Expression<Func<Address, bool>> predicate);
        IEnumerable<AddressViewModel> Search(Expression<Func<Address, bool>> predicate,
            int pageNumber,
            int pageSize);

        AddressViewModel Add(AddressViewModel entity);
        AddressViewModel Update(AddressViewModel entity);
        void Remove(Guid Id);
        void Remove(Expression<Func<Address, bool>> predicate);
    }
}
