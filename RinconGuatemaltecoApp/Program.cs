using Microsoft.EntityFrameworkCore;
using RinconGuatemaltecoApp.Data;

var builder = WebApplication.CreateBuilder(args);

// Agrega el servicio de DbContext con la conexión a la base de datos
builder.Services.AddDbContext<RinconGuatemaltecoContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Agregar soporte para controladores y vistas (MVC)
builder.Services.AddControllersWithViews();

// También puedes mantener Razor Pages si quieres usarlas
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Mapea las rutas de los controladores
app.MapControllerRoute(
     name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");

// Mapea Razor Pages
app.MapRazorPages();

app.Run();
