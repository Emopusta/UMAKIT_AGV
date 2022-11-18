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
    public class ImageRepository : EfRepositoryBase<Image, BaseDbContext>, IImageRepository
    {
        public ImageRepository(BaseDbContext context):base(context)
        {

        }

    }
}
