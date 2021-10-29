using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using Swashbuckle.AspNetCore.Swagger;
using System.Threading.Tasks;
using Microsoft.Extensions.PlatformAbstractions;
using System.IO;
using Gisa.Domain.Interfaces.Service;
using Gisa.Service;
using Gisa.Domain.Interfaces.Repository;
using Gisa.SqlRepository;
using FluentValidation;
using Gisa.Domain;
using Gisa.Domain.Validation;
using System.Globalization;

namespace Gisa.WebApi
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

            #region [ Swagger ]

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new Microsoft.OpenApi.Models.OpenApiInfo
                    {
                        Title = "GISA - Gestão Integral da Saúde do Associado",
                        Version = PlatformServices.Default.Application.ApplicationVersion,
                        Description = "GISA - API REST",
                        Contact = new Microsoft.OpenApi.Models.OpenApiContact
                        {
                            Name = "PUC Minas"
                        }
                    });

                string pathApplication = PlatformServices.Default.Application.ApplicationBasePath;
                string nameAplication = PlatformServices.Default.Application.ApplicationName;
                string pathXmlDoc = Path.Combine(pathApplication, $"{nameAplication}.xml");

                c.IncludeXmlComments(pathXmlDoc);
            });

            #endregion

            #region [ Services ]

            services.AddTransient<IConsultaService, ConsultaService>();
            services.AddTransient<IConveniadoService, ConveniadoService>();
            services.AddTransient<IEspecialidadeService, EspecialidadeService>();
            services.AddTransient<IPrestadorService, PrestadorService>();
            services.AddTransient<IAssociadoService, AssociadoService>();

            #endregion

            #region [ Repositories ]

            services.AddTransient<IConsultaRepository, ConsultaRepository>();
            services.AddTransient<IConveniadoRepository, ConveniadoRepository>();
            services.AddTransient<IEspecialidadeRepository, EspecialidadeRepository>();
            services.AddTransient<IPrestadorRepository, PrestadorRepository>();
            services.AddTransient<IAssociadoRepository, AssociadoRepository>();

            #endregion

            #region [ Validator ]

            services.AddSingleton<IValidator<Consulta>, ConsultaValidator>();
            services.AddSingleton<IValidator<Conveniado>, ConveniadoValidator>();
            services.AddSingleton<IValidator<Especialidade>, EspecialidadeValidator>();
            services.AddSingleton<IValidator<Prestador>, PrestadorValidator>();
            services.AddSingleton<IValidator<Associado>, AssociadoValidator>();

            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("pt-BR");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            // Ativando middlewares para uso do Swagger
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "GISA");
            });
        }
    }
}
