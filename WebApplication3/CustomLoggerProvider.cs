
using Microsoft.Extensions.Options;
using System.Collections.Concurrent;

namespace WebApplication3
{
    [ProviderAlias("FileProvider")]
    public sealed class CustomLoggerProvider : ILoggerProvider
    {
        private MyCustomLoggerOptions _currentOptions;
        private IDisposable? _updateToken;
        private readonly ConcurrentDictionary<string, ILogger> _loggers =
            new ConcurrentDictionary<string, ILogger>(StringComparer.OrdinalIgnoreCase);

        public CustomLoggerProvider(IOptionsMonitor<MyCustomLoggerOptions> options)
        {
            _currentOptions = options.CurrentValue;
            _updateToken = options.OnChange(updatedOptions => _currentOptions = updatedOptions);
        }

        public ILogger CreateLogger(string categoryName)
        {
            return _loggers.GetOrAdd(categoryName, key => new CustomLogger(
                categoryName,
                GetCurrentOptions));
        }

        private MyCustomLoggerOptions GetCurrentOptions() => _currentOptions;

        public void Dispose()
        {
            _updateToken?.Dispose();
            _updateToken = null;
        }
    }
}
