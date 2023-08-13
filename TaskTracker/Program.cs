using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using TaskTracker.Data;
using TaskTracker.Data.Context;
using TaskTracker.Data.Services;
using MudBlazor;
using MudBlazor.Services;
using BootstrapBlazor;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddDbContext<TaskTrackerDbContext>();
builder.Services.AddScoped<ITaskTrackerDbContext, TaskTrackerDbContext>();
builder.Services.AddScoped<ITema, Tema>();
builder.Services.AddMudServices();
builder.Services.AddScoped<IColoresServices, ColoresServices>();
builder.Services.AddBootstrapBlazor();
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
