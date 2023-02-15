﻿using FridgeApi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeApi.Infrastructure
{
    public static class Dependencies
    {
        public static void ConfigureServices(IConfiguration configuration, IServiceCollection services)
        {
            services.AddDbContext<EFCoreDbContext>(context =>
            context.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }
    }
}
