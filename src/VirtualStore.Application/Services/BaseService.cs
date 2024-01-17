using MediatR;
using VirtualStore.Core.UoW;

namespace VirtualStore.Application.Services
{
    public abstract class BaseService
    {
        protected readonly IUnitOfWork UoW;
        protected readonly IMediator Bus;

        protected BaseService(IUnitOfWork uoW, IMediator bus)
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
