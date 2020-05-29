using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Airline.DAL;
using Airline.DAL.DBContext;
using Airline.DAL.Interfaces;
using Airline.DAL.Interfaces.IEntityRepositories;
using Airline.DAL.Repositories.EntityRepositories;
using Airline.DAL.UnitOfWork;
using Airline.BLL.Services;
using Airline.BLL.Interfaces.IServices;
using Microsoft.EntityFrameworkCore;
using Airline.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using FluentValidation;
using Airline.BLL.DTOs;
using Airline.BLL.Validation;
using AutoMapper;
using Airline.BLL;
using FluentValidation.AspNetCore;
using Airline.Filters;
using Microsoft.OpenApi.Models;
using System;

namespace Airline
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AirlineContext>(opts => opts.UseSqlServer(MyConnection.Connection));

            services.AddControllers();

            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<AirlineContext>();

            #region Repositories
            services.AddTransient<IPassengerRepository, PassengerRepository>();
            services.AddTransient<IFlightScheduleRepository, FlightScheduleRepository>();
            services.AddTransient<IFlightRepository, FlightRepository>();
            #endregion

            services.AddTransient<IUnitOfWork, UnitOfWork>();

            #region Services
            services.AddTransient<IPassengerService, PassengerService>();
            services.AddTransient<IFlightScheduleService, FlightScheduleService>();
            services.AddTransient<IFlightService, FlightService>();
            #endregion

            services.AddAutoMapper(typeof(OrganizationProfile));

            #region FluentValidation

            services.AddMvc(setup =>
            {
                setup.Filters.Add(typeof(ValidatorActionFilter));
            }).AddFluentValidation();

            #region DTO Validators
            services.AddTransient<IValidator, PassengerDTOValidator>();
            services.AddTransient<IValidator, FlightDTOValidator>();
            #endregion

            #endregion
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Airline API",
                    Description = "ASP.NET Core Web API"
                });

                c.IncludeXmlComments(GetXmlCommentsPath());
            });
        }
        private string GetXmlCommentsPath()
        {
            return string.Format(@"{0}\SwaggerTest.XML", AppDomain.CurrentDomain.BaseDirectory);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My Airline API V1");

            });

        }
    }
}



