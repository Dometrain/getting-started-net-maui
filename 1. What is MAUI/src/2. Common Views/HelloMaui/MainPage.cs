namespace HelloMaui;

class MainPage : BaseContentPage
{
    public MainPage()
    {
        Content = new Label()
                        .Text("This is a Label")
                        .Center()
                        .TextCenter();
    }
}
