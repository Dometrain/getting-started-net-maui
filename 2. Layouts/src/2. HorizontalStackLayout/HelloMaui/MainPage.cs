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
                    .Source("dotnet_bot.png")
                    .Top(),

                new Label()
                    .Text("Hello MAUI", Colors.Black)
                    .Center()
                    .TextCenter(),

                new HorizontalStackLayout
                {
                    Spacing = 12,

                    Children =
                    {
                        new Entry()
                            .Placeholder("First Entry", Colors.DarkGray)
                            .TextColor(Colors.Black),

                        new Entry()
                            .Placeholder("Second Entry", Colors.DarkGray)
                            .TextColor(Colors.Black),

                        new Entry()
                            .Placeholder("Third Entry", Colors.DarkGray)
                            .TextColor(Colors.Black),
                    }
                }.Center()
                
            }
        }.Top().CenterHorizontal();
    }
}
