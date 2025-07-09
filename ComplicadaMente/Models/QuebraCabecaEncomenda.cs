/* namespace ComplicadaMente.Models
{
    public class QuebraCabecaEncomenda
    {
        // variaveis de instancia
        private int EncomendaId;
        private int QuebraCabecaId;
        private int quantidade;

        // construtor parametrizado
        public QuebraCabecaEncomenda(int EncomendaId, int QuebraCabecaId, int quantidade)
        {
            this.EncomendaId = EncomendaId;
            this.QuebraCabecaId = QuebraCabecaId;
            this.quantidade = quantidade;
        }

        // getters e setters
        public int getIdEncomenda()
        {
            return this.EncomendaId;
        }

        public void setIdEncomenda(int EncomendaId)
        {
            this.EncomendaId = EncomendaId;
        }

        public int getIdQuebraCabeca()
        {
            return this.QuebraCabecaId;
        }

        public void setIdQuebraCabeca(int QuebraCabecaId)
        {
            this.QuebraCabecaId = QuebraCabecaId;
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
    [Table("Quebra_Cabeca_Encomenda")]
    public class QuebraCabecaEncomenda
    {
        [Column("ID_Encomenda")]
        public int EncomendaId { get; set; }
        public Encomenda? Encomenda { get; set; }

        [Column("ID_Quebra_Cabeca")]
        public int QuebraCabecaId { get; set; }
        public QuebraCabeca? QuebraCabeca { get; set; }

        public int Quantidade { get; set; }
    }
}