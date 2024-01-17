namespace VirtualStore.Core.UoW
{
    public interface IUnitOfWork
    {
        bool Commit();
    }
}