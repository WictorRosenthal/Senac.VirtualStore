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
    public class AddressRepository : Repository<Address>, IAddressRepository 
    {
        public AddressRepository(VirtualStoreDbContext context) : base(context)
        {
        }

        public Address Add(Address entity)
        {
            DbSet.Add(entity);
            return entity;
        }

        public Address GetById(Guid Id)
        {
            var DbTable = DbSet.AsQueryable();
            var address = DbTable.FirstOrDefault(x => x.Id == Id);
            return address;
        }

        public void Remove(Guid Id)
        {
            var obj = GetById(Id);
            if (obj != null)
            {
                DbSet.Remove(obj);
            }
        }


        public void Remove(Expression<Func<Address, bool>> predicate)
        {
            var dbTable = DbSet.AsQueryable();
            var address = dbTable.Where(predicate);
            DbSet.RemoveRange(address);
        }

        public IEnumerable<Address> Search(Expression<Func<Address, bool>> predicate)
        {
            var context = DbSet.AsQueryable();
            return context.Where(predicate).ToList();
        }

        public IEnumerable<Address> Search(Expression<Func<Address, bool>> predicate, int pageNumber, int pageSize)
        {
            var context = DbSet.AsQueryable();
            var result = context.Where(predicate).Skip((pageNumber - 1) * pageSize).Take(pageSize);
            return result;
        }

        public Address Update(Address entity)
        {
            DbSet.Update(entity);
            return entity;
        }


    }
}
