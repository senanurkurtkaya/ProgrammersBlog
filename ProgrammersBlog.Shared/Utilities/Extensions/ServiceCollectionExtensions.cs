﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using ProgrammersBlog.Shared.Utilities.Helpers.Abstract.WritableOptionsHelper;
using ProgrammersBlog.Shared.Utilities.Helpers.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Shared.Utilities.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void ConfigureWritable<T>(
           this IServiceCollection services,
           IConfigurationSection section,
           string file = "appsettings.json") where T : class, new()
        {
            // services.Configure<T>(section);            
            //services.AddTransient<IWritableOptions<T>>(provider =>
            //{
            //    var environment = provider.GetService<IHostingEnvironment>();
            //    var options = provider.GetService<IOptionsMonitor<T>>();
            //    return new WritableOptions<T>(environment, options, section.Key, file);
            //});
        }
    }
}
