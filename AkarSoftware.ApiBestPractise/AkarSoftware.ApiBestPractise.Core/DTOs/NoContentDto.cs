using System.Text.Json.Serialization;

namespace AkarSoftware.ApiBestPractise.Core.DTOs
{
    public class NoContentDto
    {
        [JsonIgnore] // Json a dönüşte bunu ekleme diyoruz.
        public int StatusCode { get; set; } // Statü kodunu tutacağız
                                            // bu status code ü dış dünyaya açmak istemiyorum.
                                            // yani client lere endpointlere istekler sonucunda status code dönmek istemiyorum
                                            // clientler ilgili status code una sahip oluyorlar zaten 
                                            // illaki döneceğiniz response un bodysinde dönmeyeceğim 

        public List<string> Errors { get; set; } // hatalar tutulacaktır.


        ///  Methods (new anahtar sözcüğü yerine ilgili methodlar vastıası ile oluşturabilirsiniz. Tercih sizin.)
        public static NoContentDto SuccessResult(int statuscode) // illaki data dönmem gerekmeyen bir durum olabilir // Update işlemi gibi yada delete işlemi gibi geriye data dönülmez.
        {
            return new NoContentDto() { StatusCode = statuscode };
        }
        public static NoContentDto FailResult(List<string> Error, int statuscode) // hataları döneceğim alan. 
        {
            return new NoContentDto() { StatusCode = statuscode, Errors = Error };
        }

        public static NoContentDto FailResult(string Error, int statuscode) // Bazen tek bir hata gelebilir (yani operasyonel bir süreç olabilir validasyon hatasından ziyade)
        {
            return new NoContentDto() { StatusCode = statuscode, Errors = new() { Error } };
        }

    }
}
