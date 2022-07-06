using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using Capgemini.TestDev.Data; 
using System.Text;
using Capgemini.TestDev.Data.Context;
using Capgemini.TestDev.Domain.Interfaces.UoW;
using Capgemini.TestDev.Data.UnitOfWork;
using Capgemini.TestDev.Data.Repositories;
using Capgemini.TestDev.Domain.Interfaces.Repositories;
using Capgemini.TestDev.Business.Configurations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Builder;
using System.Globalization;
using Microsoft.AspNetCore.Localization;

namespace Capgemini.TestDev.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static IConfiguration Configuration { get; set; }

        public void ConfigureServices(IServiceCollection services)
        {
            var testDevConnectionString = Configuration.GetConnectionString("TestDevConnection");


            services.AddEntityFrameworkSqlite().AddDbContext<TestDevContext>();


            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICustomerCardRepository, CustomerCardRepository>();


            services.AddMvcCore().SetCompatibilityVersion(CompatibilityVersion.Latest)
           .AddMvcOptions(option => option.EnableEndpointRouting = false);
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            var usCulture = new CultureInfo("en-US");
            var supportedCultures = new[] { usCulture };

     
            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(usCulture),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            });

            //app.UseAuthentication();

            //app.UseSwagger();

            //app.UseSwaggerUI(c =>
            //{
            //    c.SwaggerEndpoint("./v1/swagger.json", "ML_CCXP v1");
            //});

            app.UseMvc();
        }
    }
}
