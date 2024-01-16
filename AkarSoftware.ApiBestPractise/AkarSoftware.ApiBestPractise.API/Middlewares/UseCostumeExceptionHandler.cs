using AkarSoftware.ApiBestPractise.Core.DTOs;
using AkarSoftware.ApiBestPractise.Services.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace AkarSoftware.ApiBestPractise.API.Middlewares
{
    public static class UseCostumeExceptionHandler 
    {
        public static void UseCostumeException(this IApplicationBuilder app)
        {
            // Framework içerisinde gelen hazır method. geriye hazır model döner. biz bunu costumize edecez
            app.UseExceptionHandler(opt =>
            {
                // Kısa devre yapması için
                opt.Run(async context =>
                {
                    var exceptionFeature = context.Features.Get<IExceptionHandlerFeature>();

                    // Eğerki kendimiz bir hata atacaksak (costume exception) burada 400 lü hata kodları dönmemiz gerekecek
                    // Eğer hata server tabanlı ise bizler bu etapta 500 lü hata kodları dönmemiz gerekecektir. 
                    // Client tabanlı bir hata atmak isteyebilirim (business için)

                    // Kendi Exception Tipimiz ise 
                    var statusCode = exceptionFeature.Error switch
                    {
                        ClientSideException => 400,
                        _ => 500
                    };

                    context.Response.StatusCode = statusCode;
                    context.Response.ContentType = "application/json";
                    var exceptionDto = CostumeResponseDto<NoContentDto>.FailResult(exceptionFeature.Error.Message.ToString(), statusCode);

                    // .Net SDK si içerisinde built in bir şekilde sınıf geldi artık Newtonsoft u eklemen gerekmiyor
                    await context.Response.WriteAsync(JsonSerializer.Serialize(exceptionDto));

                });
            }); 
        }

    }
}
