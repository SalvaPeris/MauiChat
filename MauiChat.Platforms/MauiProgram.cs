namespace MauiChat.Platforms;

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
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		builder.Services.AddSingleton<ChatPage>();

		builder.Services.AddSingleton<LocalizationPage>();

		builder.Services.AddSingleton<ProfilePage>();

		builder.Services.AddSingleton(AudioManager.Current);

		return builder.Build();
	}
}
