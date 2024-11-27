namespace FitnessWorkoutTracker.Domain.Repositories
{
    public interface IGeneralRepository<T, RT>
    {
        Task<T> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task<ICollection<T>?> GetAllAsync(CancellationToken cancellationToken);
        Task<T> UpdateAsync(T value, CancellationToken cancellationToken);
        Task<RT> CreateAsync(T userEntity, CancellationToken cancellationToken);
    }
}
