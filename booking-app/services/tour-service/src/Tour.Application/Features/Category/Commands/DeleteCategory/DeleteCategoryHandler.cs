using Domain.Interfaces;
using Shared.Common;
using MediatR;
using AutoMapper;

namespace Application.Features
{
    public class DeleteCategoryHandler : IRequestHandler<DeleteCategoryCommand, OperationResult<int>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public DeleteCategoryHandler(
            ICategoryRepository categoryRepository,
            IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<OperationResult<int>> Handle(DeleteCategoryCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var category = await _categoryRepository.GetByIdAsync(command.model.id, cancellationToken);
                if (category == null) return OperationResult<int>.Nodata(command.model.id);
                _mapper.Map(command.model, category);
                _categoryRepository.Update(category);
                return OperationResult<int>.Deleted();
            }
            catch (Exception ex)
            {
                return OperationResult<int>.Failure($"{ex.Message}");
            }
        }
    }
}