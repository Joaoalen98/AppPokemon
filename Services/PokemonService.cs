using PokeMaui.Interfaces;
using PokeMaui.Models;
using System.Net.Http.Json;

namespace PokeMaui.Services;
public class PokemonService : IPokemonService
{
    private HttpClient _http;

    public PokemonService()
    {
        _http = new HttpClient()
        {
            BaseAddress = new Uri("https://pokeapi.co/api/v2/"),
        };
    }

    public async Task<IEnumerable<Pokemon>> GetAllPokemons(int limit, int offset)
    {
        string url = $"pokemon?limit={limit}&offset={offset}";
        var req = await _http.GetFromJsonAsync<PokemonList>(url);

        List<Pokemon> pokemons = new List<Pokemon>();

        foreach (var item in req.results)
        {
            var pokemon = await GetPokemonByName(item.name);
            pokemons.Add(pokemon);
        }

        return pokemons;
    }

    public async Task<Pokemon> GetPokemonByName(string name)
    {
        var req = await _http.GetFromJsonAsync<PokemonRoot>($"pokemon/{name}");

        var pokemon = new Pokemon
        {
            Name = req.name,
            Images = new List<PokemonImage>
            {
                new PokemonImage
                {
                    Name = "Front Default",
                    Url = req.sprites.front_default,
                },
                new PokemonImage
                {
                    Name = "Back Default",
                    Url = req.sprites.back_default,
                },
            },
            Types = req.types.Select(t => new PokemonType
            {
                Name = t.type.name
            }).ToList(),
        };

        return pokemon;
    }
}
