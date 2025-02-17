using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Org.BouncyCastle.Asn1;

namespace QuelloStore.Models;

[Table("produto")]
    public class Produto
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Por favor, informe a Categoria")]
        public int CategoriaId { get; set; }
        [ForeignKey(nameof(CategoriaId))]

        public Categoria Categoria { get; set; }
       [Required(ErrorMessage = "Por favor, informe o Nome")]
       [StringLength(60, ErrorMessage = "o nome deve possuir no máximo 60 caracteres")]
        
        public string Nome { get; set; }
        [Display(Name = "Descrição", Prompt = "Descrição")]
        [StringLength(1000,ErrorMessage = "A descrição deve possuir no máximo 1000 caracteres")]
        
        public string Descricao { get; set; }
        [Display(Name = "Quantidade em Estoque")]
        [Range(0, int.MaxValue)]
        [Required(ErrorMessage = "Por favor, informe a Quantidade em estoque")]
        
        public string QtdeEstoque { get; set; }
        [Display(Name = "Valor de custo")]
        [Range(0, double.MaxValue)]
        [Column(TypeName = "numeric(10,2)")]
        public string ValorCusto { get; set; }
         [Display(Name = "Valor Venda")]
        [Range(0, double.MaxValue)]
        [Column(TypeName = "numeric(10,2)")]
        public string ValorVenda { get; set; }
    }
