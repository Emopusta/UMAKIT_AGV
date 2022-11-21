using Application.Services.Repositories;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.StreamImageService
{
    public class StreamImageManager : IStreamImageService
    {
        private readonly IStreamImageRepository _streamImageRepository;

        public StreamImageManager(IStreamImageRepository streamImageRepository)
        {
            _streamImageRepository = streamImageRepository;
        }

        public async Task<StreamImage> Update(StreamImage streamImage)
        {
            StreamImage updatedStreamImage = await _streamImageRepository.UpdateAsync(streamImage);
            return updatedStreamImage;
        }
    }
}
