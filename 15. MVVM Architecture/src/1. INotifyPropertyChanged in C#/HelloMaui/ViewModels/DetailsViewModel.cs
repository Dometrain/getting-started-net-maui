using System.Windows.Input;

namespace HelloMaui;

class DetailsViewModel : BaseViewModel, IQueryAttributable
{
	public const string LibraryQueryKey = nameof(LibraryQueryKey);
	
	string? _libraryTitle;
	string? _libraryDescription;
	ImageSource? _libraryImageSource;

	public DetailsViewModel()
	{
		BackButtonCommand = new AsyncRelayCommand(BackButtonAction);
	}
	
	public ICommand BackButtonCommand { get; }

	public string? LibraryTitle
	{
		get => _libraryTitle;
		set => SetProperty(ref _libraryTitle, value);
	}

	public string? LibraryDescription
	{
		get => _libraryDescription;
		set => SetProperty(ref _libraryDescription, value);
	}

	public ImageSource? LibraryImageSource
	{
		get => _libraryImageSource;
		set => SetProperty(ref _libraryImageSource, value);
	}
	
	Task BackButtonAction() => Shell.Current.GoToAsync("..", true);

	void IQueryAttributable.ApplyQueryAttributes(IDictionary<string, object> query)
	{
		var library = (LibraryModel)query[LibraryQueryKey];

		LibraryTitle = library.Title;
		LibraryImageSource = library.ImageSource;
		LibraryDescription = library.Description;
	}
}