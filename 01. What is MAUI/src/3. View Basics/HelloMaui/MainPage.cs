namespace HelloMaui;

class MainPage : BaseContentPage
{
    public MainPage()
    {
        Content = new VerticalStackLayout
        {
            Margin = new Thickness(0, 6, 0, 0),
            Padding = new Thickness(12),
            Spacing = 12,
            BackgroundColor  = Colors.LightSteelBlue,

            Children =
            {
                new Image()
                    .BackgroundColor(Colors.Red)
                    .Size(500, 250)
                    .Aspect(Aspect.AspectFit)
                    .Source("dotnet_bot.png")
                    .Top(),

                new Label()
                    .Text("Hello MAUI", Colors.Black)
                    .Center()
                    .TextCenter(),

                new Entry()
                    .TextColor(Colors.Black)
                    .BackgroundColor(Colors.White)
                    .Placeholder("Notes", Colors.LightGray)
            }
        }.Top().CenterHorizontal();
    }
}
