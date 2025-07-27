using Microsoft.EntityFrameworkCore;
using ComplicadaMente.Data;
using ComplicadaMente.Services;
using ComplicadaMente.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ComplicadaMenteContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddSingleton<UserStateService>();
builder.Services.AddScoped<CartService>();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ComplicadaMenteContext>();
    context.Database.EnsureCreated();
    
    await SeedDefaultUsers(context);
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

// only for development purposes
// this method seeds the database with test users if none exist
static async Task SeedDefaultUsers(ComplicadaMenteContext context)
{
    // check if there are already users in the database
    if (await context.Utilizadores.AnyAsync() || await context.Funcionarios.AnyAsync())
    {
        return;
    }

    // create test users if none exist (client)
    var defaultUtilizador = new Utilizador
    {
        Nome = "Cliente Teste",
        Email = "cliente@teste.com",
        Telefone = "123456789",
        Morada = "Rua Teste, 123, 4000-000 Porto",
        Password = BCrypt.Net.BCrypt.HashPassword("123456")
    };

    // create test users if none exist (admin)
    var defaultFuncionario = new Funcionario
    {
        Nome = "Admin Sistema",
        Cargo = "Administrador",
        Email = "admin@sistema.com",
        Password = BCrypt.Net.BCrypt.HashPassword("admin123"),
        Salario = 1500.00m
    };

    // create a test QuebraCabeca
    var defaultQuebraCabeca = new QuebraCabeca
    {
        Nome = "Puzzle Teste",
        Tipo = "Clássico",
        Preco = 19.99m,
        Descricao = "Quebra-cabeça de teste para desenvolvimento.",
        Imagem = new byte[] { 0xFF, 0xD8, 0xFF }
    };

    context.Utilizadores.Add(defaultUtilizador);
    context.Funcionarios.Add(defaultFuncionario);
    context.QuebraCabecas.Add(defaultQuebraCabeca);

    await context.SaveChangesAsync();

    Console.WriteLine("Default users and QuebraCabeca created:");
    Console.WriteLine($"Cliente: {defaultUtilizador.Email} | Password: 123456");
    Console.WriteLine($"Admin: {defaultFuncionario.Email} | Password: admin123");
    Console.WriteLine($"QuebraCabeca: {defaultQuebraCabeca.Nome}");
}