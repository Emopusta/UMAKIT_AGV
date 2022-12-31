using Application.Features.Vehicles.Dtos;
using Application.Services.Repositories;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Vehicles.Commands.UpdateVehicle
{
    public class UpdateVehicleCommand : IRequest<UpdatedVehicleDto>
    {
        public string Name { get; set; }
        public int Velocity { get; set; }
        public int BatteryPercentage { get; set; }
        public int StatusId { get; set; }

        public class UpdateVehicleCommandHandler : IRequestHandler<UpdateVehicleCommand, UpdatedVehicleDto>
        {
            IVehicleRepository _vehicleRepository;

            public UpdateVehicleCommandHandler(IVehicleRepository vehicleRepository)
            {
                _vehicleRepository = vehicleRepository;
            }
            public async Task<UpdatedVehicleDto> Handle(UpdateVehicleCommand request, CancellationToken cancellationToken)
            {
                Vehicle? vehicleToUpdate = await _vehicleRepository.GetAsync(v => v.Name == request.Name);

                vehicleToUpdate.BatteryPercentage = request.BatteryPercentage;
                vehicleToUpdate.StatusId = request.StatusId;
                vehicleToUpdate.Velocity = request.Velocity;

                Vehicle updatedVehicle = await _vehicleRepository.UpdateAsync(vehicleToUpdate);

                UpdatedVehicleDto result = new()
                {
                    Name = updatedVehicle.Name,
                    Velocity = updatedVehicle.Velocity,
                    BatteryPercentage = updatedVehicle.BatteryPercentage,
                    StatusId = updatedVehicle.StatusId
                };
                return result;



                
            }
        }
    }
}
