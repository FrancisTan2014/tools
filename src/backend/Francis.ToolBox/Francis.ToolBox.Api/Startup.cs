using AspectCore.Extensions.DependencyInjection;
using Francis.ToolBox.Api.Constants;
using Francis.ToolBox.Factories;
using Francis.ToolBox.SqlProviders;
using Francis.ToolBox.Services.Extenssions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SmartSql;
using System;

namespace Francis.ToolBox.Api
{
    public class Startup
    {
        const string CORS_NAME = "AllowAllOrigin";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services
                .AddSmartSql(builder =>
                {
                    builder.UseAlias(SmartSqlBuilder.DEFAULT_ALIAS);
                })
                .AddRepositoryFromAssembly(opts => {
                    opts.AssemblyString = Names.REPOSITORY_ASSEMBLY_NAME;
                    opts.Filter = (type) => type.Name.EndsWith("Repository");
                });
            services.RegisterServices(Names.SERVICE_ASSEMBLY_NAME, type => type.Name.EndsWith("Service"))
                .AddSingleton<SmartSqlBuilderFactory>()
                .AddSingleton<ISqlProviderFactory, SqlProviderFactory>();

            services.AddCors(
                options => options.AddPolicy(
                CORS_NAME,
                builder => builder.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin().AllowCredentials())
            );

            return services.BuildAspectInjectorProvider();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(CORS_NAME);
            app.UseMvc();
        }
    }
}
