using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using System.Net;
using System.Text.Json;

namespace Shared.Exceptions
{
    public static class GlobalExceptionHandler
    {
        public static void UseSharedErrorHandler(this IApplicationBuilder app, IHostEnvironment env)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        // Log lỗi chi tiết thông qua Serilog
                        //Log.Error(contextFeature.Error, "Xảy ra lỗi chưa được xử lý (Unhandled Exception)");
                        var errorResponse = new
                        {
                            Success = false,
                            Caption = "Lỗi hệ thống",
                            Message = env.IsDevelopment()
                                ? contextFeature.Error.Message
                                : "Đã có lỗi xảy ra. Vui lòng thử lại sau hoặc liên hệ bộ phận hỗ trợ.",
                            Data = (object?)null,
                            StackTrace = env.IsDevelopment() ? contextFeature.Error.StackTrace : null
                        };

                        var jsonOptions = new JsonSerializerOptions
                        {
                            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                            WriteIndented = true
                        };

                        await context.Response.WriteAsync(JsonSerializer.Serialize(errorResponse, jsonOptions));
                    }
                });
            });
        }
    }
}