﻿using Khuseinov_KT_42_20.Interfaces.StudentInterface;

namespace Khuseinov_KT_42_20.ServiceExtensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services) 
        {
            services.AddScoped<IStudentService, StudentService>();

            return services;
        }
    }
}
