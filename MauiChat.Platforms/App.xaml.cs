namespace MauiChat.Platforms;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
		CultureInfo.CurrentCulture = CultureInfo.CurrentUICulture = new CultureInfo("es");

		MainPage = new AppShell();
	}
}
