using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging.Configuration;
using Microsoft.Extensions.Logging;

namespace WebApplication3
{
    public static class CustomLoggerExtension
    {
        public static ILoggingBuilder AddFile(this ILoggingBuilder builder)
        {
            builder.Services.TryAddEnumerable(
                ServiceDescriptor.Singleton<ILoggerProvider, CustomLoggerProvider>()
            );

            LoggerProviderOptions.RegisterProviderOptions
                <MyCustomLoggerOptions, CustomLoggerProvider>(builder.Services);

            return builder;
        }

        public static ILoggingBuilder AddFile(this ILoggingBuilder builder, Action<MyCustomLoggerOptions> configure)
        {
            builder.AddFile();
            builder.Services.Configure(configure);
            return builder;
        }
    }
}
