using System.Reflection;
using CG.Application.Services;
using CG.Application.Services.Interfaces;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace CG.Application
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddTransient<IMigratePersonPhoneNumberService, MigratePersonPhoneNumberService>();
            return services;
        }
    }
}
