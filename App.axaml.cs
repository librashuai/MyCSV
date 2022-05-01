using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using MyCSV.ViewModels;
using MyCSV.Views;
using System.IO;

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

                desktop.Startup += Desktop_Startup;
            }

            base.OnFrameworkInitializationCompleted();
        }

        private void Desktop_Startup(object? sender, ControlledApplicationLifetimeStartupEventArgs e)
        {
            var args = e.Args;
            if(args.Length == 1)
            {
                var file = args[0];
                if(File.Exists(file))
                {
                    modelCSV.LoadCSV(file);
                }
            }
        }
    }
}
