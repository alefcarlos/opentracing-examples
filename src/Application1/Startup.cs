using Application1.Rules;
using Jaeger.Senders;
using Jaeger.Senders.Thrift;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OpenTracing;
using OpenTracing.Mock;
using System;

namespace Application1
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

            services.AddSingleton(serviceProvider =>
            {
                var loggerFactory = serviceProvider.GetRequiredService<ILoggerFactory>();
                var senderResolver = new SenderResolver(loggerFactory);

                Jaeger.Configuration.SenderConfiguration
                    .DefaultSenderResolver = senderResolver.RegisterSenderFactory<ThriftSenderFactory>();

                var config = Jaeger.Configuration.FromIConfiguration(loggerFactory, Configuration);

                return config.GetTracer();
            });

            services.AddSingleton<Random>();
            services.AddSingleton<Rule1>();
            services.AddSingleton<Rule2>();
            services.AddSingleton<Rule3>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
