using Microsoft.Maui.Controls.PlatformConfiguration;
using Microsoft.Maui.Controls.PlatformConfiguration.iOSSpecific;

namespace HelloMaui;

public abstract class BaseContentPage : ContentPage
{
	protected BaseContentPage()
	{
		On<iOS>().SetUseSafeArea(true);
	}
}