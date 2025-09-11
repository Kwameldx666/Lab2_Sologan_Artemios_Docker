namespace TaskManagerApp;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        var mainPage = Handler?.MauiContext?.Services.GetService<MainPage>();
        return new Window(mainPage ?? new MainPage(null!, null!));
    }
}