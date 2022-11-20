using Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class StreamImage : Entity
    {
        public int VehicleId { get; set; }
        public string Path { get; set; }

    }
}
