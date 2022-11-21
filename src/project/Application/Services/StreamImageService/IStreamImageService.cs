using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.StreamImageService
{
    public interface IStreamImageService
    {
        public Task<StreamImage> Update(StreamImage streamImage);
    }
}
