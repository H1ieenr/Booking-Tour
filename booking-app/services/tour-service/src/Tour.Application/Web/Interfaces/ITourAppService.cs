
namespace Tour.Application
{
    public interface ITourAppService
    {
        Task<int> CreateTourAsync(CreateTourRequestDTO request);
    }
}