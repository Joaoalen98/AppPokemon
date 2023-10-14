using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PokeMaui.Interfaces;
using PokeMaui.Models;

namespace PokeMaui.ViewModels;
public partial class IndexViewModel : ObservableObject
{
    [ObservableProperty]
    private bool _isLoading = false;

    [ObservableProperty]
    private List<Pokemon> _pokemons = new List<Pokemon>();

    [ObservableProperty]
    private int _offset = 0;

    [ObservableProperty]
    private int _limit = 20;

    private readonly IPokemonService _pokemonService;

    public IndexViewModel()
    {
        _pokemonService = Application.Current.Handler.MauiContext.Services.GetService<IPokemonService>();
        GetAllPokemons();
    }

    [RelayCommand]
    public async Task GetAllPokemons()
    {
        IsLoading = true;
        Pokemons = (await _pokemonService.GetAllPokemons(Limit, Offset)).ToList();
        IsLoading = false;
    }

    [RelayCommand]
    public async Task ChangePage(string direction)
    {
        Pokemons = new List<Pokemon>();

        if (direction == "previous")
        {
            Offset -= Limit;
        }
        else if (direction == "next")
        {
            Offset += Limit;
        }

        await GetAllPokemons();
    }

    [RelayCommand]
    public async Task GoToDetailsPage(Pokemon pokemon)
    {
        await Shell.Current.GoToAsync("/pokemons/details", new Dictionary<string, object>
        {
            { "pokemon", pokemon },
        });
    }
}
