﻿using Microsoft.AspNetCore.Components.WebView.Maui;
using OPCDAApp.Data;

namespace OPCDAApp
{
	public static class MauiProgram
	{
		public static MauiApp CreateMauiApp()
		{
			var builder = MauiApp.CreateBuilder();
			builder.Services.AddAntDesign();
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

			builder.Services.AddSingleton<WeatherForecastService>();

			return builder.Build();
		}
	}
}