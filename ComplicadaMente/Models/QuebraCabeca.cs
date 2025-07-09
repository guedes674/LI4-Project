/* using System.Reflection.Metadata;

namespace ComplicadaMente.Models
{
    public class QuebraCabeca
    {
        // variaveis de instancia
        private int id;
        private string nome;
        private string tipo;
        private double preco;
        private string descricao;
        private Blob imagem;

        // construtor parametrizado
        public QuebraCabeca(int id, string nome, string tipo, double preco, string descricao, Blob imagem)
        {
            this.id = id;
            this.nome = nome;
            this.tipo = tipo;
            this.preco = preco;
            this.descricao = descricao;
            this.imagem = imagem;
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

        public string getTipo()
        {
            return this.tipo;
        }

        public void setTipo(string tipo)
        {
            this.tipo = tipo;
        }

        public double getPreco()
        {
            return this.preco;
        }

        public void setPreco(double preco)
        {
            this.preco = preco;
        }

        public string getDescricao()
        {
            return this.descricao;
        }

        public void setDescricao(string descricao)
        {
            this.descricao = descricao;
        }

        public Blob getImagem()
        {
            return this.imagem;
        }

        public void setImagem(Blob imagem)
        {
            this.imagem = imagem;
        }
    }
} */

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComplicadaMente.Models
{
    [Table("Quebra_Cabeca")]
    public class QuebraCabeca
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string? Nome { get; set; }

        [Required]
        [StringLength(50)]
        public string? Tipo { get; set; }

        [Required]
        [Column(TypeName = "decimal(9, 2)")]
        public decimal Preco { get; set; }

        [Required]
        [StringLength(130)]
        public string? Descricao { get; set; }

        [Required]
        public byte[]? Imagem { get; set; }

        public ICollection<QuebraCabecaEncomenda>? QuebraCabecaEncomendas { get; set; }
    }
}