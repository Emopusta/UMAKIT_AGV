using Application.Services.Repositories;
using Core.Exceptions;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Images.Rules
{
    public class ImageBusinessRules
    {
        private readonly IImageRepository _imageRepository;
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IStreamImageRepository _streamImageRepository;

        public ImageBusinessRules(IImageRepository imageRepository, IVehicleRepository vehicleRepository, IStreamImageRepository streamImageRepository)
        {
            _imageRepository = imageRepository;
            _vehicleRepository = vehicleRepository;
            _streamImageRepository = streamImageRepository;
        }

        public async Task VehicleMustExistWhenImageAdded(int vehicleId)
        {
            Vehicle? vehicle =  await _vehicleRepository.GetAsync(v => v.Id == vehicleId);
            if (vehicle == null) { throw new BusinessException("vehicle must exist."); }
        }

        public async Task StreamImageMustExistWhenImageAdded(int vehicleId)
        {
            StreamImage? streamImage = await _streamImageRepository.GetAsync(s => s.VehicleId == vehicleId);
            if (streamImage == null) { throw new BusinessException("streamImage must exist."); }
        }
    }
}
