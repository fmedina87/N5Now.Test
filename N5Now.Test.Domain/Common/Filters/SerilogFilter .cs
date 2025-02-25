using Microsoft.AspNetCore.Mvc.Filters;
using Serilog;
using System.Diagnostics;
namespace N5Now.Test.Domain.Common.Filters
{
    public class SerilogFilter : IActionFilter
    {
        private readonly ILogger _logger;
        private Stopwatch _stopwatch;

        public SerilogFilter(ILogger logger)
        {
            _logger = logger;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            _stopwatch = Stopwatch.StartNew();

            var actionName = context.ActionDescriptor.DisplayName;
            var parameters = context.ActionArguments;

            _logger.Information("➡️ Ejecutando acción: {Action} | Parámetros: {@Parameters}", actionName, parameters);
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            _stopwatch.Stop();

            var actionName = context.ActionDescriptor.DisplayName;
            var elapsedTime = _stopwatch.ElapsedMilliseconds;

            if (context.Exception == null)
            {
                _logger.Information("✅ Acción completada: {Action} | Tiempo: {Elapsed}ms", actionName, elapsedTime);
            }
            else
            {
                _logger.Error("❌ Error en acción: {Action} | Tiempo: {Elapsed}ms | Error: {Error}",
                    actionName, elapsedTime, context.Exception);
            }
        }
    }
}
