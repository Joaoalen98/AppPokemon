namespace PokeMaui.Models;
public class Pokemon
{
    public string Name { get; set; }
    public List<PokemonType> Types { get; set; } = new List<PokemonType>();
    public List<PokemonImage> Images { get; set; } = new List<PokemonImage>();
}
