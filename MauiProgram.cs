using HeyNeuer.Services;
using Microsoft.Extensions.Logging;

using ZXing.Net.Maui;
using ZXing.Net.Maui.Controls;

namespace HeyNeuer;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .RegisterServices()
            .UseBarcodeReader()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("Font Awesome 6 Brands-Regular-400.otf", "FAB");
                fonts.AddFont("Font Awesome 6 Free-Regular-400.otf", "FAR");
                fonts.AddFont("Font Awesome 6 Free-Solid-900.otf", "FAS");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}

    public static MauiAppBuilder RegisterServices(this MauiAppBuilder mauiAppBuilder)
    {
        mauiAppBuilder.Services.AddSingleton<IHeyNeuerApiService, HeyNeuerApiService>();
        
		return mauiAppBuilder;
    }
}
