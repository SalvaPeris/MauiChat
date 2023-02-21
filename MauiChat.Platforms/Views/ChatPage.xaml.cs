namespace MauiChat.Platforms.Views;

public partial class ChatPage : ContentPage
{
	ChatViewModel ViewModel;

	public ChatPage(ChatViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = ViewModel = viewModel;
	}

	protected override async void OnNavigatedTo(NavigatedToEventArgs args)
	{
		base.OnNavigatedTo(args);

		await ViewModel.LoadDataAsync();
	}
}
