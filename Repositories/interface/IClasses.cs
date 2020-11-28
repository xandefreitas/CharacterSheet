using System.Threading.Tasks;
using CharacterSheet.Models;
using Refit;

namespace CharacterSheet.Interfaces
{
    public interface IClasses
    {
        [Get("/classes/{name}")]
        Task<Classes> GetAddressAsync(string name);

    }
}