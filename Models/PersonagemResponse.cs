using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace CharacterSheet.Models
{
    public class PersonagemResponse
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Criador { get; set; }
        public string Raça { get; set; }
        public string Classe {get; set;}
        public HashSet<string> Historia { get; set; }

        private HashSet<string> BuildTags(string Historia)
        {
            if (!string.IsNullOrWhiteSpace(Historia))
            {
                return Historia.Split(",").Select((l) => l.Trim()).ToHashSet();
            }

            return new HashSet<string>();
        }

        public PersonagemResponse() : base()
        {

        }

        public PersonagemResponse(Personagem personagem) : this()
        {
            if (personagem != null)
            {
                this.Id = personagem.Id;
                this.Nome = personagem.Nome;
                this.Criador = personagem.Criador;
                this.Raça = personagem.Raça;
                this.Classe = personagem.Classe;
                this.Historia = BuildTags(personagem.Historia);
            }
        }

    }

}
