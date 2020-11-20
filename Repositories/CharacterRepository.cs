using System.Collections.Generic;
using System.Linq;
using CharacterSheet.Models;

namespace CharacterSheet.Repositories
{
    public static class CharacterRepository
    {
        public static Personagem Get(string nome, string criador, string raça, string classe, string historia)
        {
            var personagens = new List<Personagem>();
            personagens.Add(new Personagem {Id = 1, Nome = "Legolas", Criador = "Username", 
            Raça = "Jogador", Classe = "Elf", Historia = "Descrição do Elfo"});
            personagens.Add(new Personagem {Id = 2, Nome = "Getafix", Criador = "Username", 
            Raça = "Mestre", Classe = "Druid", Historia = "Descrição do Druida"});
            return personagens.Where(x => x.Nome == nome && x.Criador == criador).FirstOrDefault();
        }
    }
}