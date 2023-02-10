using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto.Asp.Api.PousadaAsp.Data.Context;
using Projeto.Asp.Api.PousadaAsp.Domain.ViewModels;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Asp.Api.Controllers
{
    [Route("api/[controller]")]
    public class LoginController : MainController
    {
        private PousadaAspDbContext _context;

        public List<Teste> lista = new List<Teste>();

        public LoginController(PousadaAspDbContext context)
        {
            _context = context;
            //lista.Add(new Teste(1, "um"));
            //lista.Add(new Teste(2, "dois"));
            //lista.Add(new Teste(3, "três"));
        }

        [HttpPost]
        public async Task<ActionResult<UserViewModel>> Register()
        {
 
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            var t = lista;

            return CustomResponse(t);
        }

        [HttpPost]
        public ActionResult Criar(Teste id)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            lista.Add(id);

            var count = lista.Count();

            return CustomResponse(id);
        }

    }
        public class Teste
        {
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa conter entre {2} e {1} caracter", MinimumLength = 5)]
        public string Nome { get; set; }


            
            
        }
}
