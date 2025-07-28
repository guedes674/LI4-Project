using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using ComplicadaMente.Data;
using ComplicadaMente.Services;
using ComplicadaMente.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ComplicadaMenteContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

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
    /* byte[] imageBytes = File.ReadAllBytes("/home/guedes674/Documents/li4/LI4-Project/ComplicadaMente/Media/cubo de rubik.png"); */
    byte[] puzzle_madeira = File.ReadAllBytes("/home/guedes674/Documents/li4/LI4-Project/ComplicadaMente/Media/puzzle_madeira.png");
    byte[] puzzle_madeira_1 = File.ReadAllBytes("/home/guedes674/Documents/li4/LI4-Project/ComplicadaMente/Media/puzzle_madeira_1.png");
    byte[] puzzle_madeira_2 = File.ReadAllBytes("/home/guedes674/Documents/li4/LI4-Project/ComplicadaMente/Media/puzzle_madeira_2.png");
    byte[] puzzle_madeira_3 = File.ReadAllBytes("/home/guedes674/Documents/li4/LI4-Project/ComplicadaMente/Media/puzzle_madeira_3.png");
    byte[] puzzle_madeira_4 = File.ReadAllBytes("/home/guedes674/Documents/li4/LI4-Project/ComplicadaMente/Media/puzzle_madeira_4.png");

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

    // add default users to the context
    context.Utilizadores.Add(defaultUtilizador);
    context.Funcionarios.Add(defaultFuncionario);

    /* var quebra_cabeca = new QuebraCabeca
    {
        Nome = $"Cubo de Rubik",
        Tipo = "Clássico",
        Preco = 15.99m,
        Descricao = $"Cubo de Rubik simples e divertido, ideal para todas as idades.",
        Imagem = imageBytes,
        Quantidade = 5
    };
    context.QuebraCabecas.Add(quebra_cabeca); */

    // add a quebra-cabeça de madeira
    var quebra_cabeca_madeira = new QuebraCabeca
    {
        Nome = $"Quebra-Cabeça Madeira",
        Tipo = "Madeira",
        Preco = 25.99m,
        Descricao = $"Quebra-cabeça de madeira com peças grandes e resistentes.",
        Imagem = puzzle_madeira,
        Quantidade = 10
    };
    context.QuebraCabecas.Add(quebra_cabeca_madeira);

    // Save to get IDs
    await context.SaveChangesAsync();

    byte[][] manualImages = new byte[][] { puzzle_madeira_1, puzzle_madeira_2, puzzle_madeira_3, puzzle_madeira_4 };
    // add peças to the quebra-cabeça de madeira
    for (int i = 0; i < 4; i++)
    {
        var manual_puzzle_madeira = new ManualStep
        {
            StepNumber = i + 1,
            Nome = $"Passo {i + 1}",
            Descricao = $"Manual de instruções para o quebra-cabeça de madeira {i + 1}.",
            Imagem = manualImages[i],
            QuebraCabecaId = quebra_cabeca_madeira.Id
        };
        context.ManualSteps.Add(manual_puzzle_madeira);
    }

    await context.SaveChangesAsync();

    Console.WriteLine("Default users, QuebraCabeca and Peca created:");
    Console.WriteLine($"Cliente: {defaultUtilizador.Email} | Password: 123456");
    Console.WriteLine($"Admin: {defaultFuncionario.Email} | Password: admin123");
}