using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Behaviors;
using Microsoft.Maui.Controls.PlatformConfiguration.iOSSpecific;
using SearchBar = Microsoft.Maui.Controls.SearchBar;

namespace HelloMaui;

class MainPage : BaseContentPage
{
	readonly SearchBar _searchBar;

	public MainPage()
	{
		On<Microsoft.Maui.Controls.PlatformConfiguration.iOS>().SetUseSafeArea(true);

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
					.Assign(out _searchBar)
					.Behaviors(new UserStoppedTypingBehavior
					{
						StoppedTypingTimeThreshold = 1000,
						ShouldDismissKeyboardAutomatically = true,
						Command = new RelayCommand(() => UserStoppedTyping())
					}),
				new RefreshView
					{
						Content = new CollectionView
							{
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
							.ItemsSource(MauiLibraries)
							.Invoke(static collectionView => collectionView.SelectionChanged += HandleSelectionChanged)
					}.Invoke(refreshView => refreshView.Refreshing += HandleRefreshing)
					.Margin(12, 0)
					.Bind(RefreshView.HeightRequestProperty,
						static searchBar => searchBar.Height,
						convert: height => Height - height,
						source: _searchBar)
			}
		};
	}

	ObservableCollection<LibraryModel> MauiLibraries { get; } = new(CreateLibraries());

	static List<LibraryModel> CreateLibraries() => new()
	{
		new()
		{
			Title = "Microsoft.Maui",
			Description =
				".NET Multi-platform App UI is a framework for building native device applications spanning mobile, tablet, and desktop",
			ImageSource = "https://api.nuget.org/v3-flatcontainer/microsoft.maui.controls/8.0.3/icon"
		},
		new()
		{
			Title = "CommunityToolkit.Maui",
			Description =
				"The .NET MAUI Community Toolkit is a community-created library that contains .NET MAUI Extensions, Advanced UI/UX Controls, and Behaviors to help make your life as a .NET MAUI developer easier",
			ImageSource = "https://api.nuget.org/v3-flatcontainer/communitytoolkit.maui/5.2.0/icon"
		},
		new()
		{
			Title = "CommunityToolkit.Maui.Markup",
			Description =
				"The .NET MAUI Markup Community Toolkit is a community-created library that contains Fluent C# Extension Methods to easily create your User Interface in C#",
			ImageSource = "https://api.nuget.org/v3-flatcontainer/communitytoolkit.maui.markup/3.2.0/icon"
		},
		new()
		{
			Title = "CommunityToolkit.MVVM",
			Description =
				"This package includes a .NET MVVM library with helpers such as ObservableObject, ObservableRecipient, ObservableValidator, RelayCommand, AsyncRelayCommand, WeakReferenceMessenger, StrongReferenceMessenger and IoC",
			ImageSource = "https://api.nuget.org/v3-flatcontainer/communitytoolkit.mvvm/8.2.0/icon"
		},
		new()
		{
			Title = "Sentry.Maui",
			Description =
				"Bad software is everywhere, and we're tired of it. Sentry is on a mission to help developers write better software faster, so we can get back to enjoying technology",
			ImageSource = "https://api.nuget.org/v3-flatcontainer/sentry.maui/3.33.1/icon"
		},
		new()
		{
			Title = "Esri.ArcGISRuntime.Maui",
			Description =
				"Contains APIs and UI controls for building native mobile and desktop apps with the .NET Multi-platform App UI (.NET MAUI) cross-platform framework",
			ImageSource = "https://api.nuget.org/v3-flatcontainer/esri.arcgisruntime.maui/100.14.1-preview3/icon"
		},
		new()
		{
			Title = "Syncfusion.Maui.Core",
			Description =
				"This package contains .NET MAUI Avatar View, .NET MAUI Badge View, .NET MAUI Busy Indicator, .NET MAUI Effects View, and .NET MAUI Text Input Layout components for .NET MAUI application",
			ImageSource = "https://api.nuget.org/v3-flatcontainer/syncfusion.maui.core/21.2.10/icon"
		},
		new()
		{
			Title = "DotNet.Meteor",
			Description = "A VSCode extension that can run and debug .NET apps (based on Clancey VSCode.Comet)",
			ImageSource =
				"https://nromanov.gallerycdn.vsassets.io/extensions/nromanov/dotnet-meteor/3.0.3/1686392945636/Microsoft.VisualStudio.Services.Icons.Default"
		}
	};

	static async void HandleSelectionChanged(object? sender, SelectionChangedEventArgs e)
	{
		ArgumentNullException.ThrowIfNull(sender);

		var collectionView = (CollectionView)sender;

		if (e.CurrentSelection.FirstOrDefault() is LibraryModel library)
		{
			await Toast.Make($"{library.Title} tapped").Show();
		}

		collectionView.SelectedItem = null;
	}

	async void HandleRefreshing(object? sender, EventArgs e)
	{
		ArgumentNullException.ThrowIfNull(sender);

		_searchBar.IsEnabled = false;

		var refreshView = (RefreshView)sender;

		await Task.Delay(TimeSpan.FromSeconds(2));

		MauiLibraries.Add(new()
		{
			Title = "Sharpnado.Tabs",
			Description =
				"Pure MAUI and Xamarin.Forms Tabs, including fixed tabs, scrollable tabs, bottom tabs, badge, segmented control, custom tabs, button tabs, bendable tabs",
			ImageSource = "https://api.nuget.org/v3-flatcontainer/sharpnado.tabs/2.2.0/icon"
		});

		refreshView.IsRefreshing = false;
		
		_searchBar.IsEnabled = true;
	}

	void UserStoppedTyping()
	{
		var searchText = _searchBar.Text;

		MauiLibraries.Clear();

		if (string.IsNullOrWhiteSpace(searchText))
		{
			foreach (var library in CreateLibraries())
			{
				MauiLibraries.Add(library);
			}
		}
		else
		{
			foreach (var library in CreateLibraries().Where(x => x.Title.Contains(searchText)))
			{
				MauiLibraries.Add(library);
			}
		}
	}
}