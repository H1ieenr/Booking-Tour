using Domain.Interfaces;
using Shared.Common;
using MediatR;
using AutoMapper;
using Application.Common;

namespace Application.Features
{
    public class UpdateImagesHandler : IRequestHandler<UpdateImagesCommand, OperationResult<UpdateImagesDTO>>
    {
        private readonly IImageService _imageService;
        public UpdateImagesHandler(
            IImageService imageService)
        {
            _imageService = imageService;
        }
        public async Task<OperationResult<UpdateImagesDTO>> Handle(UpdateImagesCommand command, CancellationToken cancellationToken)
        {
            UpdateImagesDTO dto = new UpdateImagesDTO();
            var resultUpload = await _imageService.ProcessAndSaveImagesAsync(
                command.model.uploads.files,command.model.uploads.travel_tour_id, command.model.uploads.code_tour,command.model.uploads.user_id);
            var resultDelete = await _imageService.DeleteImagesAsync(command.model.deletes.delete_image_ids);

            dto.new_image_urls = resultUpload.Data;
            dto.deleted_image_ids = resultDelete.Data;
            return OperationResult<UpdateImagesDTO>.Success(dto);
        }
    }
}