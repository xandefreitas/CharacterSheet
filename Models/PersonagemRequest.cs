using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CharacterSheet.Models
{
    public class PersonagemRequest
    {
        public string Nome { get; set; }

        public string Criador { get; set; }

    }

}
