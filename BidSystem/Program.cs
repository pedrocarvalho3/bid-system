using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BidSystem.Data;
using BidSystem.Services;
using System;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<BidSystemContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BidSystemContext") ?? throw new InvalidOperationException("Connection string 'BidSystemContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<ItemService>();
builder.Services.AddScoped<StockMovementService>();
builder.Services.AddScoped<SeedingService>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
	var context = scope.ServiceProvider.GetRequiredService<BidSystemContext>();
	var seedingService = scope.ServiceProvider.GetRequiredService<SeedingService>();
	SeedingService.Seed(context); // Chama o método Seed para popular o banco de dados
}

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

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
