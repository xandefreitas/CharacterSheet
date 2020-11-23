using System.Collections.Generic;
using CharacterSheet.Models;

namespace CharacterSheet.Interfaces
{
   public interface ICharacterRepository
    {
        void Add(Personagem personagem);
        List<Personagem> GetAll();
        Personagem GetOne(long id);
        Personagem Save(Personagem personagem);
        void Remove(Personagem personagem);
        Personagem Update(Personagem personagem);
    } 
}


    

