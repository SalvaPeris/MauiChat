namespace MauiChat.Platforms.ViewModels;

[QueryProperty(nameof(Item), "Item")]
public partial class ChatDetailViewModel : BaseViewModel
{
	[ObservableProperty]
	SampleItem item;
}
