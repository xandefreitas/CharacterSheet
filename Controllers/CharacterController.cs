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
            return new ObjectResult(persona);
        }

        [HttpGet("raça/{name}")]
        [AllowAnonymous]
        public async Task<Caracteristicas> Get([FromRoute] string name,[FromBody] Caracteristicas raça)
        {
            

            var charSpecs = RestService.For<ICaracteristicas>("https://www.dnd5eapi.co/api/");

            var raçaInformada = raça.Name;
            if (raçaInformada == null)
            {
                Console.WriteLine("Raça não encontrada");
            }
            Console.WriteLine("Consultando informações da raça:" + raçaInformada);

            var InfoRaça = await charSpecs.GetAddressAsync(raçaInformada);

            //Console.Write($"\nRaça: {InfoRaça.Name}\nEnvelhecimento: {InfoRaça.Age}\nAlinhamento: {InfoRaça.Alignment}\nTamanho: {InfoRaça.Size_description}");
            
            return InfoRaça;
            
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