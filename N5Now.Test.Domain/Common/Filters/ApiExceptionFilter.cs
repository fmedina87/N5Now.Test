using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using N5Now.Test.Domain.Common.Exceptions;
using N5Now.Test.Domain.Common.Reponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace N5Now.Test.Domain.Common.Filters
{
    public class ApiExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<ApiExceptionFilter> _logger;

        public ApiExceptionFilter(ILogger<ApiExceptionFilter> logger)
        {
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            _logger.LogError(context.Exception, "Error manejado por ApiExceptionFilter");

            int statusCode;
            string errorMessage;

            if (context.Exception is ApiException apiEx)
            {
                statusCode = (int)HttpStatusCode.BadRequest;
                errorMessage = apiEx.Message;
            }
            else
            {
                statusCode = (int)HttpStatusCode.InternalServerError;
                errorMessage = "Error interno de servidor";
            }
            var response = new ApiReponse<object>(errorMessage);
            context.Result = new ObjectResult(response)
            {
                StatusCode = statusCode
            };

            context.ExceptionHandled = true;
        }
    }
}
