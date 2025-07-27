/* namespace ComplicadaMente.Models
{
    public class PecaEncomenda
    {
        // variaveis de instancia
        private int PecaId;
        private int EncomendaId;
        private int quantidade;

        // construtor parametrizado
        public PecaEncomenda(int PecaId, int EncomendaId, int quantidade)
        {
            this.PecaId = PecaId;
            this.EncomendaId = EncomendaId;
            this.quantidade = quantidade;
        }

        // getters e setters
        public int getIdPeca()
        {
            return this.PecaId;
        }

        public void setIdPeca(int PecaId)
        {
            this.PecaId = PecaId;
        }

        public int getIdEncomenda()
        {
            return this.EncomendaId;
        }

        public void setIdEncomenda(int EncomendaId)
        {
            this.EncomendaId = EncomendaId;
        }

        public int getQuantidade()
        {
            return this.quantidade;
        }

        public void setQuantidade(int quantidade)
        {
            this.quantidade = quantidade;
        }
    }
} */

using System.ComponentModel.DataAnnotations.Schema;

namespace ComplicadaMente.Models
{
    [Table("Peca_Encomenda")]
    public class PecaEncomenda
    {
        [Column("ID_Peca")]
        public int PecaId { get; set; }
        public Peca? Peca { get; set; }

        [Column("ID_Encomenda")]
        public int EncomendaId { get; set; }
        public Encomenda? Encomenda { get; set; }

        public int Quantidade { get; set; }

        public string? Nome { get; set; }
        public string? Tipo { get; set; }
        public decimal Preco { get; set; }
    }
}