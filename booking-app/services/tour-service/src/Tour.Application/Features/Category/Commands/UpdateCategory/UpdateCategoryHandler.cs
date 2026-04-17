using Domain.Entities;
using Domain.Interfaces;
using Shared.Common;
using MediatR;
using AutoMapper;

namespace Application.Features
{
    public class UpdateCategoryHandler : IRequestHandler<UpdateCategoryCommand, OperationResult<int>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public UpdateCategoryHandler(
            ICategoryRepository categoryRepository,
            IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<OperationResult<int>> Handle(UpdateCategoryCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var category = await _categoryRepository.GetByIdAsync(command.model.id);
                _mapper.Map(command.model, category);

                _categoryRepository.Update(category);
                return OperationResult<int>.Updated(category.id);
            }
            catch (Exception ex)
            {
                return OperationResult<int>.Failure($"{ex.Message}");
            }
        }
    }
}