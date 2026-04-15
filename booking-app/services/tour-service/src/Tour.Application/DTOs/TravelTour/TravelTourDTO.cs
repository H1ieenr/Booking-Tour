

namespace Tour.Application
{
    public record TravelTourDto(int Id, string Title, 
    string Code, string CategoryName, decimal BasePrice);

    public record CreateTourRequestDto(string Title, int CategoryId, decimal Price);
}