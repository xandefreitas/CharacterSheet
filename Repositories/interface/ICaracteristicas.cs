using System.Collections.Generic;
using System.Threading.Tasks;
using CharacterSheet.Models;
using Refit;

namespace CharacterSheet.Interfaces
{
    public interface ICaracteristicas
    {
        [Get("/races/{name}")]
        Task<Caracteristicas> GetAddressAsync(string name);
    }
}