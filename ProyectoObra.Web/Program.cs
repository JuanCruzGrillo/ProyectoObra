using Microsoft.EntityFrameworkCore;
using ProyectoObra.Infrastructure.Context;
using Microsoft.AspNetCore.Identity;
using ProyectoObra.Application.Servicios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Conexi�n a la DB
var connectionString = builder.Configuration.GetConnectionString("Connection");
builder.Services.AddDbContext<AppDbContext>(
    options => options.UseSqlServer(connectionString)
);

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddScoped<CategoriaService>();
builder.Services.AddScoped<EmpresaService>();
builder.Services.AddScoped<RubroService>();
builder.Services.AddScoped<EmpleadoService>();
builder.Services.AddScoped<ContratacionService>();
builder.Services.AddScoped<ProductoService>();
builder.Services.AddScoped<ContratacionProductoService>();


builder.Services.AddControllersWithViews();
/* era para google
 * builder.Services.AddAuthentication()
   .AddGoogle(options =>
   {
       IConfigurationSection googleAuthNSection =
       config.GetSection("Authentication:Google");
       options.ClientId = googleAuthNSection["ClientId"];
       options.ClientSecret = googleAuthNSection["ClientSecret"];
   });
*/

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

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{(id)?}");
    endpoints.MapRazorPages();
});
app.Run();
