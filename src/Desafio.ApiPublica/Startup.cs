using AutoMapper;
using Desafio.Aplicacao;
using Desafio.Aplicacao.Respostas.Comum;
using Desafio.Infraestrutura.Contexto;
using Desafio.InversaoControle;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System.Net.Mime;

namespace Desafio.ApiPublica
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
            services.AddDbContext<DesafioContexto>(builder
                => builder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
                        options => options.MigrationsAssembly(typeof(Startup).Assembly.FullName)));

            services.AdicionarInjecaoNativa();

            services.AddCors();

            services.AddResponseCompression();

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Desafio API",
                });
            });

            services.AddSwaggerGenNewtonsoftSupport();

            services.Configure<RouteOptions>(routeOptions =>
            {
                routeOptions.LowercaseUrls = true;
                routeOptions.LowercaseQueryStrings = true;
            });

            services.AddControllers()
                .ConfigureApiBehaviorOptions(apiBehaviorOptions =>
                {
                    apiBehaviorOptions.SuppressMapClientErrors = true;
                    apiBehaviorOptions.SuppressModelStateInvalidFilter = true;
                })
                .AddNewtonsoftJson(jsonOptions =>
                {
                    jsonOptions.SerializerSettings.Formatting = Formatting.None;
                    jsonOptions.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    jsonOptions.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                    jsonOptions.SerializerSettings.Converters.Add(new StringEnumConverter(new CamelCaseNamingStrategy()));
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory, IMapper mapper)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Validando os mapeamentos, se exitir algum problema, será lançado uma exceção.
            mapper.ConfigurationProvider.AssertConfigurationIsValid();

            // Middleware nativo para tratamento de exceções.
            app.UseExceptionHandler(builder =>
            {
                builder.Run(async context =>
                {
                    var exceptionHandler = context.Features.Get<IExceptionHandlerFeature>();
                    if (exceptionHandler != null)
                    {
                        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                        context.Response.ContentType = MediaTypeNames.Application.Json;

                        var logger = loggerFactory.CreateLogger<Startup>();
                        logger.LogError(exceptionHandler.Error, exceptionHandler.Error.Message);

                        var jsonText = JsonConvert.SerializeObject(new ApiResultado<ExececaoAplicacao>()
                            .Falha("Ocorreu um erro interno ao processar a sua solicitação."));

                        await context.Response.WriteAsync(jsonText);
                    }
                });
            });

            app.UseSwagger();

            app.UseSwaggerUI(options =>
            {
                options.DisplayRequestDuration();
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Desafio API");
            });

            app.UseHttpsRedirection();

            app.UseHsts();

            app.UseRouting();

            app.UseResponseCompression();

            app.UseCors(options =>
            {
                options.AllowAnyHeader();
                options.AllowAnyMethod();
                options.AllowAnyOrigin();
            });

            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}