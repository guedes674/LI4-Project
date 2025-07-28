using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComplicadaMente.Models
{
    public class ManualStep
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        [Required]
        public string Descricao { get; set; }

        [Required]
        [Column(TypeName = "VARBINARY(MAX)")]
        public byte[] Imagem { get; set; }

        [Required]
        public int QuebraCabecaId { get; set; }

        [ForeignKey("QuebraCabecaId")]
        public QuebraCabeca QuebraCabeca { get; set; }

        public int StepNumber { get; set; }
    }
}