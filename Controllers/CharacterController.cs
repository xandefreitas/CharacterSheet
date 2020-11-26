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
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterRepository _characterRepository;
        public CharacterController(ICharacterRepository charRepo)
        {
            _characterRepository = charRepo;
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
            personagem.Criador = User.Identity.Name;
            //personagem.Vida = qtd vida da classe

            _characterRepository.Add(personagem);
            return CreatedAtRoute("GetPersonagem", new {id=personagem.Id}, personagem);
            
        }
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
    }
}