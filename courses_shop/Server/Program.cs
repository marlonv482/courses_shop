using courses_shop.Server.Datos;
using courses_shop.Server.Repositories;
using Microsoft.AspNetCore.ResponseCompression;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddScoped<IRepositorioMasivo, RepositorioMasivo>();
builder.Services.AddScoped<IRepositorioGeneral, RepositorioGeneral>();

var cadenaConexionSQLConfiguration = new AccessoDatos(
    builder.Configuration.GetConnectionString("SQL")
);
builder.Services.AddSingleton(cadenaConexionSQLConfiguration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
