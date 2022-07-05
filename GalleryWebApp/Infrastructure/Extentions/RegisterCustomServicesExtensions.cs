using DemoWIUTGallery.BLL.Services.Abstractions;
using DemoWIUTGallery.BLL.Services.Implementations;
using DemoWIUTGallery.DAL.Repositories.Abstractions;
using DemoWIUTGallery.DAL.Repositories.Implementations;
using GalleryWebApp.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace GalleryWebApp.Infrastructure.Extentions
{
    public static class RegisterCustomServicesExtensions
    { 
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IFolderRepository, FolderRepository>();
            services.AddScoped<IPhotoRepository, PhotoRepository>();

            services.AddScoped<IFolderService, FolderService>();
            services.AddScoped<IPhotoService, PhotoService>();

            services.AddScoped<IFileManager, FileManager>();

            return services;
        }
    }
}
