/* namespace ComplicadaMente.Models
{
    public class Funcionario
    {
        // variaveis de instancia
        private int id;
        private string nome;
        private string cargo;
        private string email;
        private string password;
        private double salario;

        // construtor parametrizado
        public Funcionario(int id, string nome, string cargo, string email, string password, double salario)
        {
            this.id = id;
            this.nome = nome;
            this.cargo = cargo;
            this.email = email;
            this.password = password;
            this.salario = salario;
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

        public string getCargo()
        {
            return this.cargo;
        }

        public void setCargo(string cargo)
        {
            this.cargo = cargo;
        }

        public string getEmail()
        {
            return this.email;
        }

        public void setEmail(string email)
        {
            this.email = email;
        }

        public string getPassword()
        {
            return this.password;
        }

        public void setPassword(string password)
        {
            this.password = password;
        }

        public double getSalario()
        {
            return this.salario;
        }

        public void setSalario(double salario)
        {
            this.salario = salario;
        }
    }
} */

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComplicadaMente.Models
{
    [Table("Funcionario")]
    public class Funcionario
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string? Nome { get; set; }

        [Required]
        [StringLength(75)]
        public string? Cargo { get; set; }

        [Required]
        [StringLength(75)]
        public string? Email { get; set; }

        [Required]
        [StringLength(45)]
        public string? Password { get; set; }

        [Required]
        [Column(TypeName = "decimal(9, 2)")]
        public decimal Salario { get; set; }
    }
}