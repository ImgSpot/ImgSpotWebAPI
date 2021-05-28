using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImgSpot.Storage;
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
using Newtonsoft.Json;

namespace ImgSpot.Client
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

      //services.AddControllers();
      services.AddControllers().AddNewtonsoftJson();
      services.AddScoped<UnitOfWork>();
      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "ImgSpot.Client", Version = "v1" });
      });
      services.AddDbContext<ImgSpotContext>(options =>
          {
            if (!string.IsNullOrWhiteSpace(Configuration.GetConnectionString("mssql")))
            {
              options.UseSqlServer(Configuration.GetConnectionString("mssql"), opts =>
              {
                opts.EnableRetryOnFailure(3);
              });
            }
          });
      services.AddCors(options =>
     {
       options.AddPolicy("public", config =>
       {
         config.AllowAnyHeader();
         config.AllowAnyMethod();
         config.AllowAnyOrigin();
       });
     });
    }
    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ImgSpot.Client v1"));
      }
      else
      {
        app.UseHsts();
      }

      app.UseHttpsRedirection();

      app.UseRouting();

      app.UseAuthorization();

      app.UseCors();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
