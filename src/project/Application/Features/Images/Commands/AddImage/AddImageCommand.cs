using Application.Features.Images.Constants;
using Application.Features.Images.Dtos;
using Application.Services.Repositories;
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

        public class AddImageCommandHandler : IRequestHandler<AddImageCommand, AddedImageDto>
        {
            private readonly IImageRepository _imageRepository;

            public AddImageCommandHandler(IImageRepository imageRepository)
            {
                _imageRepository = imageRepository;
            }

            public async Task<AddedImageDto> Handle(AddImageCommand request, CancellationToken cancellationToken)
            {
                Image image = new()
                {
                    Path = FileHelper.Upload(request.File, ImageConstants.Path)
                };
                Image addedImage = await _imageRepository.AddAsync(image);
                AddedImageDto result = new()
                {
                    Id = addedImage.Id,
                    Path= addedImage.Path,
                    CreatedDate = addedImage.CreatedDate,
                };
                return result;
            }
        }
    }
}
