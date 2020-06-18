using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ProjectManagementAPI.API.Controllers;
using ProjectManagementAPI.Data;
using ProjectManagementAPI.API.Repositories;
using ProjectManagementAPI.Model;

namespace ProjectManagementAPI
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
            services.AddControllers();
            services.AddMvc();
            //I need to figure out the difference between these two lines.
            services.AddTransient<IRepository<Client>, ClientsRepository>(); 
            //services.AddTransient<IProjectsRepository, ProjectsRepository>(); 


            //services.AddTransient<IChecklistRepository,ChecklistRepository>();
            //services.AddTransient<IPlansRepository, PlansRepository>();
            //services.AddTransient<IChecklistItemsRepository,CheckListItemsRepository>();
            services.AddDbContext<ProjectManagementDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("LocalConnection"));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseDefaultFiles();

            app.UseStaticFiles();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
