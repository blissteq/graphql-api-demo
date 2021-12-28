using DemoGraphQL.API.GrapgQL.Types;
using HotChocolate.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using StudentDetails.Abstraction.Repositories;
using StudentDetails.Abstraction.Service;
using StudentDetails.Abstractions;
using StudentDetails.API.GrapgQL;
using StudentDetails.Core.Services;
using StudentDetails.Infrastructure.Data.Mongo;
using StudentDetails.Infrastruture.Data.Mongo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentDetails.API
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
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            services.AddTransient<IStudentRepository, StudentRepository>();

            services.AddTransient<IStudentDetailsApplication, StudentDetailsApplication>();
            services.AddTransient<IStudentDetailsQueryHandler, StudentDetailsQueryHandler>();

            //services.AddSingleton<AppSettings>(sp =>
            //   sp.GetRequiredService<IOptions<AppSettings>>().Value);

            services.AddTransient<MongoContext>();

            services.AddGraphQLServer()
                .AddQueryType<Query>()
                .AddType<StudentType>()
                .AddType(new UuidType('D'))

                .AddMutationType<Mutation>()
                .AddFiltering()
                .AddErrorFilter<GraphQLErrorFilter>()
                .AddSorting();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "StudentDetails.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "StudentDetails.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL();
            });
        }
    }
}
