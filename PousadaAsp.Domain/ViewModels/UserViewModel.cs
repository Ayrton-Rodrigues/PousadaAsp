using System;
using System.ComponentModel.DataAnnotations;

namespace PousadaAsp.Domain.ViewModels
{
    public class UserViewModel
    {
        [Key]
        public Guid Id { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa conter entre {2} e {1} caracter", MinimumLength = 2)]
        public string Nome { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [EmailAddress(ErrorMessage = "O campo {0} está em formato inválido")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(11, ErrorMessage = "O campo {0} precisa conter entre {2} e {1} caracter", MinimumLength = 11)]
        public string Cpf { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(10, ErrorMessage = "O campo {0} precisa conter entre {2} e {1} caracter", MinimumLength = 6)]
        public string Password { get; set; }
        
        [Compare("Password", ErrorMessage = "As senhas não conferem")]
        public string ConfirmPassword { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Roles { get; set; }

        public DateTime DataRegistro { get; set; }
        
        public bool Ativo { get; set; }

        public string Telefone { get; set; }
    }
}
