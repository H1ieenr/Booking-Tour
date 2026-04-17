using Domain.Entities;
using Domain.Interfaces;
using Shared.Common;
using MediatR;
using AutoMapper;

namespace Application.Features
{
    public class CreateTravelTourHandler : IRequestHandler<CreateTravelTourCommand, OperationResult<int>>
    {
        private readonly ITravelTourRepository _travelTourRepository;
        private readonly IMapper _mapper;

        public CreateTravelTourHandler(
            ITravelTourRepository travelTourRepository,
            IMapper mapper)
        {
            _travelTourRepository = travelTourRepository;
            _mapper = mapper;
        }

        public async Task<OperationResult<int>> Handle(CreateTravelTourCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var tour = _mapper.Map<TravelTour>(command.model);
                await _travelTourRepository.AddAsync(tour);
                await _travelTourRepository.SaveChangesAsync(cancellationToken);
                return OperationResult<int>.Created(tour.id);
            }
            catch (Exception ex)
            {
                return OperationResult<int>.Failure($"{ex.Message}");
            }
        }
    }
}