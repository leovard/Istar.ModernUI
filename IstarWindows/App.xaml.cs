using System;
using System.Timers;
using System.Windows;
using Istar.ModernUI.Presentation;
using Istar.ModernUI.Windows.Controls;

namespace IstarWindows
{
	/// <summary>
	/// Логика взаимодействия для App.xaml
	/// </summary>
	public partial class App
	{
		public static NewWindow NewWindow;
		public static Timer SplashTimer { get; set; }
		public static ModernDialog SplashWin { get; set; }

		protected override void OnStartup(StartupEventArgs e)
		{
			base.OnStartup(e);
			AppearanceManager.Current.FontSize = FontSize.Small;
			//AppearanceManager.Current.ThemeSource = New Uri("/IstarRealEstateWindows;component/Assets/ModernUI.Love.xaml", UriKind.Relative)
#if DEBUG
			Current.ShutdownMode = ShutdownMode.OnExplicitShutdown;
			GetSplash();
			Current.ShutdownMode = ShutdownMode.OnMainWindowClose;
#else
			Current.ShutdownMode = ShutdownMode.OnExplicitShutdown;
			var context = new IstarContext();
			NewWindow = new NewWindow() { Title = "Авторизация", Topmost = true };
			NewWindow.Buttons = new[] { NewWindow.OkButton, NewWindow.CancelButton };
			NewWindow.OkButton.Content = "подтвердить";
			NewWindow.OkButton.Command = LoginViewModel.LoginCommand;
			NewWindow.Content = new LoginView();
			NewWindow.ShowDialog();
			if (NewWindow.DialogResult == false)
			{
				Process.GetCurrentProcess().Kill();
			}
			NewWindow.Close();
			GetSplash();
			context.Dispose();
			Current.ShutdownMode = ShutdownMode.OnMainWindowClose;
#endif
		}

		public static void GetSplash()
		{
			SplashTimer = new Timer { Interval = 2500 };
			SplashTimer.Start();
			SplashTimer.Elapsed += SplashElapsed;
			SplashWin = new ModernDialog
			{
				WindowStartupLocation = WindowStartupLocation.CenterScreen,
				SizeToContent = SizeToContent.WidthAndHeight,
				Buttons = null,
				Title = "Идет загрузка",
				Content = new SplashScreen()
			};
			SplashWin.ShowDialog();
		}

		private static void SplashElapsed(object sender, ElapsedEventArgs e)
		{
			Current.Dispatcher.Invoke(() => SplashWin.Close());
		}

		protected override void OnExit(ExitEventArgs e)
		{
			GC.Collect();
			GC.WaitForPendingFinalizers();
			GC.Collect();
			GC.WaitForPendingFinalizers();
		}
	}
}
