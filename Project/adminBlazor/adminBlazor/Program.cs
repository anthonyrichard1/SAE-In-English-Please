﻿using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using adminBlazor.Data;
using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;
using Blazored.LocalStorage;
using adminBlazor.Services;
using Blazored.Modal;
using Microsoft.AspNetCore.Localization;
using System.Globalization;
using Microsoft.Extensions.Options;
using Microsoft.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpClient();
builder.Services.AddHttpClient("GitHub", httpClient =>
{
    httpClient.BaseAddress = new Uri("https://api.github.com/");

    // using Microsoft.Net.Http.Headers;
    // The GitHub API requires two headers.
    httpClient.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/vnd.github.v3+json");
    httpClient.DefaultRequestHeaders.Add(HeaderNames.UserAgent, "HttpRequestsSample");
});
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddScoped<IDataService, DataLocalService>();
<<<<<<< HEAD
builder.Services.AddScoped<IDataService, DataApiService>();
=======
builder.Services.AddScoped<IVocListService, VocListLocalService>();
//builder.Services.AddScoped<IDataService, DataApiService>();
>>>>>>> f62a4611bcbbfe0ed449a38e75f10df8ce6a5bbe

builder.Services.AddHttpClient();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddBlazoredModal();

// Add the controller of the app
builder.Services.AddControllers();

// Add the localization to the app and specify the resources path
builder.Services.AddLocalization(opts => { opts.ResourcesPath = "Resources"; });

// Configure the localtization
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    // Set the default culture of the web site
    options.DefaultRequestCulture = new RequestCulture(new CultureInfo("en-US"));

    // Declare the supported culture
    options.SupportedCultures = new List<CultureInfo> { new CultureInfo("en-US"), new CultureInfo("fr-FR") };
    options.SupportedUICultures = new List<CultureInfo> { new CultureInfo("en-US"), new CultureInfo("fr-FR") };
});


builder.Services
   .AddBlazorise()
   .AddBootstrapProviders()
   .AddFontAwesomeIcons();


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

// Get the current localization options
var options = ((IApplicationBuilder)app).ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();

if (options?.Value != null)
{
    // use the default localization
    app.UseRequestLocalization(options.Value);
}

// Add the controller to the endpoint
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();

