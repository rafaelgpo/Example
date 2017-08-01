﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Example.Application.Interface;
using Example.Domain.Service.Interface;
using Example.Domain.Repository.Interface;
using Example.Domain.Validation.Interface;
using Example.Application;
using Example.Domain.Service;
using Example.Repository;
using Example.Domain.Validation;
using Example.API.Models;
using Example.Domain.Events.Interface;
using Example.Domain.Events;
using Microsoft.AspNetCore.Http;
using Example.Domain.Events.Bus;

namespace Example.API
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();

            Application.AutoMapper.AutoMapperInitialization.RegisterMapping();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();

            services.AddScoped<IUserApplication, UserApplication>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserAddValidation, UserAddValidation>();
            services.AddScoped<IUserUpdateValidation, UserUpdateValidation>();
            services.AddScoped<IDomainNotificationHandler<ValidationMessage>, DomainNotificationHandler>();
            services.AddScoped<IBus, InMemoryBus>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory,
                                      IHttpContextAccessor accessor)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseMiddleware(typeof(ErrorHandlingMiddleware));

            app.UseMvc();

            // Setting the IContainer interface for use like service locator for events.
            InMemoryBus.ContainerAccessor = () => accessor.HttpContext.RequestServices;
        }
    }
}