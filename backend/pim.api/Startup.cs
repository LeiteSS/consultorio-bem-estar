using System;
using System.IO;
using System.Reflection;
using System.Text;


using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using pim.api.Business.DAL;
using pim.api.Business.Repository;
using pim.api.Configurations;
using pim.api.Infraestruture.Data;
using pim.api.Infraestruture.Data.DAL;
using pim.api.Infraestruture.Data.Repositories;

namespace pim.api
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
            

            services.AddControllers()
                .ConfigureApiBehaviorOptions(options =>
                {
                    options.SuppressConsumesConstraintForFormFileParameters = true;
                });

            services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme (Example: 'Bearer 12345abcdef')",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(apiContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });


            var secret = Encoding.ASCII.GetBytes(Configuration.GetSection("JwtConfigurations:Secret").Value);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(secret),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            Console.WriteLine(Configuration.GetConnectionString("DefaultConnection"));

            services.AddDbContext<ConsultasDbContext>(options =>
            {
                options.UseMySql(Configuration.GetConnectionString("DefaultConnection"), new MariaDbServerVersion(new Version(10, 3, 29)));
            });

            services.AddScoped<IConsultaRepository, ConsultaRepository>();
            services.AddScoped<IMedicoRepository, MedicoRepository>();

            services.AddScoped<IConsultasDao, ConsultasDao>();
            services.AddScoped<IMedicosDao, MedicosDao>();
            services.AddScoped<IPacientesDao, PacientesDao>();

            services.AddScoped<IAuthenticationServiceCustom, JwtServiceCustom>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IapilicationBuilder api, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                api.UseDeveloperExceptionPage();
            }

            api.UseHttpsRedirection();

            api.UseRouting();

            api.UseAuthentication();
            api.UseAuthorization();

            api.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            api.UseSwagger(c =>
            {
                c.RouteTemplate = "api/docs/{documentName}/swagger.json";
            });
            api.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/api/docs/v1/swagger.json", "Sistema de Teleatendimento Médico - Consultorio Bem Estar");
                c.RoutePrefix = "api/docs";
            });

            api.UseapilyMigration();
        }
    }
}
