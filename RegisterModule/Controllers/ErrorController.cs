using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using RegisterModule.Models;
using Serilog;
using System.Net;

namespace RegisterModule.Controllers
{
    public class ErrorController : Controller
    {
        [Route("/error")]
        public IActionResult Error()
        {
            Log.Logger = new LoggerConfiguration()
              .MinimumLevel.Debug()
              .WriteTo.File("ErrorLogs/ErrorLog.txt", rollingInterval: RollingInterval.Day)
              .CreateLogger();

            var exception = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var statusCode = exception.Error.GetType().Name switch
            {
                "ArgumentException" => HttpStatusCode.BadRequest,
                _ => HttpStatusCode.ServiceUnavailable
            };

            Error e = new Error() {StatusCode = (int)statusCode,Source=exception.Error.Source,ErrorMessage=exception.Error.Message,StackTrace=exception.Error.StackTrace};
            Log.Error(e.GetErrorDetails());
            return View();
        }
    }
}
