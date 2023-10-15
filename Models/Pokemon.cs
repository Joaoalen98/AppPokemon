namespace PokeMaui.Models;
public class Pokemon
{
    public string Name { get; set; }
    public List<PokemonType> Types { get; set; } = new List<PokemonType>();
    public List<PokemonImage> Images { get; set; } = new List<PokemonImage>();
    public List<PokemonStat> Stats { get; set; } = new List<PokemonStat>();

    public class PokemonImage
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }

    public class PokemonStat
    {
        public string Name { get; set; }
        public int Value { get; set; }
    }

    public class PokemonType
    {
        public string Name { get; set; }
    }
}
