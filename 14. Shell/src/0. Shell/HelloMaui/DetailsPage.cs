namespace HelloMaui;

class DetailsPage : BaseContentPage, IQueryAttributable
{
	readonly Label _libraryTitleLabel;
	readonly Label _libraryDetailsLabel;
	readonly Image _libraryImage;

	public const string LibraryQueryKey = nameof(LibraryQueryKey);

	public DetailsPage()
	{
		Shell.SetBackButtonBehavior(this, new BackButtonBehavior()
		{
			TextOverride = "List"
		});
		
		Content = new VerticalStackLayout
		{
			Spacing = 12,
			
			Children =
			{
				new Image()
					.Center()
					.Size(250)
					.Assign(out _libraryImage),

				new Label()
					.TextCenter()
					.Center()
					.Font(bold: true, size: 24)
					.Assign(out _libraryTitleLabel),

				new Label()
					.TextCenter()
					.Center()
					.Font(italic: true, size: 16)
					.Assign(out _libraryDetailsLabel),
				
				new Button()
					.Text("Back")
					.Invoke(button => button.Clicked += HandleButtonClicked)
			}
		}.Center()
		 .Padding(12);
	}

	void HandleButtonClicked(object? sender, EventArgs e)
	{
		Shell.Current.GoToAsync("..", true);
	}

	void IQueryAttributable.ApplyQueryAttributes(IDictionary<string, object> query)
	{
		var library = (LibraryModel)query[LibraryQueryKey];

		Title = library.Title;

		_libraryTitleLabel.Text = library.Title;
		_libraryImage.Source = library.ImageSource;
		_libraryDetailsLabel.Text = library.Description;
	}
}