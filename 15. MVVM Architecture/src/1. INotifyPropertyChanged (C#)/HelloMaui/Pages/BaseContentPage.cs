using Microsoft.Maui.Controls.PlatformConfiguration.iOSSpecific;

namespace HelloMaui;

abstract class BaseContentPage<TViewModel> : ContentPage where TViewModel : BaseViewModel
{
	protected BaseContentPage(TViewModel viewModel)
	{
		On<Microsoft.Maui.Controls.PlatformConfiguration.iOS>().SetUseSafeArea(true);
		
		base.BindingContext = viewModel;
	}

	protected new TViewModel BindingContext => (TViewModel)base.BindingContext;
}