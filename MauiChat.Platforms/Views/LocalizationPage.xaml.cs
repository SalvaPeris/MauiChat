namespace MauiChat.Platforms.Views;

public partial class LocalizationPage : ContentPage
{
	public LocalizationPage()
	{
		InitializeComponent();

		SetFromCodeBehind.Text = MauiChat.Platforms.Resources.Strings.AppResources.MyChats;
	}

}
