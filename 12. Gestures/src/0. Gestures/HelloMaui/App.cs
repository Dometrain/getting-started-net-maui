namespace HelloMaui;

class App : Application
{
    public App()
    {
        Resources.MergedDictionaries.Add(new HelloMaui.Resources.Styles.Colors());
        Resources.MergedDictionaries.Add(new HelloMaui.Resources.Styles.Styles());
    }

    protected override Window CreateWindow(IActivationState? activationState) => new(new MainPage());
}
