using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Ryder.Application.Common.Mapper;
using System.Reflection;

namespace Ryder.Application
{
    public static class ApplicationInjection
    {
        public static void ApplicationDependencyInjection(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMapperInitializer));
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        }
    }
}