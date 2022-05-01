using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using MyCSV.ViewModels;
using MyCSV.Views;

namespace MyCSV
{
    public partial class App : Application
    {

        public static App I;

        public Models.ModelCSV modelCSV;

        public Window mainWindow;

        public override void Initialize()
        {
            I = this;

            modelCSV = new Models.ModelCSV();

            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = new MainWindow
                {
                    DataContext = new MainWindowViewModel(),
                };
                mainWindow = desktop.MainWindow;
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}
