namespace MauiChat.Platforms.Views;

public partial class ChatDetailPage : ContentPage
{
	public ChatDetailPage(ChatDetailViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}
