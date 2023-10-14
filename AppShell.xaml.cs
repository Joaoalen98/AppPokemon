using PokeMaui.Views;

namespace PokeMaui;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute("pokemons", typeof(IndexView));
        Routing.RegisterRoute("pokemons/details", typeof(PokemonDetailsView));
    }
}
