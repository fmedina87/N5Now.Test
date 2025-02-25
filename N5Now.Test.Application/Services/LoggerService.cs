using N5Now.Test.Domain.Interfaces.Services;
using Serilog;
using System.Runtime.CompilerServices;

namespace N5Now.Test.Application.Services
{
    public class LoggerService(ILogger logger) : ILoggerService
    {
        protected readonly ILogger _logger = logger;
        public void LogInformation(string message, object data = null, [CallerMemberName] string methodName = "")
        {
            _logger.Information("➡️ [INFO] {Method}: {Message} | Datos: {@Data}", methodName, message, data);
        }

        public void LogWarning(string message, object data = null, [CallerMemberName] string methodName = "")
        {
            _logger.Warning("⚠️ [WARN] {Method}: {Message} | Datos: {@Data}", methodName, message, data);
        }

        public void LogError(Exception ex, [CallerMemberName] string methodName = "")
        {
            _logger.Error("❗ [ERROR] {Method}: {Exception}", methodName, ex);
        }
    }
}
