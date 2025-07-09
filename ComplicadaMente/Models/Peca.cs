/* using System.Reflection.Metadata;

namespace ComplicadaMente.Models
{
    public class Peca
    {
        // variaveis de instancia
        private int id;
        private string nome;
        private string tipo;
        private double preco;
        private int id_quebra_cabeca;
        private string descricao;
        private Blob imagem;

        // construtor parametrizado
        public Peca(int id, string nome, string tipo, double preco, int id_quebra_cabeca, string descricao, Blob imagem)
        {
            this.id = id;
            this.nome = nome;
            this.tipo = tipo;
            this.preco = preco;
            this.id_quebra_cabeca = id_quebra_cabeca;
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

        public int getIdQuebraCabeca()
        {
            return this.id_quebra_cabeca;
        }

        public void setIdQuebraCabeca(int id_quebra_cabeca)
        {
            this.id_quebra_cabeca = id_quebra_cabeca;
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
    [Table("Peca")]
    public class Peca
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
        [Column("ID_Quebra_Cabeca")]
        public int QuebraCabecaId { get; set; }

        [ForeignKey("QuebraCabecaId")]
        public QuebraCabeca? QuebraCabeca { get; set; }

        [Required]
        [StringLength(130)]
        public string? Descricao { get; set; }

        [Required]
        public byte[]? Imagem { get; set; }

        public ICollection<PecaEncomenda>? PecaEncomendas { get; set; }
    }
}