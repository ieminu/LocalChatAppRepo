using LocalChatApp.Hubs;
using LocalChatApp.Models;
using LocalChatApp.Pages;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddControllersWithViews();

builder.Services.AddSignalR();

builder.Services.AddDbContext<MyDBContext>(options =>
	options.UseSqlServer("Data Source=localhost;Initial Catalog=myDatabase;Integrated Security=True;TrustServerCertificate=true;")
);

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(option =>
{
	option.LoginPath = "/Login";
	option.ExpireTimeSpan = TimeSpan.FromDays(1);
});

builder.Services.AddTransient<LoginModel>();

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

app.UseAuthentication();

app.UseAuthorization();
app.MapHub<ChatHub>("/chatHub");
app.MapRazorPages();

app.Run();
