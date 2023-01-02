using Application.Features.Images.Constants;
using Application.Features.Images.Dtos;
using Application.Features.Images.Rules;
using Application.Services.ImageService;
using Application.Services.Repositories;
using Application.Services.StreamImageService;
using Core.FileHelpers;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Images.Commands.AddImage
{
    public class AddImageCommand : IRequest<AddedImageDto>
    {
        public IFormFile File { get; set; }
        public int VehicleId { get; set; }


        public class AddImageCommandHandler : IRequestHandler<AddImageCommand, AddedImageDto>
        {
            private readonly IImageRepository _imageRepository;
            private readonly IImageService _imageService;
            private readonly ImageBusinessRules _imageBusinessRules;

            public AddImageCommandHandler(IImageRepository imageRepository, IImageService imageService, ImageBusinessRules imageBusinessRules)
            {
                _imageRepository = imageRepository;
                _imageService = imageService;
                _imageBusinessRules = imageBusinessRules;
            }

            public async Task<AddedImageDto> Handle(AddImageCommand request, CancellationToken cancellationToken)
            {
                Image image = new()
                {
                    VehicleId = request.VehicleId,
                    Path = FileHelper.Upload(request.File, ImageConstants.Path)
                };
                Image addedImage = await _imageRepository.AddAsync(image);

                await _imageBusinessRules.VehicleMustExistWhenImageAdded(request.VehicleId);
                await _imageBusinessRules.StreamImageMustExistWhenImageAdded(request.VehicleId);


                await _imageService.UpdateStreamImageWithImage(addedImage);

                AddedImageDto result = new()
                {
                    Id = addedImage.Id,
                    VehicleId = addedImage.VehicleId,
                    Path= addedImage.Path,
                    CreatedDate = addedImage.CreatedDate,
                };
                return result;
            }
        }
    }
}
