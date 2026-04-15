using Domain.Entities;
using Domain.Interfaces;
using Shared.Common;
using Shared.Exceptions;
using MediatR;
using AutoMapper;

namespace Tour.Application
{
    public class CreateTourHandler : IRequestHandler<CreateTourCommand, OperationResult<int>>
    {
        private readonly ITravelTourRepository _tourRepository;
        private readonly IMapper _mapper;

        public CreateTourHandler(
            ITravelTourRepository tourRepository,
            IMapper mapper)
        {
            _tourRepository = tourRepository;
            _mapper = mapper;
        }

        public async Task<OperationResult<int>> Handle(CreateTourCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var tour = _mapper.Map<TravelTour>(request.TourDto);
                await _tourRepository.AddAsync(tour);

                var result = await _tourRepository.SaveChangesAsync(cancellationToken);
                if (result) return OperationResult<int>.Created(1);
                
                return OperationResult<int>.Failure();
            }
            catch (Exception ex)
            {
                return OperationResult<int>.Failure($"{ex.Message}");
            }
        }
    }
}