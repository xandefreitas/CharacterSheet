using System;
using System.Collections.Generic;
using System.Linq;
using CharacterSheet.Models;

namespace CharacterSheet.Repositories
{
    public static class UserRepository
    {
        public static User Get(string username, string password)
        {
            var users = new List<User>();
            users.Add(new User {Id = 1, Username = "player1", Password = "player1", Role = "Jogador"});
            users.Add(new User {Id = 2, Username = "player2", Password = "player2", Role = "Mestre"});
            return users.Where(x => x.Username.ToLower() == username.ToLower() && x.Password == x.Password).FirstOrDefault();
        }

        internal static string Get(object username)
        {
            throw new NotImplementedException();
        }
    }
}
