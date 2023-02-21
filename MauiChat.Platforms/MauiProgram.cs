namespace MauiChat.Platforms;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiCommunityToolkit()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("FontAwesome6FreeBrands.otf", "FontAwesomeBrands");
				fonts.AddFont("FontAwesome6FreeRegular.otf", "FontAwesomeRegular");
				fonts.AddFont("FontAwesome6FreeSolid.otf", "FontAwesomeSolid");
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		builder.Services.AddTransient<SampleDataService>();
		builder.Services.AddTransient<ChatDetailViewModel>();
		builder.Services.AddTransient<ChatDetailPage>();

		builder.Services.AddSingleton<ChatViewModel>();

		builder.Services.AddSingleton<ChatPage>();

		builder.Services.AddSingleton<HomeViewModel>();

		builder.Services.AddSingleton<HomePage>();

		builder.Services.AddSingleton<ProfileViewModel>();

		builder.Services.AddSingleton<ProfilePage>();

		builder.Services.AddSingleton<LocalizationViewModel>();

		builder.Services.AddSingleton<LocalizationPage>();

		builder.Services.AddSingleton<SampleViewModel>();

		builder.Services.AddSingleton<SamplePage>();

		builder.Services.AddSingleton(AudioManager.Current);

		return builder.Build();
	}
}
