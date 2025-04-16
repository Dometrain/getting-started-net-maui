﻿using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Behaviors;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Views;
using SearchBar = Microsoft.Maui.Controls.SearchBar;

namespace HelloMaui;

class ListPage : BaseContentPage<ListViewModel>
{
	public ListPage(ListViewModel listViewModel) : base(listViewModel)
	{
		this.AppThemeColorBinding(BackgroundColorProperty, Colors.LightBlue, Color.FromArgb("#3b4a4f"));

		Content = new VerticalStackLayout
		{
			Spacing = 0,
			Children =
			{
				new SearchBar()
					.Placeholder("search titles")
					.AppThemeColorBinding(SearchBar.TextColorProperty, Colors.Black, Colors.LightGray)
					.AppThemeColorBinding(SearchBar.BackgroundColorProperty, Colors.LightBlue, Color.FromArgb("#3b4a4f"))
					.Assign(out SearchBar searchBar)
					.Bind(SearchBar.TextProperty,
							getter: static (ListViewModel vm) => vm.SearchBarText,
							setter: static (ListViewModel vm, string text) => vm.SearchBarText = text)
					.Behaviors(new UserStoppedTypingBehavior
					{
						BindingContext = listViewModel,
						StoppedTypingTimeThreshold = 1000,
						ShouldDismissKeyboardAutomatically = true,
					}.Bind(UserStoppedTypingBehavior.CommandProperty,
							getter: static (ListViewModel vm) => vm.UserStoppedTypingCommand))
					.TapGesture(async () =>
					{
						await Toast.Make("Double Tap Detected").Show();
					}, 2),
				new RefreshView
					{
						Content = new CollectionView
							{
								CanReorderItems = true,
								
								Header = new Label()
									.Text(".NET MAUI Libraries")
									.AppThemeColorBinding(Label.TextColorProperty, Colors.Black, Colors.LightGray)
									.Paddings(bottom: 8)
									.Font(size: 32)
									.Center()
									.TextCenter(),
								Footer = new Label()
									.Text(".NET MAUI: From Zero to Hero")
									.AppThemeColorBinding(Label.TextColorProperty, Color.FromArgb("#474f52"), Colors.DarkGrey)
									.TextCenter()
									.Center()
									.Font(size: 10)
									.Paddings(left: 8),
								SelectionMode = SelectionMode.Single
							}.ItemTemplate(new MauiLibrariesDataTemplate())
							.Invoke(static collectionView => collectionView.SelectionChanged += HandleSelectionChanged)
							.Bind(CollectionView.ItemsSourceProperty,
									getter: static (ListViewModel vm) => vm.MauiLibraries)
					}.Bind(RefreshView.IsRefreshingProperty, 
							getter: static (ListViewModel vm) => vm.IsRefreshing,
							setter: static (ListViewModel vm, bool isRefreshing) => vm.IsRefreshing = isRefreshing)
					.Bind(RefreshView.CommandProperty, 
							getter: static (ListViewModel vm) => vm.RefreshCommand,
							mode: BindingMode.OneTime)
					.Margin(12, 0)
			}
		};
	}

	protected override async void OnAppearing()
	{
		base.OnAppearing();

		await Task.Delay(TimeSpan.FromSeconds(1));

		this.ShowPopup(new WelcomePopup());
	}

	static async void HandleSelectionChanged(object? sender, SelectionChangedEventArgs e)
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
}