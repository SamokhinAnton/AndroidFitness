using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fitness.DataModels.Entities.Token;
using Fitness.DataModels.Entities.Users;
using Fitness.WebApi.Utilities.JWT;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Fitness.WebApi
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
            services.AddMvc();
            services.AddCors();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(cfg =>
                {
                    cfg.RequireHttpsMetadata = false;
                    cfg.SaveToken = true;

                    cfg.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidIssuer = Configuration["JWTBearerSettings:Issuer"],
                        ValidateAudience = true,
                        ValidAudience = Configuration["JWTBearerSettings:Audience"],
                        ValidateLifetime = true,
                        IssuerSigningKey = JwtAuthOptionsModel.GetSymmetricSecurityKey((Configuration["JWTBearerSettings:Key"])),
                        ValidateIssuerSigningKey = true
                    };
                });
            services.Configure<GzipCompressionProviderOptions>(options =>
                options.Level = System.IO.Compression.CompressionLevel.Optimal);
            services.AddResponseCompression(options =>
            {
                options.Providers.Add<GzipCompressionProvider>();
                options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[]
                            {
                               "image/png",
                               "image/jpeg",
                               "image/bmp"
                            });
            });

            services.Configure<JwtAuthOptionsModel>(Configuration.GetSection("JWTBearerSettings"));

            services.AddTransient<IJWTAuthHelper<UserModel>, JWTAuthHelper>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors(o =>
            {
                o.AllowAnyMethod().AllowAnyOrigin().AllowAnyHeader();
            });
            app.UseAuthentication();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
