using System.Net;
using System;
using CarBook.Infrastructure.Context;
using CarBook.Domain.Entities;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpClient();
builder.Services.AddDbContext<CarBookContext>();
builder.Services.AddIdentity<AppUser, AppRole>()
            .AddEntityFrameworkStores<CarBookContext>()
            .AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = new PathString("/Login/LoginAppUser"); // Yetkisiz kullanıcı korumalı sayfaya girince buraya yönlenir
    options.LogoutPath = new PathString("/Login/Logout");
});
builder.Services.AddControllersWithViews();
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
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});

//bu kodla projede area varsa, o area’nın çalışabilmesi için özel bir route (yönlendirme) tanımlamış oluyorsun.
app.Run();
