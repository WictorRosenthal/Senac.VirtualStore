﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VirtualStore.Domain.Entities;

namespace VirtualStore.Domain.Interfaces
{
    public interface IBasketItemRepository
    {
        
        BasketItem GetById(Guid Id);
        
        IEnumerable<BasketItem> Search(Expression<Func<BasketItem, bool>> predicate);
        
        IEnumerable<BasketItem> Search(Expression<Func<BasketItem, bool>> predicate,
            int pageNumber,
            int pageSize);
        
        BasketItem Add(BasketItem entity);
        
        BasketItem Update(BasketItem entity);
        
        void Remove(Guid Id);
        
        void Remove(Expression<Func<BasketItem, bool>> predicate);
    }
}
