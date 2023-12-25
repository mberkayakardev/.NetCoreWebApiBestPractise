using EfPractise.WEBUI.Datas.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<UdemyContext>(x => { x.UseSqlServer("server=192.168.1.185; database=UdemyContext; user id =locallogin; password=Qwerasdf0147; TrustServerCertificate=Yes"); });

var app = builder.Build();

app.UseStaticFiles(new StaticFileOptions { RequestPath = "/node_modules", FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "node_modules"))}) ;

app.UseRouting();
app.UseEndpoints(x =>
{

    x.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");

});



app.Run();
