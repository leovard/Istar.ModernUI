using System.Windows;
using IstarWindows.ViewModels;
using Microsoft.Practices.Unity;

namespace IstarWindows.Views
{
    /// <summary>
    /// Логика взаимодействия для LoginView.xaml
    /// </summary>
    public partial class LoginView
    {
        public LoginView()
        {
            InitializeComponent();

            var container = new UnityContainer();
            container.RegisterType<LoginViewModel>();
            DataContext = container.Resolve<LoginViewModel>();
            Loaded += LoginLoaded;
        }

        private void LoginLoaded(object sender, RoutedEventArgs e)
        {
            UserNameBox.Focus();
        }
    }
}