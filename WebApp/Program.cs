using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using WebApp.Data;
using WebApp.Services;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
// Add services to the container.

builder.Services.AddControllersWithViews();

builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IOrderStatusService, OrderStatusService>();
builder.Services.AddScoped<IOrderHistoryService, OrderHistoryService>();
builder.Services.AddScoped<IOpportunityService,OpportunityService>();
builder.Services.AddScoped<IOpportunityStatusService,OpportunityStatusService>();
builder.Services.AddScoped<IOpportunityHistoryService,OpportunityHistoryService>();
builder.Services.AddScoped<IAnnotationTypeService,AnnotationTypeService>();
builder.Services.AddScoped<IAnnotationService,AnnotationService>();
builder.Services.AddScoped<IEventService,EventService>();
builder.Services.AddScoped<IEventTypeService,EventTypeService>();


builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderStatusRepository, OrderStatusRepository>();
builder.Services.AddScoped<IOrderHistoryRepository, OrderHistoryRepository>();
builder.Services.AddScoped<IOpportunityRepository, OpportunityRepository>();
builder.Services.AddScoped<IOpportunityStatusRepository, OpportunityStatusRepository>();
builder.Services.AddScoped<IOpportunityHistoryRepository, OpportunityHistoryRepository>();
builder.Services.AddScoped<IAnnotationTypeRepository,AnnotationTypeRepository>();
builder.Services.AddScoped<IAnnotationRepository,AnnotationRepository>();
builder.Services.AddScoped<IEventRepository,EventRepository>();
builder.Services.AddScoped<IEventTypeRepository,EventTypeRepository>();


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

app.MapFallbackToFile("index.html");

app.Run();
