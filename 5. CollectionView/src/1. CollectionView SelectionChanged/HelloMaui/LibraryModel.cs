namespace HelloMaui;

class LibraryModel
{
	public required string Title { get; init; }
	public required string Description { get; init; }
	public required ImageSource ImageSource { get; init; } = "appicon";
}