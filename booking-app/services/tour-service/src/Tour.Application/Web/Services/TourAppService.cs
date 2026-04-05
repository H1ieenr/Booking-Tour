
namespace Tour.Application
{
    public class TourAppService : ITourAppService
    {
        //private readonly ITourRepository _tourRepository;
        public TourAppService(){}
        public async Task<int> CreateTourAsync(CreateTourRequestDTO request)
        {
            return 1;
        }
    }
}