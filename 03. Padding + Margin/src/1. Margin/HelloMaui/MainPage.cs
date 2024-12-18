using static CommunityToolkit.Maui.Markup.GridRowsColumns;

namespace HelloMaui;

class MainPage : BaseContentPage
{
    public MainPage()
    {
        BackgroundColor = Colors.DarkViolet;

        Content = new ScrollView
        {
            Content = new Grid
            {
                BackgroundColor = Colors.LightSteelBlue,

                RowSpacing = 12,
                
                ColumnSpacing = 12,

                RowDefinitions = Rows.Define(
                    (Row.Image, Star),
                    (Row.Label, 100),
                    (Row.Entry, 40),
                    (Row.LargeText, 500)),

                ColumnDefinitions = Columns.Define(
                    (Column.Entry1, Star),
                    (Column.Entry2, Star),
                    (Column.Entry3, Star)),

                Children =
                {
                    new Image()
                        .Center()
                        .Size(500, 250)
                        .Aspect(Aspect.AspectFit)
                        .Source("dotnet_bot.png")
                        .Row(Row.Image).ColumnSpan(All<Column>()),

                    new Label()
                        .BackgroundColor(Colors.Green)
                        .Text("Hello MAUI", Colors.Black)
                        .Height(90)
                        .Center()
                        .TextCenter()
                        .Paddings(5, 10, 15, 30)
                        .Margins(30, 15, 10, 5)
                        .Row(Row.Label).ColumnSpan(All<Column>()),

                     new Entry()
                        .End()
                        .Placeholder("First Entry", Colors.DarkGray)
                        .TextColor(Colors.Black)
                        .Row(Row.Entry).Column(Column.Entry1),

                     new Entry()
                        .CenterHorizontal()
                        .Placeholder("Second Entry", Colors.DarkGray)
                        .TextColor(Colors.Black)
                        .Row(Row.Entry).Column(Column.Entry2),

                     new Entry()
                        .Start()
                        .Placeholder("Third Entry", Colors.DarkGray)
                        .TextColor(Colors.Black)
                        .Row(Row.Entry).Column(Column.Entry3),

                     new Label { LineBreakMode = LineBreakMode.WordWrap }
                        .Text("LARGE TEXT")
                        .TextCenter()
                        .Font(size: 100)
                        .Row(Row.LargeText).ColumnSpan(All<Column>())
                }
            }.Top().CenterHorizontal()
            .Padding(12)
            .Margins(0, 6, 0 ,0)
            
        };
    }

    enum Row { Image, Label, Entry, LargeText }
    enum Column { Entry1, Entry2, Entry3 }
}
