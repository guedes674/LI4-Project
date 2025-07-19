using Microsoft.EntityFrameworkCore;
using ComplicadaMente.Data;
using ComplicadaMente.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ComplicadaMenteContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor(options =>
{
    options.DetailedErrors = builder.Environment.IsDevelopment();
});

var app = builder.Build();

// adding a user test only to test login
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ComplicadaMenteContext>();
    context.Database.EnsureCreated();

    if (!context.Funcionarios.Any())
    {
        context.Funcionarios.Add(new Funcionario
        {
            Nome = "Admin Test",
            Cargo = "Administrador",
            Email = "admin@test.com",
            Password = BCrypt.Net.BCrypt.HashPassword("123456"),
            Salario = 1500.00m
        });
        context.SaveChanges();
    }
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseSession();

app.MapRazorPages();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();