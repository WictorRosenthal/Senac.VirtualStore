using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VirtualStore.Domain.Entities;
using VirtualStore.Domain.Interfaces;
using VirtualStory.Infra.Data.Context;

namespace VirtualStory.Infra.Data.Repositories
{
    public class PaymentMethodRepository : Repository<PaymentMethod>, IPaymentMethodRepository
    {
        public PaymentMethodRepository(VirtualStoreDbContext context) : base(context)
        {
        }

        public PaymentMethod Add(PaymentMethod entity)
        {
            DbSet.Add(entity);
            return entity;
        }

        public PaymentMethod GetById(Guid Id)
        {
            var DbTable = DbSet.AsQueryable();
            var paymentMethod = DbTable.FirstOrDefault(x => x.Id == Id);
            return paymentMethod;
        }

        public void Remove(Guid Id)
        {
            var obj = GetById(Id);
            if (obj != null)
            {
                DbSet.Remove(obj);
            }
        }

        public void Remove(Expression<Func<PaymentMethod, bool>> predicate)
        {
            var dbTable = DbSet.AsQueryable();
            var paymentMethods = dbTable.Where(predicate);
            DbSet.RemoveRange(paymentMethods);
        }

        public IEnumerable<PaymentMethod> Search(Expression<Func<PaymentMethod, bool>> predicate)
        {
            var context = DbSet.AsQueryable();
            return context.Where(predicate).ToList();
        }

        public IEnumerable<PaymentMethod> Search(Expression<Func<PaymentMethod, bool>> predicate, int pageNumber, int pageSize)
        {
            var context = DbSet.AsQueryable();
            var result = context.Where(predicate).Skip((pageNumber - 1) * pageSize).Take(pageSize);
            return result;
        }

        public PaymentMethod Update(PaymentMethod entity)
        {
            DbSet.Update(entity);
            return entity;
        }
    }
}
