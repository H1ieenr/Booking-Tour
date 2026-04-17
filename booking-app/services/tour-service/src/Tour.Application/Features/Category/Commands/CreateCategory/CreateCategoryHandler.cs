using Domain.Entities;
using Domain.Interfaces;
using Shared.Common;
using MediatR;
using AutoMapper;

namespace Application.Features
{
    public class CreateCategoryHandler : IRequestHandler<CreateCategoryCommand, OperationResult<int>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CreateCategoryHandler(
            ICategoryRepository categoryRepository,
            IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<OperationResult<int>> Handle(CreateCategoryCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var category = _mapper.Map<Category>(command.model);
                await _categoryRepository.AddAsync(category);
                return OperationResult<int>.Created(category.id);
            }
            catch (Exception ex)
            {
                return OperationResult<int>.Failure($"{ex.Message}");
            }
        }
    }
}