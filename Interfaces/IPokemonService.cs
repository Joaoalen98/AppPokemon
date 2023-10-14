using PokeMaui.Models;

namespace PokeMaui.Interfaces;
public interface IPokemonService
{
    Task<IEnumerable<Pokemon>> GetAllPokemons(int limit, int offset);
    Task<Pokemon> GetPokemonByName(string name);
}
