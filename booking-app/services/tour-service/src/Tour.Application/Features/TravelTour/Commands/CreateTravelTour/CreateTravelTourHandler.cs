using Domain.Entities;
using Domain.Interfaces;
using Shared.Common;
using Shared.Exceptions;
using MediatR;
using AutoMapper;

namespace Tour.Application
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

                var result = await _travelTourRepository.SaveChangesAsync(cancellationToken);
                if (result) return OperationResult<int>.Created(tour.id);
                
                return OperationResult<int>.Failure();
            }
            catch (Exception ex)
            {
                return OperationResult<int>.Failure($"{ex.Message}");
            }
        }
    }
}