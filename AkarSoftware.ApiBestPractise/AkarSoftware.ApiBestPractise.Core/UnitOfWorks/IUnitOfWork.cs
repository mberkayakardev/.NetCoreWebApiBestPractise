namespace AkarSoftware.ApiBestPractise.Core.UnitOfWorks
{
    public interface IUnitOfWork
    {
        Task CommitAsync(); // SaveChangeAsync
        void Commit(); // SaveChange
    }
}
