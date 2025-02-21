using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuelloStore.Models;

[Table("ProdutoFoto")]
    public class ProdutoFoto
    {
        [Key]
        public int Id { get; set; }
        [Display (Name = "Produto")]
        [Required(ErrorMessage = "Por favor, informe o produto")]
        public int ProdutoId { get; set; }
        [ForeignKey("ProdutoId")]
        public Produto Produto { get; set; }

        [StringLength(200)]
        [Display(Name = "Foto")]
        [Required(ErrorMessage = "Por favor, selecione a Foto")]
        public string ArquivoFoto { get; set; }
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
    } 