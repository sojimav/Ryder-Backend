using Serilog;
using Serilog.Events;
using Serilog.Sinks.Redis;

namespace Ryder.Api.Configurations
{
    public static class LogSettingsExtension
    {
        public static void SetupSeriLog(this IServiceCollection services, IConfiguration config)
        {
            var redisConfiguration = new RedisConfiguration();
            redisConfiguration.Host = "127.0.0.1:6379";

            var logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.Redis(redisConfiguration) // Ensure that Redis sink is properly configured
                .CreateLogger();

            logger.Information("This is an informational message...."); // Example log event


            Log.Information("Hello, world!");
        }
    }
}