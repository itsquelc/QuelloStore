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

       [Display(Prompt="Informe seu Email")]
       [Required(ErrorMessage = "Por favor, informe seu Email")]
       [EmailAddress(ErrorMessage = "Por favor, informe um Email válido!")]
       [StringLength(100, ErrorMessage = "O Email deve possuir no máximo 100 caracteres")]
       public string Email { get; set; }

       [DataType(DataType.Password)]
       [Display(Name = "Senha de acesso", Prompt = "Informe sua senha de acesso")]
       [Required(ErrorMessage = "Por favor, informe sua senha de acesso")]
       [StringLength(20, MinimumLength = 6, ErrorMessage = "a senha de acesso deve possuir no mínimo 6 e no máximo 20 caracteres")]
       public string Senha { get; set; }

       [DataType(DataType.Password)]
       [Display(Name = "Confirmar a senha de acesso", Prompt = "Confirme sua senha de acesso")]
       [Compare("Senha", ErrorMessage = "As senhas não se conferem.")]
       public string ConfirmacaoSenha { get; set; }

       public IFormFile Foto { get; set; }
    }
