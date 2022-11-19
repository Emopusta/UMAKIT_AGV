using Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Vehicle : Entity
    {
        public string Name { get; set; }
        public int Velocity { get; set; }
        public int BatteryPercentage { get; set; }
        public int StatusId { get; set; }
    }
}
