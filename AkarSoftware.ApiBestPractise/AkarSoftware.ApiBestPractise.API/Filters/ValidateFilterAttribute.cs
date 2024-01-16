using AkarSoftware.ApiBestPractise.Core.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AkarSoftware.ApiBestPractise.API.Filters
{
    public class ValidateFilterAttribute : ActionFilterAttribute
    {

        // Çalışmadan hemen öncesinde çalışması için Executing methodu ezildi. (override) 
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            // Fluent validator kütüphanesi ModelState ile entegredir. fluent validaton dan alınan bir hata modelstate e maplenir.
            
            if (!context.ModelState.IsValid) 
            {
                var errors = context.ModelState.Values.SelectMany(x => x.Errors).Select(c=> c.ErrorMessage);
                // Hata sınıfındaki hataların içerisinden direk  mesajlar string olarak alındı 
                
                // Client hatası olduğu için 400 lü hata döneceğiz.
                context.Result = new BadRequestObjectResult(CostumeResponseDto<NoContentDto>.FailResult(errors.ToList(),400));
            
            }


        }
    }
}
