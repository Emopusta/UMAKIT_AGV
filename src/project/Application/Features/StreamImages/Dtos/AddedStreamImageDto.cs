using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.StreamImages.Dtos
{
    public class AddedStreamImageDto
    {
        public int Id { get; set; }
        public int VehicleId { get; set; }
        public string Path { get; set; }
    }
}
