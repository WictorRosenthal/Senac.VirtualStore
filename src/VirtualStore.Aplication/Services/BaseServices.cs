using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualStore.Core.UoW;
using VirtualStore.Infra.Data.UoW;

namespace VirtualStore.Aplication.Services
{
    public abstract class BaseServices
    {
        protected readonly IUnitOfWork UoW;
        protected readonly IMediator Bus;

        protected BaseServices(IUnitOfWork uoW, IMediator bus)
        {
            UoW = uoW;
            Bus = bus;
        }

        protected bool Commit()
        {
            return UoW.Commit();
        }
    }
}
