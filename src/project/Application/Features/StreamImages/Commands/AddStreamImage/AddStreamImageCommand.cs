using Application.Features.StreamImages.Constants;
using Application.Features.StreamImages.Dtos;
using Application.Services.Repositories;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.StreamImages.Commands.AddStreamImage
{
    public class AddStreamImageCommand : IRequest<AddedStreamImageDto>
    {
        public int VehicleId { get; set; }


        public class AddStreamImageCommandHandler : IRequestHandler<AddStreamImageCommand, AddedStreamImageDto>
        {
            private readonly IStreamImageRepository _streamImageRepository;

            public AddStreamImageCommandHandler(IStreamImageRepository streamImageRepository)
            {
                _streamImageRepository = streamImageRepository;
            }

            public async Task<AddedStreamImageDto> Handle(AddStreamImageCommand request, CancellationToken cancellationToken)
            {
                StreamImage streamImageToAdd = new()
                {
                    Path = StreamImageConstants.DefaultPath,
                    VehicleId = request.VehicleId,
                };
                StreamImage addedStreamImage = await _streamImageRepository.AddAsync(streamImageToAdd);

                AddedStreamImageDto result = new()
                {
                    Path = addedStreamImage.Path,
                    VehicleId = addedStreamImage.VehicleId
                };
                return result;

            }
        }
    }
}
