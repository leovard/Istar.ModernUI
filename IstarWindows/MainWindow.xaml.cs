using System;
using System.Windows;
using Istar.ModernUI.Windows.Controls;
using IstarWindows.ViewModels;
using Microsoft.Practices.Unity;

namespace IstarWindows
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            var container = new UnityContainer();
            container.RegisterType<MainViewModel>();
            DataContext = container.Resolve<MainViewModel>();
            Loaded += MainLoaded;
        }

        private void MainLoaded(object sender, RoutedEventArgs e)
        {
            var contentFrame = GetTemplateChild("ContentFrame") as ModernFrame;
            if (contentFrame != null)
            {
                contentFrame.KeepContentAlive = false;
            }
            if (MainViewModel.CanExecuteSchema)
            {
                ModernDialog.ShowMessage("Перед началом работы с программой требуется" + Environment.NewLine + "выполнить скрипт для обновления базы данных.", "Внимание!", MessageBoxButton.OK);
            }
            else
            {
                if (MainViewModel.CanExecuteScript)
                {
                    ModernDialog.ShowMessage("Для продолжения работы с программой требуется" + Environment.NewLine + "выполнить скрипт для заполнения базы данных.", "Внимание!", MessageBoxButton.OK);
                }
            }
            LinkNavigator.Commands.Add(MainViewModel.AboutLink.Source, MainViewModel.AboutCommand);
            LinkNavigator.Commands.Add(MainViewModel.SchemaLink.Source, MainViewModel.GoSchemaCommand);
            LinkNavigator.Commands.Add(MainViewModel.ScriptLink.Source, MainViewModel.GoScriptCommand);
            LinkNavigator.Commands.Add(MainViewModel.SoundLink.Source, MainViewModel.GoSoundCommand);
            LinkNavigator.Commands.Add(MainViewModel.ExitLink.Source, MainViewModel.GoExitCommand);
        }
    }
}
