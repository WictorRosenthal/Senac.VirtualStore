using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VirtualStore.Domain.Entities;

namespace VirtualStore.Domain.Interfaces
{
    public interface IBuyerRepository
    {
        
        Buyer GetById(Guid Id);
        
        IEnumerable<Buyer> Search(Expression<Func<Buyer, bool>> predicate);
        
        IEnumerable<Buyer> Search(Expression<Func<Buyer, bool>> predicate,
            int pageNumber,
            int pageSize);
       
        Buyer Add(Buyer entity);
        
        Buyer Update(Buyer entity);
        
        void Remove(Guid Id);
        
        void Remove(Expression<Func<Buyer, bool>> predicate);
    }
}
