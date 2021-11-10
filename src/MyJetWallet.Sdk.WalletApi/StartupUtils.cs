using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyJetWallet.Sdk.Authorization.Http;
using MyJetWallet.Sdk.RestApiTrace;
using MyJetWallet.Sdk.Service;
using MyJetWallet.Sdk.WalletApi.Common;
using MyJetWallet.Sdk.WalletApi.Middleware;
using Prometheus;
using SimpleTrading.BaseMetrics;
using SimpleTrading.ServiceStatusReporterConnector;
using SimpleTrading.TokensManager;
using Microsoft.OpenApi.Models;

namespace MyJetWallet.Sdk.WalletApi
{
    public static class StartupUtils
    {
        private const string SessionEncodingKeyEnv = "SESSION_ENCODING_KEY";

        /// <summary>
        /// Setup swagger ui ba
        /// </summary>
        /// <param name="services"></param>
        public static void SetupSwaggerDocumentation(this IServiceCollection services)
        {
            /*
            services.AddSwaggerDocument(o =>
            {
                o.Title = "MyJetWallet API";
                o.GenerateEnumMappingDescription = true;

                o.AddSecurity("Bearer", Enumerable.Empty<string>(),
                    new OpenApiSecurityScheme
                    {
                        Type = OpenApiSecuritySchemeType.ApiKey,
                        Description = "Bearer Token",
                        In = OpenApiSecurityApiKeyLocation.Header,
                        Name = "Authorization"
                    });
            });
            */
            
            /*
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "MyJetWallet API", 
                    Version = "v1"
                });
                
                c.AddSecurityDefinition("auth", new OpenApiSecurityScheme()
                {
                    Type = SecuritySchemeType.ApiKey,
                    BearerFormat = "Bearer <api key>"
                });
            });
            services.AddSwaggerGenNewtonsoftSupport();
            */
        }

        /// <summary>
        /// Headers settings
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigurateHeaders(this IServiceCollection services)
        {
            services.Configure<ForwardedHeadersOptions>(options =>
            {
                options.ForwardedHeaders =
                    ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
            });
        }

        public static void SetupWalletServices(IServiceCollection services)
        {
            services.SetupSwaggerDocumentation();
            services.ConfigurateHeaders();
            services.AddControllers(options =>
            {

            }).AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new MyDoubleConverter());
            });

            services
                .AddAuthentication(o => { o.DefaultScheme = "Bearer"; })
                .AddScheme<MyAuthenticationOptions, RootSessionAuthHandler>("Bearer", o => { });

            services
                .AddAuthorization(o => o.SetupWalletApiPolicy());
        }

        public static void SetupWalletApplication(IApplicationBuilder app, IWebHostEnvironment env, 
            bool enableApiTrace, string swaggerOffsetName)
        {
            if (env.IsDevelopment())
            {
                TokensManager.DebugMode = true;
                RootSessionAuthHandler.IsDevelopmentEnvironment = true;
            }


            app.UseForwardedHeaders();

            if (enableApiTrace)
            {
                app.UseMiddleware<ApiTraceMiddleware>();
                Console.WriteLine("API Trace is Enabled");
            }
            else
            {
                Console.WriteLine("API Trace is Disabled");
            }


            app.BindMetricsMiddleware();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseStaticFiles();

            app.UseMetricServer();

            app.BindServicesTree(Assembly.GetExecutingAssembly());

            GetSessionEncodingKey();

            app.BindIsAlive(GetEnvVariables());

            /*
            app.UseSwagger(options =>
            {
                options.RouteTemplate = $"/swagger/{swaggerOffsetName}/{{swaggerOffsetName}}/swagger.json";
            });
            
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"/swagger/{swaggerOffsetName}/v1/swagger.json", $"Wallet API: {swaggerOffsetName}");
            });
            */
            
            /*
            app.UseOpenApi(settings =>
            {
                settings.Path = $"/swagger/{swaggerOffsetName}/swagger.json";
            });

            app.UseSwaggerUi3(settings =>
            {
                settings.EnableTryItOut = true;
                settings.Path = $"/swagger/{swaggerOffsetName}";
                settings.DocumentPath = $"/swagger/{swaggerOffsetName}/swagger.json";

            });
            */
            

            app.UseMiddleware<ExceptionLogMiddleware>();
            app.UseMiddleware<DebugMiddleware>();

            app.UseAuthentication();
            app.UseAuthorization();
            
        }

        public static string GetSessionEncodingKey()
        {
            var key = Environment.GetEnvironmentVariable(SessionEncodingKeyEnv);

            if (string.IsNullOrEmpty(key))
                throw new Exception($"Env Variable {SessionEncodingKeyEnv} is not found");

            return key;
        }

        private static IDictionary<string, string> GetEnvVariables()
        {
            var autoLoginKey = GetSessionEncodingKey();

            return new Dictionary<string, string>
            {
                { SessionEncodingKeyEnv, autoLoginKey.EncodeToSha1().ToHexString() }
            };
        }
    }
}