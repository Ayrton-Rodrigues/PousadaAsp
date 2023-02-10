using System;

namespace Projeto.Asp.Api.PousadaAsp.Domain.ViewModels
{
    public class UserViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public string Password { get; set; }
        public int Role { get; set; }

        public DateTime BirthDate { get; set; }
        
        public bool Active { get; set; }
    }
}
