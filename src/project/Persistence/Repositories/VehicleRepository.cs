using Application.Services.Repositories;
using Core.Repositories;
using Domain.Entities;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class VehicleRepository : EfRepositoryBase<Vehicle, BaseDbContext>, IVehicleRepository
    {
        public VehicleRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
