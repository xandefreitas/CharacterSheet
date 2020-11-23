using System.Collections.Generic;
using System.Linq;
using CharacterSheet.Interfaces;
using CharacterSheet.Models;

namespace CharacterSheet.Repositories
{
    public class CharacterRepository : ICharacterRepository
    {
        private DatabaseContext context;
        public CharacterRepository(DatabaseContext ctx)
        {
            context = ctx;
        }
        public void Add(Personagem personagem)
        {
            context.Personagens.Add(personagem);
            context.SaveChanges();
        }
        public List<Personagem> GetAll()
        {
            return context.Personagens.ToList();
        }

        public Personagem GetOne(long id)
        {
            return context.Personagens.Where((p) => p.Id == id).SingleOrDefault();
        }

        public void Remove(Personagem personagem)
        {
            context.Personagens.Remove(personagem);
            context.SaveChanges();
        }

        public Personagem Save(Personagem personagem)
        {
            context.Personagens.Add(personagem);
            context.SaveChanges();
            return personagem;
        }

        public Personagem Update(Personagem personagem)
        {
            context.Personagens.Update(personagem);
            context.SaveChanges();
            return personagem;
        }
    }
}