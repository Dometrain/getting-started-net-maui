using Microsoft.Maui.Controls.PlatformConfiguration;
using Microsoft.Maui.Controls.PlatformConfiguration.iOSSpecific;

namespace HelloMaui;

abstract class BaseContentPage : ContentPage
{
	protected BaseContentPage()
	{
		On<iOS>().SetUseSafeArea(true);
	}
}