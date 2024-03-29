﻿using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
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
using adminBlazor.Models;
using adminBlazor;
using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.Authorization;


var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
builder.Services.AddBlazoredModal();
builder.Services.AddRazorPages();
    builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<IDataService, DataLocalService>();
builder.Services.AddScoped<IDataService, DataApiService>();


builder.Services.AddScoped<IVocListService, VocListLocalService>();

builder.Services.AddOptions();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<CustomStateProvider>();
builder.Services.AddScoped<AuthenticationStateProvider>(s => s.GetRequiredService<CustomStateProvider>());
builder.Services.AddScoped<IAuthService, AuthService>();


builder.Services.AddHttpClient();
builder.Services.AddBlazoredLocalStorage();



// Add the controller of the app
builder.Services.AddControllers();

// Add the localization to the app and specify the resources path
builder.Services.AddLocalization(opts => { opts.ResourcesPath = "Resources"; });

// Configure the localization
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    // Set the default culture of the web site
    options.DefaultRequestCulture = new RequestCulture(new CultureInfo("en-US"));

    // Declare the supported culture
    options.SupportedCultures = new List<CultureInfo> { new CultureInfo("en-US"), new CultureInfo("fr-FR") };
    options.SupportedUICultures = new List<CultureInfo> { new CultureInfo("en-US"), new CultureInfo("fr-FR") };
});

builder.Logging.AddConfiguration(builder.Configuration.GetSection("Logging"));


builder.Services
    .AddBlazorise()
    .AddBootstrapProviders()
    .AddFontAwesomeIcons();

builder.Services.AddBlazoredSessionStorage();

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