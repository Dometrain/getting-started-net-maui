using Microsoft.Maui.Layouts;

namespace HelloMaui;

public class MainPage : ContentPage
{
    const int imageWidthRequest = 500;
    const int imageHeightRequest = 250;
    const int labelHeightRequest = 32;
    const int absoluteLayoutChildrenSpacing = 12;

    public MainPage()
    {
        BackgroundColor = Colors.DarkViolet;

        Content = new AbsoluteLayout
        {
            BackgroundColor = Colors.LightSteelBlue,

            Children =
            {
                new Image()
                    .Size(imageWidthRequest, imageHeightRequest)
                    .Aspect(Aspect.AspectFit)
                    .Source("dotnet_bot.png")
                    .LayoutFlags(AbsoluteLayoutFlags.PositionProportional)
                    .LayoutBounds(0.5, 0),

                new Label()
                    .Height(labelHeightRequest)
                    .Text("Hello MAUI", Colors.Black)
                    .Center()
                    .TextCenter()
                    .LayoutFlags(AbsoluteLayoutFlags.XProportional)
                    .LayoutBounds(0.5, imageHeightRequest + absoluteLayoutChildrenSpacing),

                 new Entry()
                    .Placeholder("First Entry", Colors.DarkGray)
                    .TextColor(Colors.Black)
                    .LayoutFlags(AbsoluteLayoutFlags.XProportional | AbsoluteLayoutFlags.WidthProportional)
                    .LayoutBounds(0, imageHeightRequest + absoluteLayoutChildrenSpacing + labelHeightRequest + absoluteLayoutChildrenSpacing, 0.3, labelHeightRequest),

                 new Entry()
                    .Placeholder("Second Entry", Colors.DarkGray)
                    .TextColor(Colors.Black)
                    .LayoutFlags(AbsoluteLayoutFlags.XProportional | AbsoluteLayoutFlags.WidthProportional)
                    .LayoutBounds(0.5, imageHeightRequest + absoluteLayoutChildrenSpacing + labelHeightRequest + absoluteLayoutChildrenSpacing, 0.3, labelHeightRequest),

                 new Entry()
                    .Placeholder("Third Entry", Colors.DarkGray)
                    .TextColor(Colors.Black)
                    .LayoutFlags(AbsoluteLayoutFlags.XProportional | AbsoluteLayoutFlags.WidthProportional)
                    .LayoutBounds(1, imageHeightRequest + absoluteLayoutChildrenSpacing + labelHeightRequest + absoluteLayoutChildrenSpacing, 0.3, labelHeightRequest),
            }
        }.Top().CenterHorizontal();
    }
}
