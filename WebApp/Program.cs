using Microsoft.Net.Http.Headers;
using Azure;
using Azure.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using WebApp.Data;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
// Add services to the container.

builder.Services.AddControllersWithViews();

//Add SpaStaticFiles

builder.Services.AddSpaStaticFiles(configuration =>
{
    configuration.RootPath = "ClientApp/dist";
});

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

//Add spaPath 
var spaPath = "/app";
if(app.Environment.IsDevelopment()){
    app.MapWhen(y => y.Request.Path.StartsWithSegments(spaPath), builder => {
        builder.UseSpa(spa => {
            spa.UseProxyToSpaDevelopmentServer("http://localhost:44445");
        });
    });
}else{
    app.UseStaticFiles();
    app.UseSpa(spa =>
    {
        spa.Options.SourcePath = "ClientApp"; // La carpeta raíz de tu aplicación SPA.
        spa.Options.DefaultPageStaticFileOptions = new StaticFileOptions
        {
            OnPrepareResponse = ctx =>
            {
                var headers = ctx.Context.Response.GetTypedHeaders();
                headers.CacheControl = new CacheControlHeaderValue
                {
                    NoCache = true,
                    NoStore = true,
                    MustRevalidate = true
                };
            }
        };
    });
}

app.MapFallbackToFile("index.html");

app.Run();
