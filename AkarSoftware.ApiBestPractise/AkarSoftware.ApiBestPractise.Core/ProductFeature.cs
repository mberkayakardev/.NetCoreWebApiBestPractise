namespace AkarSoftware.ApiBestPractise.Core
{

    /// <summary>
    ///  Normal şartlar altında tüm entity ler base entity den kalıtım alır ama biz burda almamamızın temelindeki sebep
    ///  ProductFeature bir Product a bağlıdır updated ve created tarihlier otrak olacaktır
    ///  Bu sebeple biz burada bir Base entity den kalıtım almadan direk id yi elle verdik.
    /// </summary>
    public class ProductFeature
    {
        public int Id { get; set; }
        public string Color { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }

        public int ProductId { get; set; } // FK 
        public Product Product { get; set; }


    }
}
