
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
using StudentCourse.Abstraction.Courses.Repositories;
using StudentCourse.Abstraction.Courses.Service;

using StudentCourse.API.Courses.GrapgQL;
using StudentCourse.API.Courses.GrapgQL.Types;

using StudentCourse.Core.Courses.Services;

using StudentCourse.Infrastructure.Course.Data.Mongo;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentCourse.API
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

            services.AddTransient<ICourseRepository, CourseRepository>();
            
            services.AddTransient<IDemoGraphQLApplication, DemoGraphQLApplication>();
            services.AddTransient<IDemoGraphQLQueryHandler, DemoGraphQLQueryHandler>();

            services.AddSingleton<MongoContext>(sp =>
               sp.GetRequiredService<IOptions<MongoContext>>().Value);

            services.AddGraphQLServer()
                .AddQueryType<Query>()
                .AddType<CourseType>()
              
               
                
                .AddType(new UuidType('D'))
                .AddMutationType<Mutation>()
                .AddFiltering()
                .AddErrorFilter<GraphQLErrorFilter>()
                .AddSorting();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "StudentCourse.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "StudentCourse.API v1"));
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
