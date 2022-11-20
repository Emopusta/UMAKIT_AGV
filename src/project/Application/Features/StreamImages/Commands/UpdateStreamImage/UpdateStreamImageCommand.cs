using Application.Features.StreamImages.Dtos;
using Application.Services.Repositories;
using Core.Exceptions;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.StreamImages.Commands.UpdateStreamImage
{
    public class UpdateStreamImageCommand : IRequest<UpdatedStreamImageDto>
    {
        public int Id { get; set; }
        public string Path { get; set; }

        public class UpdateStreamImageCommandHandler : IRequestHandler<UpdateStreamImageCommand, UpdatedStreamImageDto>
        {
            private readonly IStreamImageRepository _streamImageRepository;

            public UpdateStreamImageCommandHandler(IStreamImageRepository streamImageRepository)
            {
                _streamImageRepository = streamImageRepository;
            }

            public async Task<UpdatedStreamImageDto> Handle(UpdateStreamImageCommand request, CancellationToken cancellationToken)
            {
                StreamImage? streamImageToUpdate = await _streamImageRepository.GetAsync(s => s.Id == request.Id);

                if(streamImageToUpdate == null) { throw new BusinessException("StreamImage Does not exist"); }

                streamImageToUpdate.Path = request.Path;

                StreamImage updatedStreamImage = await _streamImageRepository.UpdateAsync(streamImageToUpdate);

                UpdatedStreamImageDto result = new()
                {
                    Id = updatedStreamImage.Id,
                    Path = request.Path,
                    VehicleId = updatedStreamImage.VehicleId
                };
                return result;
            }
        }
    }
}
