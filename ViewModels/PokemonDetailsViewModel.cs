using CommunityToolkit.Mvvm.ComponentModel;
using PokeMaui.Models;

namespace PokeMaui.ViewModels;
public partial class PokemonDetailsViewModel : ObservableObject, IQueryAttributable
{
    [ObservableProperty]
    private Pokemon _pokemon;

    public PokemonDetailsViewModel()
    {

    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        Pokemon = query["pokemon"] as Pokemon;
    }
}
