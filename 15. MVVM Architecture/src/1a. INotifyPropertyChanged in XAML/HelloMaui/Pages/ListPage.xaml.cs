using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Views;

namespace HelloMaui;

public partial class ListPage : BaseContentPage<ListViewModel>
{
	public ListPage(ListViewModel listViewModel) : base(listViewModel)
	{
		InitializeComponent();
	}
	
	protected override async void OnAppearing()
	{
		base.OnAppearing();

		await Task.Delay(TimeSpan.FromSeconds(1));

		this.ShowPopup(new WelcomePopup());
	}

	async void HandleSelectionChanged(object? sender, SelectionChangedEventArgs e)
	{
		ArgumentNullException.ThrowIfNull(sender);

		var collectionView = (CollectionView)sender;

		if (e.CurrentSelection.FirstOrDefault() is LibraryModel libraryModel)
		{
			Dictionary<string, object> parameters = new()
			{
				{ DetailsViewModel.LibraryQueryKey, libraryModel }
			};
			
			await Shell.Current.GoToAsync(AppShell.GetRoute<DetailsPage>(), parameters);
		}

		collectionView.SelectedItem = null;
	}

	class WelcomePopup : Popup
	{
		public WelcomePopup()
		{
			Opened += HandlePopupOpened;
			
			Content = new Label()
				.Text("Welcome")
				.TextCenter()
				.Font(bold: true, size: 32)
				.Center()
				.Padding(12, 24);

			Content.Scale = 0;
		}

		async void HandlePopupOpened(object? sender, PopupOpenedEventArgs e)
		{
			ArgumentNullException.ThrowIfNull(Content);
			
			await Content.ScaleTo(1, 300, Easing.SpringOut);
		}
	}

	async void HandleSearchBarTappedTwice(object? sender, TappedEventArgs e)
	{
		await Toast.Make("Double Tap Detected").Show();
	}
}