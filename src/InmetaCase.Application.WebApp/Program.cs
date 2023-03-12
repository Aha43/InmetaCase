using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Hosting.StaticWebAssets;
using InmetaCase.Application.WebApp.Data;
using MudBlazor.Services;
using InmetaCase.Infrastructure.Database;
using InmetaCase.Infrastructure.Http;
using InmetaCase.Business;

var builder = WebApplication.CreateBuilder(args);

StaticWebAssetsLoader.UseStaticWebAssets(builder.Environment, builder.Configuration);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddMudServices();

// Add application services
var api = builder.Configuration["api"];
api = (api == null) ? "db" : "http";
if (api.Equals("db"))
{
    builder.Services.AddInmetaCaseDatabaseApi(builder.Configuration);
}
else if (api.Equals("http"))
{
    builder.Services.AddInmetaCaseHttpClientsApi(builder.Configuration);
}
else
{
    throw new Exception($"Uknown api '{api}");
}
builder.Services.AddInmetaBusiness();

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

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();