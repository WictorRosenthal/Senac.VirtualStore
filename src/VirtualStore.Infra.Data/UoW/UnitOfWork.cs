using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualStore.Core.UoW;
using VirtualStore.Infra.Data.Context;

namespace VirtualStore.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly VirtualStoreDbContext _context;
        public UnitOfWork(VirtualStoreDbContext context)
        {
            _context = context;
        }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
