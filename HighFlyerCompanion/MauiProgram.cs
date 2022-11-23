/* Modification non fusionnée à partir du projet 'HighFlyerCompanion (net6.0-ios)'
Avant :
using Microsoft.AspNetCore.Components.WebView.Maui;
using HighFlyerCompanion.Data.Service;
Après :
using HighFlyerCompanion.Data.Service;
using Microsoft.AspNetCore.Components.WebView.Maui;
*/

/* Modification non fusionnée à partir du projet 'HighFlyerCompanion (net6.0-windows10.0.19041.0)'
Avant :
using Microsoft.AspNetCore.Components.WebView.Maui;
using HighFlyerCompanion.Data.Service;
Après :
using HighFlyerCompanion.Data.Service;
using Microsoft.AspNetCore.Components.WebView.Maui;
*/

/* Modification non fusionnée à partir du projet 'HighFlyerCompanion (net6.0-maccatalyst)'
Avant :
using Microsoft.AspNetCore.Components.WebView.Maui;
using HighFlyerCompanion.Data.Service;
Après :
using HighFlyerCompanion.Data.Service;
using Microsoft.AspNetCore.Components.WebView.Maui;
*/

using HighFlyerCompanion.Data.Service;

namespace HighFlyerCompanion;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            });

        builder.Services.AddMauiBlazorWebView();
#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
#endif

        builder.Services.AddSingleton<MissionService>();
        builder.Services.AddSingleton<DroneHealthService>();
        builder.Services.AddSingleton<DroneOnMissionService>();

        return builder.Build();
    }
}