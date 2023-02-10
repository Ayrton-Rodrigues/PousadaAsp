
using System;

namespace Projeto.Asp.Api.PousadaAsp.Domain.Entity
{
    public class User : BaseEntity
    {

        public string Name { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public string Password { get; set; }
        public int Role { get; set; }

        public DateTime BirtDate { get; set; }

        public bool Active { get; set; }


    }   

    
    }

   
