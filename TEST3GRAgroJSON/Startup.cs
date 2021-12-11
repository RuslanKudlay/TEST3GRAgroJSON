using BAL.ProductService;
using DAL;
using DAL.Entity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TEST3GRAgroJSON
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
            services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
            services.AddScoped<IProductService, ProductService>();

            services.AddDbContext<ApplicationDbContext>
            (
                option =>
                {
                    option.UseSqlServer(Configuration["SqlServerConnectionString"],
                    _ => _.MigrationsAssembly("DAL"));
                }
            );

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TEST3GRAgroJSON", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TEST3GRAgroJSON v1"));
            }

            DefaultData(app);

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void DefaultData(IApplicationBuilder app)
        {
            var scopeFactory = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>();

            using (var scope = scopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                if (dbContext.Products.FirstOrDefault() == null)
                {
                    for (int i = 1; i < 11; i++)
                    {
                        var product = new Product
                        {
                            Name = $"Name{i}",
                        };
                        dbContext.Add(product);

                        for (int j = 1; j < 2; j++)
                        {
                            var volume = new Volume
                            {
                                Product = product
                            };
                            dbContext.Add(volume);

                            for (int z = 1; z < 2; z++)
                            {
                                var propertyVolume = new PropertyVolume
                                {
                                    Heigth = z,
                                    Width = z,
                                    Weigth = z,
                                    Volume = volume
                                };
                                dbContext.Add(propertyVolume);
                                dbContext.SaveChanges();
                            }
                        }
                    }
                }
            }
        }
    }
}
