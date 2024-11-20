namespace FitnessWorkoutTracker.Domain.Repositories
{
    public interface IGeneralRepository<T, RT>
    {
        Task<RT> CreateAsync(T userEntity);
    }
}
