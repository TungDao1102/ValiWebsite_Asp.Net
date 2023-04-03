using Microsoft.EntityFrameworkCore;
using ValiWebsite.Models;
using ValiWebsite.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
// var connectionString = builder.Configuration.GetConnectionString("QlbanVaLiContext");
builder.Services.AddSession();
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddDbContext<QlbanVaLiContext>(options => 
options.UseSqlServer(builder.Configuration.GetConnectionString("QlbanVaLiContext")));
builder.Services.AddScoped<ILoaiSpRepository, LoaiSpRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline. 
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseSession();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "Admin",
      pattern: "{area:exists}/{controller=HomeAdmin}/{action=Index}/{id?}"
    );
	endpoints.MapControllerRoute(
	 name: "Test",
	 pattern: "{area:exists}/{controller=Test}/{action=Index}/{id?}"
   );
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
