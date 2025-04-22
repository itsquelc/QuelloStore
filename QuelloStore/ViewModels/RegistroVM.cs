using System.ComponentModel.DataAnnotations;

namespace QuelloStore.ViewModels;
    public class RegistroVM
    {
       [Display(Name = "Nome Completo", Prompt = "Informe seu nome completo")]
       [Required(ErrorMessage = "Por favor, informe seu nome")]
       [StringLength(60, ErrorMessage = "O nome deve possuir no máximo 60 caracteres")]
       public string Nome { get; set; }      

       [DataType(DataType.Date)]
       [Display(Name = "Data de nascimento", Prompt = "Informe sua data de nascimento")]
       [Required(ErrorMessage = "Por favor, informe sua data de nascimento")]
       public DateTime? DataNascimento { get; set; } = null;
    }
