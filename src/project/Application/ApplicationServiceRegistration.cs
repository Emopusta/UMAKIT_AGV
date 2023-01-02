using Application.Features.Images.Rules;
using Application.Services.ImageService;
using Application.Services.StreamImageService;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {

            services.AddMediatR(Assembly.GetExecutingAssembly());


            services.AddScoped<IStreamImageService, StreamImageManager>();
            services.AddScoped<IImageService, ImageManager>();

            services.AddScoped<ImageBusinessRules>();

            return services;

        }
    }
}
