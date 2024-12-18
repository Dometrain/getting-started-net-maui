namespace HelloMaui;

class MainPage : BaseContentPage
{
    public MainPage()
    {
        BackgroundColor = Colors.DarkViolet;

        Content = new VerticalStackLayout
        {
            Spacing = 12,
            
            BackgroundColor = Colors.LightSteelBlue,

            Children =
            {
                new Image()
                    .Size(500, 250)
                    .Aspect(Aspect.AspectFit)
                    .Source("dotnet_bot.png"),

                new Label()
                    .Text("Hello MAUI", Colors.Black)
                    .Center()
                    .TextCenter(),

                new Entry()
                    .Placeholder("Notes", Colors.DarkGray)
                    .TextColor(Colors.Black)
            }
        }.Top().CenterHorizontal();
    }
}
