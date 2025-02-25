using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace N5Now.Test.Domain.Interfaces.Services
{
    public interface ILoggerService
    {
        void LogInformation(string message, object data = null, string methodName = "");
        void LogWarning(string message, object data = null, string methodName = "");
        void LogError(Exception ex, string methodName = "");
    }
}
