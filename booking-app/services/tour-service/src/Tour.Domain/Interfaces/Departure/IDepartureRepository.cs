using Domain.Entities;


namespace Domain.Interfaces
{
    public interface IDepartureRepository
    {
        Task<Departure> GetDepartureWithDetailsAsync(int id);
    }
}