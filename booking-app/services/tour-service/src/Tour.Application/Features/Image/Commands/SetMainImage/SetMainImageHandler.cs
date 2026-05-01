using MediatR;
using Shared.Common;
using AutoMapper;
using Domain.Interfaces;


namespace Application.Features
{
    public class SetMainImageHandler : IRequestHandler<SetMainImageCommand, OperationResult<int>>
    {
        private readonly IImageRepository _imageRepository;
        private readonly IMapper _mapper;
        public SetMainImageHandler(
            IImageRepository imageRepository, IMapper mapper)
        {
            _imageRepository = imageRepository;
            _mapper = mapper;
        }
        public async Task<OperationResult<int>> Handle(SetMainImageCommand command, CancellationToken cancellationToken)
        {
             try
            {
                var image = await _imageRepository.GetByIdAsync(command.model.id, cancellationToken);
                if (image == null) return OperationResult<int>.Nodata(command.model.id);

                image.is_primary = command.model.is_primary;
                _imageRepository.Update(image);
                return OperationResult<int>.Updated(image.id);
            }
            catch (Exception ex)
            {
                return OperationResult<int>.Failure($"{ex.Message}");
            }
        }
    }
}