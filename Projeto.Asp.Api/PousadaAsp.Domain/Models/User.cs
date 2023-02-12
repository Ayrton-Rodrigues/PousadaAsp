
using System;

namespace Projeto.Asp.Api.PousadaAsp.Domain.Entity
{
    public class User : BaseEntity
    {

        public string Nome { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public string Password { get; set; }
        public int RolesId { get; set; }

        public DateTime data_nascimento { get; set; }

        public bool Ativo { get; set; }


    }   

    
    }

   
