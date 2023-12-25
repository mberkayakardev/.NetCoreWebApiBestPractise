using EfPractise.WEBUI.Datas.Contexts;
using EfPractise.WEBUI.Datas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EfPractise.WEBUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly UdemyContext _context;

        public HomeController(UdemyContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            //Products p = new Products();
            //var result = _context.Entry<Products>(p).State;
            //var result2 = _context.Add(p);

            var product = _context.Products.FirstOrDefault();
            var result3 = _context.Entry<Products>(product).State;

            product.Name = "Hasan";
            var result4 = _context.Entry<Products>(product).State;

            _context.SaveChanges();

            var product2 = _context.Products.FirstOrDefault();
            var result32 = _context.Entry<Products>(product2).State;
            _context.Entry<Products>(product2).State = EntityState.Detached;
            var result324 = _context.Entry<Products>(product2).State;

            product2.Name = "Mehmet";
            var result322 = _context.Entry<Products>(product2).State;
            var resultbilmemne = _context.Entry<Products>(product2).State = EntityState.Modified;


            _context.SaveChanges();






            //_context.Products.Add();
            return View();
        }

    }
}
