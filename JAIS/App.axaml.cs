using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using JAIS.Core;
using JAIS.Services.SystemService;

namespace JAIS;

public class App : Application
{
    public static Application MainWindow;

    public override void Initialize()
    {
        var systemService = Ioc.Resolve<ISystemService>();

        MainWindow = this;
        AvaloniaXamlLoader.Load(this);

        systemService.ChangeTheme(systemService.CurrentSystemConfig.DarkMode);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow();
        }
        else if (ApplicationLifetime is ISingleViewApplicationLifetime singleView)
        {
            singleView.MainView = new MainSingleView();
        }

        base.OnFrameworkInitializationCompleted();
    }
}