using Application.Features.Vehicles.Dtos;
using Application.Services.Repositories;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Vehicles.Commands.AddVehicle
{
    public class AddVehicleCommand : IRequest<AddedVehicleDto>
    {
        public string Name { get; set; }

        public class AddVehicleCommandHandler : IRequestHandler<AddVehicleCommand, AddedVehicleDto>
        {
            private readonly IVehicleRepository _vehicleRepository;

            public AddVehicleCommandHandler(IVehicleRepository vehicleRepository)
            {
                _vehicleRepository = vehicleRepository;
            }

            public async Task<AddedVehicleDto> Handle(AddVehicleCommand request, CancellationToken cancellationToken)
            {
                Vehicle vehicleToAdd = new()
                {
                    Name = request.Name,
                    Velocity = 0,
                    BatteryPercentage = 0,
                    StatusId = 1,
                };

                Vehicle addedVehicle = await _vehicleRepository.AddAsync(vehicleToAdd);

                AddedVehicleDto result = new()
                {
                    Name = addedVehicle.Name,
                    Velocity = addedVehicle.Velocity,
                    BatteryPercentage = addedVehicle.BatteryPercentage,
                    StatusId = addedVehicle.StatusId
                };
                return result;

            }
        }
    }
}
