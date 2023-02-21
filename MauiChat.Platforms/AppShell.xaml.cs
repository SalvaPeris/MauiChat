namespace MauiChat.Platforms;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(ChatDetailPage), typeof(ChatDetailPage));
	}
}
