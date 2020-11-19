using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CharacterSheet.Models;
using System;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using CharacterSheet.Services;
using CharacterSheet.Repositories;

namespace CharacterSheet.Controllers
{
    [Route("v1/account")]
    public class HomeController : ControllerBase
    {
        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public ActionResult<dynamic> Authenticate([FromBody] User model)
        {

            var user = UserRepository.Get(model.Username, model.Password);

            if (user == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            var token = TokenService.GenerateToken(user);
            user.Password = "";

            return new
            {
                user = user,
                token = token
            };
        }
        [HttpGet]
        [Route("anonymous")]
        [AllowAnonymous]
        public string Anonymous() => "Usuário Anônimo";

        [HttpGet]
        [Route("authenticated")]
        [Authorize]
        public string Authenticated() => String.Format("Autenticado - Usuário {0}", User.Identity.Name);

        [HttpGet]
        [Route("jogador")]
        [Authorize(Roles = "Jogador, Mestre")]
        public string Jogador() => "Usuário do tipo Jogador";

        [HttpGet]
        [Route("mestre")]
        [Authorize(Roles = "Mestre")]
        public string Mestre() => "Usuário do tipo Mestre";

    }
}