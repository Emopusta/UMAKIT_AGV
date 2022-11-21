using Application.Services.Repositories;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.ImageService
{
    public class ImageManager : IImageService
    {
        private readonly IStreamImageRepository _streamImageRepository;

        public ImageManager(IStreamImageRepository streamImageRepository)
        {
            _streamImageRepository = streamImageRepository;
        }
        public async Task<Image> UpdateStreamImageWithImage(Image image)
        {

            StreamImage streamImageToUpdate = await _streamImageRepository.GetAsync(p => p.Id == image.VehicleId);

            streamImageToUpdate.Path = image.Path;

            StreamImage updatedStreamImage = await _streamImageRepository.UpdateAsync(streamImageToUpdate);

            return image;
        }
    }
}
