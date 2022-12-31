using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Vehicles.Dtos
{
    public class UpdatedVehicleDto
    {
        public string Name { get; set; }
        public int Velocity { get; set; }
        public int BatteryPercentage { get; set; }
        public int StatusId { get; set; }
    }
}
