using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ComplicadaMente.Data;
using ComplicadaMente.Models;

namespace ComplicadaMente.Pages
{
    public class LoginModel : PageModel
    {
        private readonly ComplicadaMenteContext _context;

        public LoginModel(ComplicadaMenteContext context)
        {
            _context = context;
        }

        [BindProperty]
        public string Email { get; set; } = string.Empty;

        [BindProperty]
        public string Password { get; set; } = string.Empty;

        public string? ErroMensagem { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            var funcionario = await _context.Funcionarios
                .FirstOrDefaultAsync(f => f.Email == Email);

            if (funcionario == null || !BCrypt.Net.BCrypt.Verify(Password, funcionario.Password))
            {
                ModelState.AddModelError(string.Empty, "Email ou password inválidos.");
                return Page();
            }

            HttpContext.Session.SetString("UserId", funcionario.Id.ToString());
            HttpContext.Session.SetString("UserEmail", funcionario.Email);

            return RedirectToPage("/Shop");
        }
    }
}
