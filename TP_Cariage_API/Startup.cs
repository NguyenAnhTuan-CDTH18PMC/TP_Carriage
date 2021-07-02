using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TP_Cariage_API.Models;
using TP_Cariage_API.Data;
using TP_Cariage_API.Momo;
using Microsoft.AspNetCore.Identity;
using TP_Cariage_API.System;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;
using System.Text;
using Microsoft.IdentityModel.Logging;

namespace TP_Cariage_API
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
            services.AddControllersWithViews()
.AddNewtonsoftJson(options =>options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddControllers();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IMomoServices, MoMoServices>();
           // services.AddTransient<IUserService, UserService>();
            services.AddDbContext<TPCarriageContext>(options => options.UseSqlServer(Configuration.GetConnectionString("TP_Carriage_API")))
                .AddIdentity<Accounts,IdentityRole>()
                .AddEntityFrameworkStores<TPCarriageContext>()
                .AddDefaultTokenProviders();

             services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                      .AddCookie(x =>
                      {
                          x.LoginPath = "/Account/Login";
                          x.AccessDeniedPath = "/Account/AccessDenied";
                      })
                      .AddJwtBearer(x =>
                      {
                          x.RequireHttpsMetadata = false;
                          x.SaveToken = false;
                          x.TokenValidationParameters = new TokenValidationParameters
                          {
                          ValidateIssuerSigningKey = true,
                              ValidateIssuer = true,
                              ValidateAudience = true,
                              ValidateLifetime = true,
                              ClockSkew = TimeSpan.Zero,
                              ValidIssuer = Configuration["Tokens:Issuer"],
                              ValidAudience=Configuration["Tokens:Audience"],
                              IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Tokens:Key"]))
                          };
                          x.Events = new JwtBearerEvents()
                          {
                              OnAuthenticationFailed = c =>
                              {
                                  c.NoResult();
                                  c.Response.StatusCode = 500;
                                  c.Response.ContentType = "text/plain";
                                  return c.Response.WriteAsync(c.Exception.ToString());
                              },
                              OnChallenge = context =>
                              {
                                  context.HandleResponse();
                                  context.Response.StatusCode = 401;
                                  context.Response.ContentType = "application/json";
                                  var result = JsonConvert.SerializeObject("Vui lòng đăng nhập");
                                  return context.Response.WriteAsync(result);
                              },
                              OnForbidden = context =>
                              {
                                  context.Response.StatusCode = 403;
                                  context.Response.ContentType = "application/json";
                                  var result = JsonConvert.SerializeObject("Vui lòng đăng nhập");
                                  return context.Response.WriteAsync(result);
                              },
                          };
                      });
            services.AddAuthorization(options =>
            {
                var defaultAuthorizationPolicyBuilder = new AuthorizationPolicyBuilder(CookieAuthenticationDefaults.AuthenticationScheme, JwtBearerDefaults.AuthenticationScheme);
                defaultAuthorizationPolicyBuilder = defaultAuthorizationPolicyBuilder.RequireAuthenticatedUser();
                options.DefaultPolicy = defaultAuthorizationPolicyBuilder.Build();
            });
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
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
