using static CommunityToolkit.Maui.Markup.GridRowsColumns;

namespace HelloMaui;

class MainPage : BaseContentPage
{
    public MainPage()
    {
        BackgroundColor = Colors.DarkViolet;

        Content = new Grid
        {
            BackgroundColor = Colors.LightSteelBlue,

            RowSpacing = 12,

            RowDefinitions = Rows.Define(
                (Row.Image, Star),
                (Row.Label, 32),
                (Row.Entry, 40)),

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
                    .Text("Hello MAUI", Colors.Black)
                    .Center()
                    .TextCenter()
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
            }
        }.Top().CenterHorizontal();
    }

    enum Row { Image, Label, Entry }
    enum Column { Entry1, Entry2, Entry3}
}
