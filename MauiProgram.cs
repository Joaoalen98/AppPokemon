using Microsoft.Extensions.Logging;
using PokeMaui.Interfaces;
using PokeMaui.Services;
using PokeMaui.ViewModels;
using PokeMaui.Views;

namespace PokeMaui;
public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .RegisterServices()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }

    public static MauiAppBuilder RegisterServices(this MauiAppBuilder builder)
    {
        // views
        builder.Services.AddSingleton<IndexView>();

        // viewmodels
        builder.Services.AddSingleton<IndexViewModel>();

        // services
        builder.Services.AddSingleton<IPokemonService, PokemonService>();

        return builder;
    }
}
