using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CharacterSheet.Models;
using System;
using Microsoft.AspNetCore.Authorization;
using CharacterSheet.Services;
using CharacterSheet.Repositories;
using CharacterSheet.Interfaces;
using Refit;
using System.Threading.Tasks;

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
        [Microsoft.AspNetCore.Authorization.Authorize(Roles="Jogador, Mestre")]
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
            var charSpecs = RestService.For<ICaracteristicas>("https://www.dnd5eapi.co/api/");
            var classSpecs = RestService.For<IClasses>("https://www.dnd5eapi.co/api/");
            
            if (string.IsNullOrWhiteSpace(persona.Raça) || string.IsNullOrWhiteSpace(persona.Classe))
            {
                Console.WriteLine("Raça ou Classe não encontrada");
            }
            
            var InfoRaça = charSpecs.GetAddressAsync(persona.Raça).Result;
            var InfoClasse = classSpecs.GetAddressAsync(persona.Classe).Result;
            

            return new ObjectResult(new{persona = persona, raca = InfoRaça, classe = InfoClasse});
        }      

        [HttpDelete("{id}")]
        [Microsoft.AspNetCore.Authorization.Authorize(Roles = "Mestre")]
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