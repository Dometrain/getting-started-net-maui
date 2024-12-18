namespace HelloMaui;

class App : Application
{
    public App()
    {
        Resources.MergedDictionaries.Add(new HelloMaui.Resources.Styles.Colors());
        Resources.MergedDictionaries.Add(new HelloMaui.Resources.Styles.Styles());
    }

    protected override Window CreateWindow(IActivationState? activationState) => new(new MainPage());

    protected override void OnStart()
    {
        base.OnStart();
        
        Trace.WriteLine("*****App Started*****");
    }

    protected override void OnResume()
    {
        base.OnResume();
        
        Trace.WriteLine("*****App Resumed*****");
    }

    protected override void OnSleep()
    {
        base.OnSleep();
        
        Trace.WriteLine("*****App Backgrounded*****");
    }
}
