using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using IstarWindows.Code;

namespace IstarWindows.ViewModels
{
    public class LoginViewModel : ViewModel
    {
        public static TextBox UserNameBox;
        public static PasswordBox UserPasswordBox;
        private static string _purpose;

        public static bool IsValid => UserNameBox != null && UserPasswordBox != null && UserNameBox.Text.Length > 7 && UserPasswordBox.Password.Length > 7;

        public string Purpose
        {
            get
            {
                return _purpose;
            }
            set
            {
                _purpose = value;
                NotifyPropertyChanged();
            }
        }

        public static ICommand LoginCommand
        {
            get
            {
                return new ActionCommand(p => Login(), p => IsValid);
            }
        }

        public static string UserName => PasswordDecryptor.Unprotect(Properties.Resources.Email, _purpose);

        public static string UserPassword => PasswordDecryptor.Unprotect(Properties.Resources.Hash, _purpose);

        private static void Login()
        {
            Application.Current.MainWindow.Title = "Авторизация";
            //PasswordDecryptor.Protect(UserNameBox.Text, _purpose)
            //PasswordDecryptor.Protect(UserPasswordBox.Password, _purpose)
            if (UserNameBox.Text == UserName && UserPasswordBox.Password == UserPassword)
            {
                Application.Current.MainWindow.DialogResult = true;
            }
            else
            {
                if (Application.Current.MainWindow.Title != "Криптография!")
                {
                    Application.Current.MainWindow.Title = "Авторизация!";
                }
            }
        }

        public LoginViewModel()
        {
            if (Application.Current.MainWindow != null) Application.Current.MainWindow.Loaded += LoginView_Loaded;
        }

        private static void LoginView_Loaded(object sender, RoutedEventArgs e)
        {
            UserNameBox = UiHelper.FindChild<TextBox>(Application.Current.MainWindow, "UserNameBox");
            UserPasswordBox = UiHelper.FindChild<PasswordBox>(Application.Current.MainWindow, "UserPasswordBox");
        }
    }
}
