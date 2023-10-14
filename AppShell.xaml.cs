using PokeMaui.Views;

namespace PokeMaui;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute("/", typeof(IndexView));
    }
}
