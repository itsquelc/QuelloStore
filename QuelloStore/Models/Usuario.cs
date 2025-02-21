using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace QuelloStore.Models;

    public class Usuario : IdentityUser
    {
        [Required(ErrorMessage = "Por favor, informe o nome")]
        public string Nome {get; set;}

        [DataType(DataType.Date)]
        [Display(Name = "Data de Nascimento")]
        public DateTime DataNascimento {get; set;}

        public string Foto {get; set;}
        
    }
