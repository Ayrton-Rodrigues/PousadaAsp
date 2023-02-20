
using System;

namespace Projeto.Asp.Api.PousadaAsp.Domain.Entity
{
    public class User : BaseEntity
    {

        public string Nome { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public DateTime RegisterDate { get; set; }
        public int Roles { get; set; }

        public bool Ativo { get; set; }

 
    } 

    
}

   
