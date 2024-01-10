using System.Text.Json.Serialization;

namespace AkarSoftware.ApiBestPractise.Core.DTOs
{
    // Generic olarak bir data alsın.
    public class CostumeResponseDto <T>
    {
        [JsonIgnore] // Json a dönüşte bunu ekleme diyoruz.
        public int StatusCode { get; set; } // Statü kodunu tutacağız
                                            // bu status code ü dış dünyaya açmak istemiyorum.
                                            // yani client lere endpointlere istekler sonucunda status code dönmek istemiyorum
                                            // clientler ilgili status code una sahip oluyorlar zaten 
                                            // illaki döneceğiniz response un bodysinde dönmeyeceğim 
        
        public T Data { get; set; } // Dataları tutacağız 
        public List<string> Errors { get; set; } // hatalar tutulacaktır.


        ///  Methods (new anahtar sözcüğü yerine ilgili methodlar vastıası ile oluşturabilirsiniz. Tercih sizin.)
        public static CostumeResponseDto<T> SuccessResult(int statuscode, T data) // verileri listelemek gibi 
        {
            return new CostumeResponseDto<T>() { Data = data , StatusCode = statuscode};
        }
        public static CostumeResponseDto<T> SuccessResult(int statuscode) // illaki data dönmem gerekmeyen bir durum olabilir // Update işlemi gibi yada delete işlemi gibi geriye data dönülmez.
        {
            return new CostumeResponseDto<T>() {StatusCode = statuscode};
        }
        public static CostumeResponseDto<T> FailResult( List<string> Error, int statuscode) // hataları döneceğim alan. 
        {
            return new CostumeResponseDto<T>() { StatusCode = statuscode , Errors = Error};
        }

        public static CostumeResponseDto<T> FailResult(string Error, int statuscode) // Bazen tek bir hata gelebilir (yani operasyonel bir süreç olabilir validasyon hatasından ziyade)
        {
            return new CostumeResponseDto<T>() { StatusCode = statuscode, Errors = new() {Error} };
        }


    }
}
