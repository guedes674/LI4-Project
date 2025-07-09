/* namespace ComplicadaMente.Models
{
    public class Utilizador
    {
        // variaveis de instancia
        private int id;
        private string nome;
        private string email;
        private string telefone;
        private string morada;
        private string password;

        // construtor parametrizado
        public Utilizador(int id, string nome, string email, string telefone, string morada, string password)
        {
            this.id = id;
            this.nome = nome;
            this.email = email;
            this.telefone = telefone;
            this.morada = morada;
            this.password = password;
        }

        // getters e setters
        public int getId()
        {
            return this.id;
        }

        public void setId(int id)
        {
            this.id = id;
        }

        public string getNome()
        {
            return this.nome;
        }

        public void setNome(string nome)
        {
            this.nome = nome;
        }

        public string getEmail()
        {
            return this.email;
        }

        public void setEmail(string email)
        {
            this.email = email;
        }

        public string getTelefone()
        {
            return this.telefone;
        }

        public void setTelefone(string telefone)
        {
            this.telefone = telefone;
        }

        public string getMorada()
        {
            return this.morada;
        }

        public void setMorada(string morada)
        {
            this.morada = morada;
        }

        public string getPassword()
        {
            return this.password;
        }

        public void setPassword(string password)
        {
            this.password = password;
        }
    }
} */

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComplicadaMente.Models
{
    [Table("Utilizador")]
    public class Utilizador
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string? Nome { get; set; }

        [Required]
        [StringLength(75)]
        public string? Email { get; set; }

        [Required]
        [StringLength(15)]
        public string? Telefone { get; set; }

        [Required]
        [StringLength(150)]
        public string? Morada { get; set; }

        [Required]
        [StringLength(45)]
        public string? Password { get; set; }
    }
}