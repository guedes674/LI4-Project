/* namespace ComplicadaMente.Models
{
    public class Encomenda
    {
        // variaveis de instancia
        private int id;
        private string estado;
        private double preco_total;
        private int id_utilizador;
        private int id_funcionario;
        private DateTime data_encomenda;

        // construtor parametrizado
        public Encomenda(int id, string estado, double preco_total, int id_utilizador, int id_funcionario, DateTime data_encomenda)
        {
            this.id = id;
            this.estado = estado;
            this.preco_total = preco_total;
            this.id_utilizador = id_utilizador;
            this.id_funcionario = id_funcionario;
            this.data_encomenda = data_encomenda;
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

        public string getEstado()
        {
            return this.estado;
        }

        public void setEstado(string estado)
        {
            this.estado = estado;
        }

        public double getPrecoTotal()
        {
            return this.preco_total;
        }

        public void setPrecoTotal(double preco_total)
        {
            this.preco_total = preco_total;
        }

        public int getIdUtilizador()
        {
            return this.id_utilizador;
        }

        public void setIdUtilizador(int id_utilizador)
        {
            this.id_utilizador = id_utilizador;
        }

        public int getIdFuncionario()
        {
            return this.id_funcionario;
        }

        public void setIdFuncionario(int id_funcionario)
        {
            this.id_funcionario = id_funcionario;
        }

        public DateTime getDataEncomenda()
        {
            return this.data_encomenda;
        }

        public void setDataEncomenda(DateTime data_encomenda)
        {
            this.data_encomenda = data_encomenda;
        }
    }
} */

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComplicadaMente.Models
{
    [Table("Encomenda")]
    public class Encomenda
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string? Estado { get; set; }

        [Required]
        [Column("Preco_Total", TypeName = "decimal(10, 2)")]
        public decimal PrecoTotal { get; set; }

        [Required]
        [Column("ID_Utilizador")]
        public int UtilizadorId { get; set; }

        [ForeignKey("UtilizadorId")]
        public Utilizador? Utilizador { get; set; }

        [Required]
        [Column("ID_Funcionario")]
        public int FuncionarioId { get; set; }

        [ForeignKey("FuncionarioId")]
        public Funcionario? Funcionario { get; set; }

        [Required]
        [Column("Data_Encomenda")]
        public DateOnly DataEncomenda { get; set; }

        public ICollection<QuebraCabecaEncomenda>? QuebraCabecaEncomendas { get; set; }
        public ICollection<PecaEncomenda>? PecaEncomendas { get; set; }
    }
}