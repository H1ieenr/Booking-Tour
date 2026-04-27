using Domain.Interfaces;
using Shared.Common;
using MediatR;
using AutoMapper;
using Application.Common;

namespace Application.Features
{
    public class UploadImagesHandler : IRequestHandler<UploadImagesCommand, OperationResult<List<string>>>
    {
        private readonly IImageService _imageService;
        public UploadImagesHandler(
            IImageService imageService)
        {
            _imageService = imageService;
        }
        public async Task<OperationResult<List<string>>> Handle(UploadImagesCommand command, CancellationToken cancellationToken)
        {
            return await _imageService.ProcessAndSaveImagesAsync(
                command.model.files,command.model.travel_tour_id, command.model.code_tour,command.model.user_id);
        }
    }
}