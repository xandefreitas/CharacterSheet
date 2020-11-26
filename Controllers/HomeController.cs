using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CharacterSheet.Models;
using System;
using Microsoft.AspNetCore.Authorization;
using CharacterSheet.Services;
using CharacterSheet.Repositories;
using CharacterSheet.Interfaces;

namespace CharacterSheet.Controllers
{
    
    [Route("v1/account")]
    //[AllowAnonymous]
    public class HomeController : ControllerBase
    {
        private readonly ICharacterRepository _characterRepository;
        public HomeController(ICharacterRepository charRepo)
        {
            _characterRepository = charRepo;
        }

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

        [HttpPost]
        [Route("create")]
        [Authorize(Roles="Jogador, Mestre")]
        public IActionResult Create([FromBody] Personagem personagem)
        {
            if (personagem == null)
            {
                return BadRequest();
            }

            _characterRepository.Add(personagem);
            return CreatedAtRoute("GetPersonagem", new {id=personagem.Id}, personagem);
            
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
        [Route("lista")]
        [AllowAnonymous]
        public IEnumerable<Personagem> GetAll()
        {
            return _characterRepository.GetAll();
        }

        [HttpGet("{id}", Name = "GetPersonagem")]
        [AllowAnonymous]
        public IActionResult GetOne(long id)
        {
            var persona = _characterRepository.GetOne(id);
            if(persona==null)
            {
                return NotFound();
            }
            return new ObjectResult(persona);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Mestre")]
        public IActionResult Remove(long id)
        {
            var persona = _characterRepository.GetOne(id);

            if (persona==null)
            {
                return NotFound();
            }
            _characterRepository.Remove(persona);
            return new NoContentResult();
        }

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