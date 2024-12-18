namespace HelloMaui;

class RefreshViewHeightConverter : IValueConverter
{
	public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
	{
		ArgumentNullException.ThrowIfNull(value);
		ArgumentNullException.ThrowIfNull(parameter);
		
		var searchBarHeight = (double)value;
		var listPage = (ListPage)parameter;

		return listPage.Height - searchBarHeight;
	}

	public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
	{
		throw new NotImplementedException();
	}
}