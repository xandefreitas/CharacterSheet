using System.Collections.Generic;
using System.Linq;
using CharacterSheet.Interfaces;
using CharacterSheet.Models;

namespace CharacterSheet.Repositories
{
    public class UserRepository
    {
        private DatabaseContext context;
        public UserRepository(DatabaseContext ctx)
        {
            context = ctx;
        }
        
        public static User Get(string username, string password)
        {
            var users = new List<User>();
            users.Add(new User 
            {
                Id = 1, 
                Username = "player1", 
                Password = "player1", 
                Role = "Jogador"
            });
            users.Add(new User 
            {
                Id = 2, 
                Username = "player2", 
                Password = "player2", 
                Role = "Mestre"
            });
            return users.Where(x => x.Username.ToLower() == username.ToLower() && x.Password == x.Password).FirstOrDefault();
        }
    }
}
