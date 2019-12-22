using System;
using System.Reflection;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NLog.Web;
using WorkerServiceMediatr.Service;
using WorkerServiceMediatr.Service.Contracts;

namespace WorkerServiceMediatr
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
            try
            {
                logger.Debug("init main");
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception exception)
            {
                logger.Error(exception, "Stopped program because of exception");
                throw;
            }
            finally
            {
                NLog.LogManager.Shutdown();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            
                .UseNLog()
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddMediatR(Assembly.GetExecutingAssembly());
                    services.AddTransient<INotificationService, NotificationService>();
                    services.AddHostedService<Worker>();
                });
    }
}
